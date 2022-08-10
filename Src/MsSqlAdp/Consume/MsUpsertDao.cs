using System.Text;
using Dafist.Engine.FieldsData;
using Dafist.Engine.Updates;
using Dafist.SqlCommon;
using Dafist.SqlCommon.Basics;
using Dafist.SqlCommon.Consume;

namespace Dafist.MsSqlAdp.Consume
{
    class MsUpsertDao : UpsertDao
    {
        private readonly FieldDataHelper h;
        private readonly RobustDaBasics basics;
        private readonly TransactionTextAdder transactionTextAdder;
        public MsUpsertDao(RobustDaBasics basics, TransactionTextAdder transactionTextAdder, FieldDataHelper helper)
        {
            this.h = helper;
            this.transactionTextAdder = transactionTextAdder;
            this.basics = basics;
        }

        // https://michaeljswart.com/2017/07/sql-server-upsert-patterns-and-antipatterns/
        /*
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
        BEGIN TRAN
            IF EXISTS (SELECT * FROM Employee WHERE ID1 = @ID1 AND ID2 = @ID2)
                UPDATE Employee
                SET Col1 = Val1, Col2 = Val2, ...., ColN = ValN
                WHERE ID1 = @ID1 AND ID2 = @ID2
            ELSE
                INSERT INTO dbo.Employee(Col1, ..., ColN)
                VALUES(Val1, .., ValN)
        COMMIT
        */

        public bool Upsert(TargetUpdate upsert)
        {
            var allFieldsData = upsert.AllData;
            //var targetSrcIdData = def.SourceIdFieldsData(data);
            var correlationData = upsert.CorrelationData;

            var sqlText = CreatSqlText(upsert.EntityName, allFieldsData, correlationData);
            
            sqlText = transactionTextAdder.Add(sqlText);

            var parameters = h.CreateParams(allFieldsData);

            var r = basics.Execute(new Sql(sqlText, parameters), "upsert");

            return r;
        }

        string CreatSqlText(string tableName, FieldDataSet allFieldsData, FieldDataSet correlationData)
        {
            var r = new StringBuilder();

            if (correlationData.IsEmpy())
            {
                r.Append(
                    CreateInsert(tableName, allFieldsData));
            }
            else
            {
                r.Append(
                    CreateIfUpdate(tableName, allFieldsData, correlationData));

                r.Append("\nELSE\n");

                r.Append(
                    CreateInsert(tableName, allFieldsData));
    
            }
            
            return r.ToString();
        }

        string CreateIfUpdate(string tableName, FieldDataSet allFieldsData,FieldDataSet correlationData)
        {
            var r = new StringBuilder();

            var whereClause = h.CreateWhere(correlationData);
            
            r.AppendFormat("IF EXISTS (SELECT * FROM {0} {1})\n", tableName, whereClause);

            r.Append(
                CreateUpdate(tableName, allFieldsData, whereClause));

            return r.ToString();
        }


        string CreateUpdate(string tableName, FieldDataSet allFieldsData, string whereClause)
        {
            var equalsText = h.CreateSqlText(allFieldsData,(fn, pv) => string.Format("{0}={1}", fn, pv), ", ");

            return string.Format("UPDATE {0}\nSET {1}\n{2};", tableName, equalsText, whereClause);
        }


        string CreateInsert(string tableName, FieldDataSet allFieldsData)
        {
            var fieldNames = h.CreateSqlText(allFieldsData,(fn, pv) => fn, ", ");

            var fieldValues = h.CreateSqlText(allFieldsData,(fn, pv) => pv, ", ");

            return string.Format("INSERT INTO {0}({1})\nVALUES({2});",
                tableName, fieldNames, fieldValues);
        }
    }
}
