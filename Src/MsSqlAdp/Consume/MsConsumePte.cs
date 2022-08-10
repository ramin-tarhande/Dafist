using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.MsSqlAdp.Consume
{
    class MsConsumePte : SeparatedSchemaPte
    {
        private readonly HashSet<int> dataProblems;
        public MsConsumePte(SchemaErrorExpert schemaErrorExpert)
            : base(schemaErrorExpert)
        {
            dataProblems = new HashSet<int>()
            {
                2627, //pk
                2601, //unique index
                245, //conversion
                547, //constraint/fk
                515, //not nullable
                8152  //data would be truncated
            };
        }

        protected override ProblemType DetermineNonSchema(Problem problem)
        {
            var x = problem.Exception;

            var sx = x as SqlException;
            if (sx!=null)
            {
                return IsDataProblem(sx)? ProblemType.DataProblem : ProblemType.RetriableFailure;
            }

            if (x is SqlTypeException)
            {
                return ProblemType.DataProblem;
            }

            return ProblemType.RetriableFailure;
        }

        bool IsDataProblem(SqlException sx)
        {
            return dataProblems.Contains(sx.Number);
            //return sx.Class == 14 || sx.Class == 16;
        }
    }
}
