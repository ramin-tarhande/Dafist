using System;
using System.Diagnostics;
using log4net;

namespace Dafist.Engine.Tools
{
    class PerfLogTool
    {
        private readonly ILog log;
        public PerfLogTool(ILog log)
        {
            this.log = log;
        }

        public void Exec(Action action,string actionName)
        {
            var sw = Stopwatch.StartNew();
            action();
            sw.Stop();

            log.DebugFormat("{0} done in {1}",actionName,sw.Elapsed.TotalMilliseconds);
        }
    }
}
