using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Resilience.Problems
{
    public class FixedNonSchemaPte : SeparatedSchemaPte
    {
        private readonly ProblemType nonSchemaPt;
        public FixedNonSchemaPte(SchemaErrorExpert schemaErrorExpert, 
            ProblemType nonSchemaPt)
            :base(schemaErrorExpert)
        {
            this.nonSchemaPt = nonSchemaPt;
        }

        protected override ProblemType DetermineNonSchema(Problem problem)
        {
            return nonSchemaPt;
        }
    }
}
