using Dafist.Engine.Resilience.Problems;

namespace Dafist.Engine.ObjectFactories
{
    public interface GetObjectsFactory
    {
        ProblemTypeExpert CreateProblemTypeExpert();
    }
}