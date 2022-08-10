using System.Linq;
using log4net;
using Dafist.Engine.Buffers;
using Dafist.Engine.Progress;
using Dafist.Engine.Tools;

namespace Dafist.Engine.Get.Load
{
    class LoadDirector
    {
        private readonly Loader loader;
        private readonly UpdatesBuffer buffer;
        private readonly ProgressMeter progress;
        private readonly Sleeper sleeper;
        private readonly EngineSettings settings;
        private readonly ILog log;
        public LoadDirector(Loader loader, UpdatesBuffer buffer, ProgressMeter progress, EngineSettings settings, ILog log)
        {
            this.settings = settings;
            this.loader = loader;
            this.progress = progress;
            this.buffer = buffer;
            this.log = log;
            this.sleeper = new Sleeper();
        }

        public void Start()
        {
        }

        public void Stop()
        {
            sleeper.Stop();
        }

        public bool Load()
        {
            log.Debug("");
            log.Debug("Load updates");

            progress.GetState = GetState.BufferFull;
            var stopState = buffer.WaitForRoom();
            if (stopState.Stopped)
            {
                return false;
            }

            progress.GetState = GetState.Busy;

            var updates = loader.Load();

            if (updates.Any())
            {
                progress.GetDone(updates.Count());
                buffer.Put(updates);
            }
            else
            {
                progress.GetState = GetState.Free;
                sleeper.Sleep(settings.LoadIdleSleepTime, "loadIdle");
            }
            
            return true;
        }
    }
}
