using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Consume.Map
{
    class MappingPte : SeparatedSchemaPte
    {
        public MappingPte(SchemaErrorExpert schemaErrorExpert)
            : base(schemaErrorExpert)
        {
        }

        protected override ProblemType DetermineNonSchema(Problem problem)
        {
            return problem.Exception is ExternalSystemNotAvailableException ? 
                ProblemType.RetriableFailure : ProblemType.DataProblem;
        }
    }
}
