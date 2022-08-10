using log4net;
using Dafist.Engine.Buffers;
using Dafist.Engine.Consume;
using Dafist.Engine.Get;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.Engine.Facade
{
    public class EngineFacade
    {
        public SyncProgress Progress { get; private set; }

        private readonly GettingManager getting;
        private readonly ConsumingManager consuming;
        private readonly SafeExecutersClub safeExecuters;
        private readonly UpdatesBuffer buffer;
        private readonly ILog log;
        internal EngineFacade(GettingManager gettingManager, ConsumingManager consumingManager, UpdatesBuffer buffer,
            SafeExecutersClub safeExecuters,
            SyncProgress progress, ILog log)
        {
            this.safeExecuters = safeExecuters;
            this.buffer = buffer;
            this.Progress = progress;
            this.consuming = consumingManager;
            this.getting = gettingManager;
            this.log = log;
        }

        public void Start()
        {
            log.Debug("");
            log.Debug("Starting engine");

            getting.Start();
            consuming.Start();
        }

        public void Stop()
        {
            log.Debug("");
            log.Debug("Stopping engine");

            safeExecuters.StopAll();

            buffer.Stop();

            getting.Stop();
            consuming.Stop();

            log.Debug("Engine stopped");
        }
    }
}
