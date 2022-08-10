using System;
using Dafist.Engine.Consume;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Progress;
using Dafist.Engine.Schemas;
using Dafist.Engine.Tools;
using Dafist.Engine.Updates;
using log4net;

namespace SyncApp3.Run
{
    class SimpleConsumeObjectsFactory : ConsumeObjectsFactory
    {
        private readonly Consumer consumer;
        public SimpleConsumeObjectsFactory(Consumer consumer)
        {
            this.consumer = consumer;
        }

        public ProblemTypeExpert CreateProblemTypeExpert()
        {
            return new FixedPte(ProblemType.NotRecognized);
        }

        public Consumer CreateConsumer(SafeExecuter safeExecuter, ProgressMeter progress)
        {
            return consumer;
        }
    }

    class DelayerConsumer : Consumer
    {
        private readonly TimeSpan delayTime;
        private readonly Sleeper sleeper;
        public DelayerConsumer(TimeSpan delayTime, object consumerId, ILog log)
            : base(consumerId)
        {
            this.delayTime = delayTime;
            sleeper=new Sleeper();

        }

        public override void Check(Mapping mapping)
        {
            
        }

        public override void Start()
        {
            
        }

        public override bool Consume(TargetUpdate update)
        {
            sleeper.Sleep(delayTime,"delayConsume");
            return true;
        }

        public override void Stop()
        {
            sleeper.Stop();
        }

        public override void Dispose()
        {
        }
    }

}
