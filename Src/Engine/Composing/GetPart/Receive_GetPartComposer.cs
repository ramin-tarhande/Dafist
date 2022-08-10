using Dafist.Engine.Get;
using Dafist.Engine.Get.Receive;
using Dafist.Engine.ObjectFactories;

namespace Dafist.Engine.Composing.GetPart
{
    public class Receive_GetPartComposer : GetPartComposer
    {
        private readonly ReceiveObjectsFactory receiveObjectsFactory;
        public Receive_GetPartComposer(ReceiveObjectsFactory receiveObjectsFactory)
        {
            this.receiveObjectsFactory = receiveObjectsFactory;
        }

        public GettingManager Compose(CommonObjects c)
        {
            var problemProcessor = GetProblemProcessorFactory.Create(receiveObjectsFactory, c);

            var receiver = receiveObjectsFactory.CreateReceiver(problemProcessor);

            var receiveDirector = new ReceiveDirector(receiver, c.Buffer, c.Progress, c.Log);

            return receiveDirector;
        }
    }
}
