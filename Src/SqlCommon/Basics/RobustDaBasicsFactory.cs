using System.Data;
using log4net;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.SqlCommon.Basics
{
    public abstract class RobustDaBasicsFactory
    {
        private readonly CommonSqlSettings settings;
        private readonly ILog log;

        protected RobustDaBasicsFactory(CommonSqlSettings settings, ILog log)
        {
            this.settings = settings;
            this.log = log;
        }

        public RobustDaBasics Create(string connectionString, SafeExecuter safeExecuter)
        {
            var basicOperations = new BasicDaOperations(() => CreateDbConnection(connectionString),
                settings, log);

            return new RobustDaBasics(basicOperations, safeExecuter);
        }

        protected abstract IDbConnection CreateDbConnection(string connectionString);
    }
}
