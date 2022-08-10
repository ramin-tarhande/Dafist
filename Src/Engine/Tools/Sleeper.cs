using System;
using System.Threading;

namespace Dafist.Engine.Tools
{
    public class Sleeper 
    {
        private readonly ManualResetEvent mre;
        private readonly SleepLogger logger;

        public Sleeper()
            :this(SleepLogger.Null)
        {
            
        }

        public Sleeper(SleepLogger logger)
        {
            this.logger = logger;
            mre = new ManualResetEvent(false);
        }

        public void Sleep(TimeSpan sleepTime, string context)
        {
            logger.Before(sleepTime, context);

            var rs = mre.WaitOne(sleepTime);

            logger.After(sleepTime, context,rs);
            
        }

        public void Stop()
        {
            mre.Set();
        }
    }
}
