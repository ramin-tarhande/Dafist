using Dafist.Engine.Updates;
using Dafist.SqlCommon.Basics;

namespace Dafist.SqlCommon.Consume
{
    public class DeleteDao
    {
        private readonly FieldDataHelper h;
        private readonly RobustDaBasics basics;
        public DeleteDao(RobustDaBasics basics, FieldDataHelper helper)
        {
            this.basics = basics;
            this.h = helper;
        }

        /*
            DELETE FROM Employee WHERE ID1 = @ID1 AND ID2 = @ID2
         */

        internal bool Delete(TargetUpdate update)
        {
            //var idData = update.IdData();
            var data = update.CorrelationData;
            if (data.IsEmpy())
            {
                return false;
            }

            var sqlText = string.Format("DELETE FROM {0} {1};",
                update.EntityName,
                h.CreateWhere(data));

            var parameters = h.CreateParams(data);

            var r = basics.Execute(new Sql(sqlText, parameters), "delete");

            return r;
        }
    }
}
