using System.Data;
using System.Data.SqlClient;
using log4net;
using Dafist.SqlCommon;
using Dafist.SqlCommon.Basics;

namespace Dafist.MsSqlAdp.ObjectFactories
{
    class MsRobustDaBasicsFactory : RobustDaBasicsFactory
    {
        public MsRobustDaBasicsFactory(CommonSqlSettings settings, ILog log)
            : base(settings, log)
        {
        }

        protected override IDbConnection CreateDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
