using System.Collections.Generic;
using System.Linq;
using log4net;
using Dafist.Engine.Get.Load;
using Dafist.Engine.Schemas;
using Dafist.Engine.Schemas.Top;
using Dafist.Engine.Updates;
using Dafist.MsSqlAdp.Updates;

namespace Dafist.MsSqlAdp.Get
{
    class MsLoader : Loader
    {
        private readonly ChangeTrackingDao dao;
        private readonly VersionRangeExpert versionRangeExpert;
        private readonly Schema schema;
        private readonly ILog log;
        public MsLoader(ChangeTrackingDao dao, VersionRangeExpert versionRangeExpert, Schema schema, ILog log)
        {
            this.dao = dao;
            this.versionRangeExpert = versionRangeExpert;
            this.schema = schema;
            
            this.log = log;
        }

        public IEnumerable<SourceUpdate> Load()
        {
            var versionRange = versionRangeExpert.GetVersionRange();

            if (versionRange.IsEmpty())
            {
                //progress.LoadState = LoadState.Idle;
                log.Debug("version range is empty");
                log.Debug("");
                //sleeper.Sleep(settings.LoadIdleSleepTime, "readIdle");
                return Enumerable.Empty<SourceUpdate>();
            }

            var updates = LoadCore(versionRange);

            updates = Order(updates);

            versionRangeExpert.SyncDoneWith(versionRange);

            return updates;
        }

        IEnumerable<MsSourceUpdate> LoadCore(VersionRange versionRange)
        {
            var all = new List<MsSourceUpdate>();

            foreach (var sourceEntities in schema.SourceEntities)
            {
                var entityUpdates = dao.Load(sourceEntities, versionRange: versionRange);

                //if (tableUpdates.OfType<Delete>().Any()) throw new Exception("horrible conditions");

                var count = entityUpdates.Count();
                log.DebugFormat("{0} updates: {1}", sourceEntities.Name, count);

                all.AddRange(entityUpdates);
            }

            return all;
        }

        static IEnumerable<MsSourceUpdate> Order(IEnumerable<MsSourceUpdate> all)
        {
            return all.OrderBy(c => c.Version.Value).ToList();
        }
    }
}
