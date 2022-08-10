using System;
using log4net;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Tools;

namespace Dafist.Engine.Resilience.SafeExecution
{
    public class SafeExecuter
    {
        private bool stop;

        private readonly ProblemProcessor problemProcessor;
        private readonly EngineSettings settings;
        private readonly Sleeper sleeper;
        private readonly ILog log;
        internal SafeExecuter(ProblemProcessor problemProcessor,SafeExecutersClub club, EngineSettings settings, ILog log)
        {
            this.problemProcessor = problemProcessor;
            this.settings = settings;
            //this.sleeper = new Sleeper(new SleepLogger.Active(log));
            this.sleeper = new Sleeper();
            this.log = log;

            club.Register(this);
        }

        public void Stop()
        {
            stop = true;
            sleeper.Stop();
        }

        public bool Execute(Action operation, string operationName)
        {
            var failureDescription = operationName + " failed";

            TryResult tr;
            do
            {
                tr = TryToDo(operation, failureDescription);

                if (tr.ShouldRetry())
                {
                    this.sleeper.Sleep(this.settings.FailureSleepTime, failureDescription); //"failure"
                }

            } while (tr.ShouldRetry() && !stop);

            return tr.Success;
        }

        TryResult TryToDo(Action operation, string logfailure)
        {
            try
            {
                operation();

                return new TryResult(success:true, reaction:ReactionType.None); 
            }
            catch (Exception x)
            {
                log.Info("Exception caught in SafeExecuter");

                var problem=new Problem(x);
                ReactionType reactionType;
                problemProcessor.Process(problem,out reactionType);
                
                if (reactionType== ReactionType.Rethrow)
                {
                    throw;
                }

                log.Info(logfailure, x);

                return new TryResult(success: false, reaction: reactionType); 
            }
        }
    }
}
