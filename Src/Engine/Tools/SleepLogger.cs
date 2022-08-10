using log4net;
using System;

namespace Dafist.Engine.Tools
{
    public abstract class SleepLogger
    {
        public static SleepLogger Null = new _Null();
        public abstract void Before(TimeSpan sleepTime, string context);
        public abstract void After(TimeSpan sleepTime, string context,bool aborted);

        public class Active : SleepLogger
        {
            private readonly ILog log;
            Guid guid;
            public Active(ILog log)
            {
                this.log = log;
            }

            public override void Before(TimeSpan sleepTime, string context)
            {
                guid = Guid.NewGuid();
                log.DebugFormat("Sleep for {0} ({1}) {2}", sleepTime, context, guid);
            }

            public override void After(TimeSpan sleepTime, string context, bool aborted)
            {
                if (aborted)
                {
                    log.DebugFormat("Sleep aborted ({0}) {1}", context, guid);
                }
                else
                {
                    log.DebugFormat("Sleep done ({0}) {1}", context, guid);
                }
            }
        }

        private class _Null : SleepLogger
        {
            public override void Before(TimeSpan sleepTime, string context)
            {
            }

            public override void After(TimeSpan sleepTime, string context, bool aborted)
            {
            }
        }

    }
}
