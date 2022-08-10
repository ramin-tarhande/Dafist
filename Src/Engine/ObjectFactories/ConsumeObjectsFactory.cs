using Dafist.Engine.Consume;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Progress;

namespace Dafist.Engine.ObjectFactories
{
    public interface ConsumeObjectsFactory
    {
        ProblemTypeExpert CreateProblemTypeExpert();
        Consumer CreateConsumer(SafeExecuter safeExecuter, ProgressMeter progress);
    }
}