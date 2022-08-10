using log4net;
using Dafist.MsSqlAdp.Updates;

namespace Dafist.MsSqlAdp.Get
{
    class VersionRangeExpert
    {
        private Version curLower;
        private readonly ChangeTrackingDao dao;
        private readonly MsSourceSqlSettings settings;
        private readonly ILog log;
        public VersionRangeExpert(ChangeTrackingDao dao, MsSourceSqlSettings settings, ILog log)
        {
            this.settings = settings;
            this.dao = dao;
            this.log = log;
        }

        internal VersionRange GetVersionRange()
        {
            var lastExistingVersion = dao.GetLastExistingVersion();
            log.DebugFormat("curLower= {0} lastExistingVersion= {1}", CurLowerText(), lastExistingVersion);

            var upper = lastExistingVersion;
            var lower = GetLower(lastExistingVersion);
            var diff = upper.Diff(lower);
            if (diff>settings.LoadMaxVersionDiff)
            {
                log.DebugFormat("diff={0}; make upper smaller",diff);
                upper = lower.Add(settings.LoadMaxVersionDiff);
            }

            var r = new VersionRange(lower, upper);

            log.DebugFormat("Sync with version range: {0}",r.Text());

            return r;
        }


        string CurLowerText()
        {
            if (curLower == null)
            {
                return "-";
            }
            else
            {
                return curLower.ToString();
            }
        }

        Version GetLower(Version lastExistingVersion)
        {
            if (curLower == null)
            {
                //check file
                log.InfoFormat("initial version: {0}",lastExistingVersion);
                curLower = lastExistingVersion;
                //curLower = new Version(0);
            }

            return curLower;
        }

        internal void SyncDoneWith(VersionRange versionRange)
        {
            curLower = versionRange.Upper;
        }

        /*
        internal VersionRange GetLowerVersion(Version lastExistingVersion)
        {
            var lower = GetLower(lastExistingVersion);

            var upper = GetUpper(lower, lastExistingVersion);
            
            return new VersionRange(lower,upper);
        }

        
        Version GetUpper(Version lower, Version lastExistingVersion)
        {
            var diff = lastExistingVersion.Value - lower.Value;
            if (diff<0)
            {
                Trace.Fail("lastExistingVersion should not be smaller than lower versino");
            }

            if (diff<settings.MaxBufferSize)
            {
                return lastExistingVersion;
            }
            else
            {
                return new Version(lower.Value + settings.MaxBufferSize);
            }
        }*/

    }
}
