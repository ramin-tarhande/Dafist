using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.Schemas;
using Dafist.Engine.Schemas.Source;
using Dafist.MsSqlAdp.Updates;
using Dafist.SqlCommon;
using Dafist.SqlCommon.Basics;

namespace Dafist.MsSqlAdp.Get
{
    class ChangeTrackingDao
    {
        private readonly RobustDaBasics basics;
        private readonly CtSqlExpert ctSqlExpert;
        private readonly UpdateFactory updateFactory;
        public ChangeTrackingDao(RobustDaBasics basics)
        {
            this.basics=basics;
            ctSqlExpert=new CtSqlExpert();
            updateFactory=new UpdateFactory();
        }

        internal Version GetLastExistingVersion()
        {
            var v = basics.Query<long>(
                new Sql("select CHANGE_TRACKING_CURRENT_VERSION()"),"GetLastExistingVersion")
                          .FirstOrDefault();

            return new Version(v);
        }

        internal IEnumerable<MsSourceUpdate> Load(SourceEntity entity, VersionRange versionRange)
        {
            var rows = LoadCore(entity, versionRange);

            var updates = Convert(rows, entity);
            
            return updates;
        }

        IEnumerable<object> LoadCore(SourceEntity entity, VersionRange versionRange)
        {
            var sql = ctSqlExpert.CreatSql(entity, versionRange);

            return basics.Query<object>(sql,"LoadTrackingData");

        }

        IEnumerable<MsSourceUpdate> Convert(IEnumerable<object> rows, SourceEntity entity)
        {
            return rows.Select(rowData =>
                updateFactory.Create(rowData, entity))
                .ToList();
        }
        /*
        internal void Stop()
        {
            basics.Stop();
        }*/
    }
}
