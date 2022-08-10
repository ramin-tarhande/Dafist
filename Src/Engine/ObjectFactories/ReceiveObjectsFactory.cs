using Dafist.Engine.Get.Receive;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.Engine.ObjectFactories
{
    public interface ReceiveObjectsFactory : GetObjectsFactory
    {
        Receiver CreateReceiver(ProblemProcessor problemProcessor);
    }
}
