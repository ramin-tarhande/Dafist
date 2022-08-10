using System;
using System.Collections.Generic;
using log4net;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Buffers
{
    public class UpdatesBuffer
    {
        public event Action RoomAvailable;

        private readonly BufferEvents events;
        private readonly Queue<SourceUpdate> queue;
        private readonly object syncObject;
        private readonly EngineSettings settings;
        //private readonly ILog log;
        public UpdatesBuffer(EngineSettings settings, ILog log)
        {
            syncObject = new object();
            this.settings = settings;
            queue = new Queue<SourceUpdate>(settings.BufferSizeThreshold);

            events=new BufferEvents(IsEmpty,IsFull, log);

            //this.log = log;
        }

        private bool IsEmpty() //no lock needed, called inside a lock
        {
            return queue.Count == 0;    
        }

        public bool IsFull()  //no lock needed, called inside a lock
        {
            return queue.Count >= settings.BufferSizeThreshold;
        }

        public int Size()
        {
            lock (syncObject)
            {
                return queue.Count;    
            }
        }

        public StopState WaitForRoom()
        {
            return events.WaitForRoom();
        }

        public StopState WaitForData()
        {
            return events.WaitForData();
        }

        internal void Put(IEnumerable<SourceUpdate> updates)
        {
            lock (syncObject)
            {
                //log.Debug("Put");

                foreach (var update in updates)
                {
                    queue.Enqueue(update);
                }

                //LogSize("Put");

                events.PutDone(updates);
            }
        }

        internal SourceUpdate Take()
        {
            //log.Debug("Take");

            var r = TakeCore();

            //LogSize("Take");

            FireRoomEvent();

            return r;
        }

        SourceUpdate TakeCore()
        {
            lock (syncObject)
            {
            
                if (IsEmpty())
                {
                    return null;
                }

                var r = queue.Dequeue();

                events.TakeDone();
                
                return r;
            }
        }

        void FireRoomEvent()
        {
            if (!IsFull())
            {
                if (RoomAvailable!=null)
                {
                    RoomAvailable();
                }
            }
        }

        /*
        void LogSize(string action)
        {
            log.DebugFormat("{0} -> buffer size={1}",action, queue.Count);
        }*/

        internal void Stop()
        {
            events.Stop();
        }
    }
}
