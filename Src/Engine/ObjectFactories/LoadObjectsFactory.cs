using Dafist.Engine.Get.Load;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.Engine.ObjectFactories
{
    public interface LoadObjectsFactory : GetObjectsFactory
    {
        Loader CreateLoader(SafeExecuter safeExecuter);
    }
}