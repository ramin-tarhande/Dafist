namespace Dafist.Engine.Resilience.Problems
{
    public class FixedPte : ProblemTypeExpert
    {
        private readonly ProblemType defaultProblemType;

        public FixedPte(ProblemType defaultProblemType)
        {
            this.defaultProblemType = defaultProblemType;
        }

        public ProblemType Determine(Problem problem)
        {
            return defaultProblemType;
        }
    }
}
