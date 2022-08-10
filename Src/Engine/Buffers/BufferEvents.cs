using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using log4net;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Buffers
{
    class BufferEvents
    {
        private readonly Func<bool> isEmpty;
        private readonly Func<bool> isFull;
        private readonly ManualResetEvent data, room, stop;
        private readonly WaitHandle[] roomOrStop, dataOrStop;
        private readonly ILog log;
        public BufferEvents(Func<bool> isEmpty, Func<bool> isFull, ILog log)
        {
            this.log = log;
            this.isEmpty = isEmpty;
            this.isFull = isFull;
            data = new ManualResetEvent(false);
            room = new ManualResetEvent(true);
            stop = new ManualResetEvent(false);
            roomOrStop = new WaitHandle[] { room, stop };
            dataOrStop = new WaitHandle[] { data, stop };
            
        }

        public StopState WaitForRoom()
        {
            var r = WaitHandle.WaitAny(roomOrStop);

            return new StopState(r == 1);
        }

        public StopState WaitForData()
        {
            var r = WaitHandle.WaitAny(dataOrStop);

            return new StopState(r == 1);
        }

        internal void PutDone(IEnumerable<SourceUpdate> updates)
        {
            if (updates.Any())
            {
                data.Set();
            }

            if (isFull())
            {
                log.Debug("buffer is full");
                room.Reset();
            }
        }

        internal void TakeDone()
        {
            if (isEmpty())
            {
                log.Debug("buffer is empty");
                data.Reset();
            }

            if (!isFull())
            {
                room.Set();
            }
        }

        internal void Stop()
        {
            stop.Set();
        }
    }
}
