using log4net;

namespace Dafist.Engine.Composing
{
    public class SimpleDepencies
    {
        public QuitApp QuitApp { get; private set; }
        public EngineSettings Settings { get; private set; }
        public ILog Log { get; private set; }
        public SimpleDepencies(QuitApp quitApp, EngineSettings settings, ILog log)
        {
            this.QuitApp = quitApp;
            this.Settings = settings;
            this.Log = log;
        }
    }
}
