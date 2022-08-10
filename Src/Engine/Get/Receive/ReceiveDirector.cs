using log4net;
using Dafist.Engine.Buffers;
using Dafist.Engine.Progress;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Get.Receive
{
    class ReceiveDirector : GettingManager 
    {
        private readonly Receiver receiver;
        private readonly UpdatesBuffer buffer;
        private readonly ProgressMeter progress;
        //private readonly ILog log;
        public ReceiveDirector(Receiver receiver, UpdatesBuffer buffer, ProgressMeter progress, ILog log)
        {
            this.receiver = receiver;
            this.buffer = buffer;
            this.progress = progress;
            //this.log = log;
        }

        public void Start()
        {
            receiver.Received += OnReceive;
            receiver.Start();
        }

        void OnReceive(SourceUpdate update)
        {
            //log.Debug(" wait");
            progress.GetState = GetState.BufferFull;
            var stopState = buffer.WaitForRoom();
            if (stopState.Stopped)
            {
                return;
            }

            //log.Debug(" getting");
            progress.GetState = GetState.Busy;

            progress.GetDone(1);
            buffer.Put(new []{update});

            progress.GetState = GetState.Free;
        }

        public void Stop()
        {
            receiver.Stop();
        }

    }
}
