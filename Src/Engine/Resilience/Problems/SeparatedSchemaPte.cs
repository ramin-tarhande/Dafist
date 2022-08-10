using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Resilience.Problems
{
    public abstract class SeparatedSchemaPte : ProblemTypeExpert
    {
        private readonly SchemaErrorExpert schemaErrorExpert;
        protected SeparatedSchemaPte(SchemaErrorExpert schemaErrorExpert)
        {
            this.schemaErrorExpert = schemaErrorExpert;
        }

        public ProblemType Determine(Problem problem)
        {
            if (schemaErrorExpert.IsSchemaError(problem.Exception))
            {
                return ProblemType.SchemaError;
            }

            return DetermineNonSchema(problem);
        }

        protected abstract ProblemType DetermineNonSchema(Problem problem);
    }
}