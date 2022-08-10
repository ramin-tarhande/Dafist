using System;
using System.Threading;
using log4net;

namespace Dafist.Engine.Tools
{
    class ThreadRunner
    {
        readonly Thread thread;
        volatile bool stop, threadStopped;
        private readonly QuitApp quitApp;
        private readonly ILog log;
        private readonly Func<bool> doOnePassStuff;
        private readonly string taskName;
        public ThreadRunner(Func<bool> doOnePassStuff, string taskName, QuitApp quitApp, ILog log)
        {
            this.doOnePassStuff = doOnePassStuff;
            this.quitApp = quitApp;
            this.log = log;
            this.taskName = taskName;
            stop = false;
            thread = new Thread(ThreadMethod);
            thread.Name = taskName;
        }

        public void Start()
        {
            thread.Start();
        }

        void ThreadMethod()
        {
            try
            {
                Execute();
            }
            catch (ThreadAbortException)
            {
                //fine!
                threadStopped = true;
            }
            catch (Exception x)
            {
                //log.Info("\n---------------------------------");
                log.ErrorFormat("\nerror in {0}", taskName);
                //log.Info("this should not happen!");
                log.Error(null, x);
                log.InfoFormat("{0} stopped", taskName);

                threadStopped = true;
                quitApp(x.Message);
            }
        }

        void Execute()
        {
            var goOn = true;
            while (!stop && goOn)
            {
                goOn = doOnePassStuff();
            }
        }

        public void Stop()
        {
            if (threadStopped)
            {
                return;
            }

            log.InfoFormat("stopping {0}", taskName);
            
            stop = true;

            thread.Join();
            threadStopped = true;
            
        }

    }
}
