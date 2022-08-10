using System;
using System.Collections.Generic;
using System.Diagnostics;
using log4net;
using Dafist.Engine.Buffers;
using Dafist.Engine.Consume.Map;
using Dafist.Engine.Progress;
using Dafist.Engine.Schemas;
using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Schemas.Top;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Consume.Top
{
    class ConsumeDirector : IDisposable
    {
        private readonly ConsumeMapper mapper;
        private readonly IEnumerable<Consumer> consumers;
        private readonly Schema schema;
        private readonly UpdatesBuffer buffer;
        private readonly ProgressMeter progress;
        private readonly ILog log;

        public ConsumeDirector(ConsumeMapper mapper, IEnumerable<Consumer> consumers,Schema schema,
            UpdatesBuffer buffer, ProgressMeter progress, ILog log)
        {
            this.schema = schema;
            this.consumers = consumers;
            this.mapper = mapper;
            this.progress = progress;
            this.buffer = buffer;
            this.log = log;
        }

        public void Start()
        {
            CheckMappings();
            foreach (var consumer in consumers)
            {
                consumer.Start();
            }    
        }

        /// fail fast if there is problem in mappings
        void CheckMappings()
        {
            foreach (var sourceEntity in schema.SourceEntities)
            {
                foreach (var consumer in consumers)
                {
                    var mapping = FindMapping(sourceEntity, consumer);
                    if (mapping!=null)
                    {
                        consumer.Check(mapping);
                    }
                }
            }
        }


        internal void Stop()
        {
            foreach (var consumer in consumers)
            {
                consumer.Stop();
            }
        }

        public void Dispose()
        {
            //mapper.Stop();
            foreach (var consumer in consumers)
            {
                consumer.Dispose();
            }
        }

        public bool Consume()
         {
            log.Debug("");
            log.Debug("Consume updates");

            progress.ConsumeState = ConsumeState.Free;

            //log.Debug(" wait for data");
            var stopState=buffer.WaitForData();
            if (stopState.Stopped)
            {
                return false;
            }

            progress.ConsumeState = ConsumeState.Busy;

            //log.Debug(" take data");
            var update = buffer.Take();
            Trace.Assert(update != null, "update!=null");

            //
            ConsumeCore(update);
            
             return true;
         }

        void ConsumeCore(SourceUpdate sourceUpdate)
        {
            log.Debug(sourceUpdate.Text());

            foreach (var consumer in consumers)
            {
                var sourceEntity = sourceUpdate.Entity;
                var mapping = FindMapping(sourceEntity, consumer);
                if (mapping!=null)
                {
                    var targetUpdate = mapper.Map(sourceUpdate, mapping);
                    if (targetUpdate != null)
                    {
                        FeedToConsumer(targetUpdate, consumer);
                    }    
                }
                
            }    
        }

        static Mapping FindMapping(SourceEntity sourceEntity, Consumer consumer)
        {
            return sourceEntity.GetMappingFor(consumer);
        }

        private void FeedToConsumer(TargetUpdate targetUpdate,Consumer consumer)
        {
            //var pad = "".PadLeft(targetUpdate.UpdateType.ToString().Length+2);
            log.DebugFormat(" {0} ({1}) ( {2} )", targetUpdate.Text(), targetUpdate.UpdateType, consumer.Id);

            var r = consumer.Consume(targetUpdate);
            if (r)
            {
                progress.ConsumeDone();
            }
        }
    }
}
