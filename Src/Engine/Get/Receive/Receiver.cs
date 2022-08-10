using System;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Get.Receive
{
    public interface Receiver
    {
        void Start();
        void Stop();
        event Action<SourceUpdate> Received;
    }
}