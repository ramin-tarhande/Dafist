using TDCS.General;
using TDCS.General.Tools;
using Dafist.Engine.Buffers;

namespace Dafist.Engine.Progress
{
    public class ProgressMeter : SyncProgress
    {
        private readonly Counter getsCounter, consumesCounter, failuresCounter, invalidsCounter;
        private readonly UpdatesBuffer buffer;
        internal ProgressMeter(UpdatesBuffer buffer, EngineSettings settings)
        {
            this.buffer = buffer;

            getsCounter=Counter.CreateWrapping(settings.CountWrapping);
            consumesCounter = Counter.CreateWrapping(settings.CountWrapping);
            failuresCounter=Counter.CreateSimple();
            invalidsCounter = Counter.CreateSimple();

            GetState = GetState.Free;
            ConsumeState = ConsumeState.Free;
        }

        public int BufferSize
        {
            get
            {
                return buffer.Size();
            }
        }

        public GetState GetState { get; set; }
        public ConsumeState ConsumeState { get; set; }

        public int Gets
        {
            get
            {
                return (int)getsCounter.Value;
            }
        }

        public int Consumes
        {
            get
            {
                return (int)consumesCounter.Value;
            }
        }

        public int Failures
        {
            get
            {
                return (int)failuresCounter.Value;
            }
        }

        public int Invalids
        {
            get
            {
                return (int)invalidsCounter.Value;
            }
        }

        public void GetDone(int count)
        {
            if (count==0)
            {
                return;
            }

            getsCounter.Add(count);
        }

        public void ConsumeDone()
        {
            consumesCounter.AddOne();
        }

        readonly object invalidSyncObj=new object();
        public void InvalidData()
        {
            lock (invalidSyncObj)
            {
                invalidsCounter.AddOne();    
            }
            
        }

        readonly object failedSyncObj = new object();
        public void Failed()
        {
            lock (failedSyncObj)
            {
                failuresCounter.AddOne();    
            }
        }
    }
}
