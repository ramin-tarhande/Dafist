using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.Engine.Composing.GetPart
{
    static class GetProblemProcessorFactory
    {
        public static ProblemProcessor Create(GetObjectsFactory getObjectsFactory,CommonObjects c)
        {
            SetFailed setFailed = () => c.Progress.GetState = GetState.Failed;

            var problemTypeExpert = getObjectsFactory.CreateProblemTypeExpert();

            var problemProcessor = new ProblemProcessor(problemTypeExpert, c.Progress, setFailed, c.Log);

            return problemProcessor;
        }

    }
}
