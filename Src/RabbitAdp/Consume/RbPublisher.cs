using EasyNetQ;
using Dafist.Engine.Consume;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Schemas;
using Dafist.Engine.Updates;

namespace Dafist.RabbitAdp.Consume
{
    class RbPublisher : Consumer
    {
        private IBus bus;
        private readonly SafeExecuter safeExecuter;
        private readonly RbSettings settings;
        public RbPublisher(SafeExecuter safeExecuter, RbSettings settings, object consumerId) 
            : base(consumerId)
        {
            this.safeExecuter = safeExecuter;
            this.settings = settings;
        }

        public override void Check(Mapping mapping)
        {
            
        }

        public override void Start()
        {
            bus = RbBusFactory.Start(settings);
        }

        public override bool Consume(TargetUpdate update)
        {
            var r = safeExecuter.Execute(
                () => Publish(update), "publish");

            return r;
        }

        void Publish(TargetUpdate update)
        {
            var msg = update.ToMessage();

            var topic = CreateTopic(update);

            bus.Publish(msg, c=>c.WithTopic(topic));
        }

        static string CreateTopic(TargetUpdate update)
        {
            return string.Format("{0}.{1}", update.EntityName, update.UpdateType);
        }

        public override void Stop()
        {
        }

        public override void Dispose()
        {
            if (bus != null)
            {
                bus.Dispose();
            }
        }
    }
}
