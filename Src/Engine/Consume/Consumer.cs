using System;
using Dafist.Engine.Schemas;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Consume
{
    public abstract class Consumer : ConsumerBasics,IDisposable
    {
        public object Id { get; private set; }
        protected Consumer(object consumerId)
        {
            Id = consumerId;
        }

        /// <summary>
        /// is the mapping appropriate for the consumer
        /// do consumer-specific checks
        /// </summary>
        /// <param name="mapping"></param>
        public abstract void Check(Mapping mapping);

        /// <summary>
        /// start working
        /// </summary>
        public abstract void Start();

        public abstract bool Consume(TargetUpdate update);

        /// <summary>
        /// stop working
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// release resources
        /// </summary>
        public abstract void Dispose();
    }
}