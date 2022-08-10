using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using log4net;

namespace Dafist.SqlCommon.Basics
{
    public class BasicDaOperations
    {
        private readonly Func<IDbConnection> dbConnectionFactory;
        private readonly ILog log;
        private readonly CommonSqlSettings settings;
        public BasicDaOperations(Func<IDbConnection> dbConnectionFactory, CommonSqlSettings settings, ILog log)
        {
            this.settings = settings;
            this.dbConnectionFactory = dbConnectionFactory;
            this.log = log;
        }

        internal void Execute(Sql sql)
        {
            int r;

            try
            {
                using (var connection = Open())
                {
                    r = connection.Execute(sql.Text, sql.Parameters, null, settings.DbCommandTimeout_s);
                }
            }
            catch
            {
                log.DebugFormat("Failed to execute sql command:\n {0}", sql.Text);
                throw;
            }

            if (settings.LogAffectedRows)
            {
                log.DebugFormat("    af={0}", r);
            }
        }


        internal IEnumerable<T> Query<T>(Sql sql)
        {
            try
            {
                using (var connection = Open())
                {
                    return connection.Query<T>(sql.Text, sql.Parameters, null, true, settings.DbCommandTimeout_s);
                }
            }
            catch (Exception)
            {
                log.DebugFormat("Failed to run sql query:\n {0}", sql.Text);
                throw;
            }
            
        }

        IDbConnection Open()
        {
            var c = dbConnectionFactory();
            c.Open();

            return c;
        }
    }
}
