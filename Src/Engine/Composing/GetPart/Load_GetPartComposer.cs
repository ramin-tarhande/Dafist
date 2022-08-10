using Dafist.Engine.Get;
using Dafist.Engine.Get.Load;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.Engine.Composing.GetPart
{
    public class Load_GetPartComposer : GetPartComposer
    {
        private readonly LoadObjectsFactory loadObjectsFactory;
        public Load_GetPartComposer(LoadObjectsFactory loadObjectsFactory)
        {
            this.loadObjectsFactory = loadObjectsFactory;
        }

        public GettingManager Compose(CommonObjects c)
        {
            var problemProcessor = GetProblemProcessorFactory.Create(loadObjectsFactory, c);

            var safeExecuter = new SafeExecuter(problemProcessor, c.SafeExecutersClub, c.Settings, c.Log);

            var loader = loadObjectsFactory.CreateLoader(safeExecuter);

            var loadDirector = new LoadDirector(loader, c.Buffer, c.Progress, c.Settings, c.Log);

            var loadDriver = new LoadDriver(loadDirector, c.QuitApp, c.Log);

            return loadDriver;
        }

        
    }
}
