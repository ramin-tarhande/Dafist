using Dafist.Engine.Get.Receive;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.MessagingCommon;
using Dafist.RabbitAdp.Get;

namespace Dafist.RabbitAdp.ObjectFactories
{
    public class RbReceiveObjectsFactory<T> : ReceiveObjectsFactory where T : class
    {
        private readonly MessageConverter<T> messageConverter;
        private readonly string subscriptionId;
        private readonly RbReceiveSettings settings;
        public RbReceiveObjectsFactory(MessageConverter<T> messageConverter, string subscriptionId,
            RbReceiveSettings settings)
        {
            this.messageConverter = messageConverter;
            this.subscriptionId = subscriptionId;
            this.settings = settings;
        }

        public ProblemTypeExpert CreateProblemTypeExpert()
        {
            //return new FixedPte(ProblemType.DataProblem);
            return new FixedPte(ProblemType.NotRecognized);
        }

        public Receiver CreateReceiver(ProblemProcessor problemProcessor)
        {
            return new RbReceiver<T>(messageConverter, this.subscriptionId, settings);
        }
    }
}
