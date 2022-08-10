using System;
using log4net;
using Dafist.Engine.Progress;
using Dafist.Engine.Resilience.Problems;

namespace Dafist.Engine.Resilience.SafeExecution
{
    public delegate void SetFailed();
    public class ProblemProcessor
    {
        private readonly ProblemTypeExpert problemExpert;
        private readonly ProgressMeter progress;
        private readonly SetFailed setFailed;
        private readonly ILog log;
        internal ProblemProcessor(ProblemTypeExpert problemExpert, ProgressMeter progress,
            SetFailed setFailed, ILog log)
        {
            this.log = log;
            this.setFailed = setFailed;
            this.problemExpert = problemExpert;
            this.progress = progress;
        }

        internal void Process(Problem problem, out ReactionType reactionType)
        {
            var problemType = problemExpert.Determine(problem);

            if (problemType == ProblemType.DataProblem)
            {
                progress.InvalidData();
                reactionType = ReactionType.None;
            }
            else if (problemType == ProblemType.RetriableFailure || 
                     problemType == ProblemType.NotRecognized)
            {
                setFailed();
                progress.Failed();
                reactionType = ReactionType.Retry;
            }
            else if (problemType == ProblemType.SchemaError)
            {
                reactionType = ReactionType.Rethrow;
            }
            else
            {
                throw new Exception("unexpected problem type");
            }

            log.DebugFormat("ProblemType: {0} -> ReactionType: {1}", problemType, reactionType);
        }
    }
}
