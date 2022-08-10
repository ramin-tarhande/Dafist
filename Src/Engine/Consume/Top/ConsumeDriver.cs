using log4net;
using Dafist.Engine.Tools;

namespace Dafist.Engine.Consume.Top
{
    class ConsumeDriver : ConsumingManager
    {
        private readonly ThreadRunner threadRunner;
        private readonly ConsumeDirector consumeDirector;
        public ConsumeDriver(ConsumeDirector consumeDirector, QuitApp quitApp, ILog log)
        {
            this.consumeDirector = consumeDirector;

            threadRunner = new ThreadRunner(
                consumeDirector.Consume, "consume", quitApp, log);
        }

        public void Start()
        {
            consumeDirector.Start();

            threadRunner.Start();
        }

        public void Stop()
        {
            consumeDirector.Stop(); 

            threadRunner.Stop(); //swap order 98/12/11

            consumeDirector.Dispose(); //release resources
        }
    }
}
