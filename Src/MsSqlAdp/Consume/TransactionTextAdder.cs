using System.Text;

namespace Dafist.MsSqlAdp.Consume
{
    abstract class TransactionTextAdder
    {
        public static TransactionTextAdder Create(MsTargetSqlSettings settings)
        {
            return settings.UseTransactions ? (TransactionTextAdder)new Actual() : new Null();
        }

        public abstract string Add(string sqlText);

        class Null:TransactionTextAdder
        {
            public override string Add(string sqlText)
            {
                return sqlText;
            }
        }

        class Actual : TransactionTextAdder
        {
            public override string Add(string sqlText)
            {
                var r = new StringBuilder();

                r.Append("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;\n");
                r.Append("BEGIN TRAN\n");

                r.Append(sqlText);

                r.Append("\n");
                r.Append("COMMIT");

                return r.ToString();
            }
        }
    }
}
