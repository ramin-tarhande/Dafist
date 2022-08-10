using log4net;
using Dafist.Engine.Buffers;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Progress;
using Dafist.Engine.Schemas.Top;

namespace Dafist.Engine.Composing
{
    public class CommonObjects 
    {
        public static CommonObjects Initialize(SimpleDepencies simpleDependecies, Schema schema)
        {
            var x = new CommonObjects(schema);
            x.Init(simpleDependecies);
            return x;
        }
        public Schema Schema { get; private set; }
        public ProgressMeter Progress { get; private set; }
        public UpdatesBuffer Buffer { get; private set; }
        public QuitApp QuitApp { get; private set; }
        public EngineSettings Settings { get; private set; }
        public ILog Log { get; private set; }
        public SafeExecutersClub SafeExecutersClub { get; private set; }

        private CommonObjects(Schema schema)
        {
            this.Schema = schema;
        }

        private void Init(SimpleDepencies simpleDependecies)
        {
            QuitApp = simpleDependecies.QuitApp;
            Settings = simpleDependecies.Settings;
            Log = simpleDependecies.Log;

            //
            Buffer = new UpdatesBuffer(Settings, Log);
            Progress = new ProgressMeter(Buffer, Settings);
            SafeExecutersClub = new SafeExecutersClub();
        }
    }
}
