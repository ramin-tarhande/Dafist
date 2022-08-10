using log4net;
using Dafist.Engine.Tools;

namespace Dafist.Engine.Get.Load
{
    class LoadDriver : GettingManager
    {
        private readonly LoadDirector loadDirector;
        private readonly ThreadRunner threadRunner;
        public LoadDriver(LoadDirector loadDirector, QuitApp quitApp, ILog log)
        {
            this.loadDirector = loadDirector;
            
            threadRunner = new ThreadRunner(
                loadDirector.Load, "load", quitApp, log);
        }

        public void Start()
        {
            loadDirector.Start();

            threadRunner.Start();
        }

        public void Stop()
        {
            loadDirector.Stop();

            threadRunner.Stop();
        }
    }
}
