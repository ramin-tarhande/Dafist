namespace Dafist.Engine.Resilience.Problems
{
    public interface ProblemTypeExpert
    {
        ProblemType Determine(Problem problem);
    }
}