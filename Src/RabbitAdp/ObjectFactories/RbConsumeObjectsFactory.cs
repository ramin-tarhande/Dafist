using Dafist.Engine.Consume;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Progress;
using Dafist.RabbitAdp.Consume;

namespace Dafist.RabbitAdp.ObjectFactories
{
    public class RbConsumeObjectsFactory : ConsumeObjectsFactory
    {
        private readonly RbSettings settings;
        private readonly object consumerId;
        public RbConsumeObjectsFactory(RbSettings settings, object consumerId)
        {
            this.consumerId = consumerId;
            this.settings = settings;
        }

        public ProblemTypeExpert CreateProblemTypeExpert()
        {
            return new FixedPte(ProblemType.RetriableFailure);
        }

        public Consumer CreateConsumer(SafeExecuter safeExecuter, ProgressMeter progress)
        {
            return new RbPublisher(safeExecuter, settings, consumerId);
        }
    }
}
