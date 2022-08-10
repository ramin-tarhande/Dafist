using System.Drawing;
using System.Windows.Forms;
using log4net;
using SyncApp1.SchemaDef;
using TDCS.Logging;
using TDCS.Yaml;
using Dafist.Engine;
using Dafist.Engine.Composing;
using Dafist.Engine.Composing.ConsumePart;
using Dafist.Engine.Composing.GetPart;
using Dafist.Engine.Composing.Root;
using Dafist.Engine.Schemas.Top;
using Dafist.MsSqlAdp.ObjectFactories;
using Dafist.Ui;
using Dafist.Ui.Tools;

namespace SyncApp1.Run
{
    class AppStarter
    {
        private Schema schema;
        private SyncApp1Settings settings;
        private ILog log;
        public Form Start()
        {
            return DfDebugFriendly.TryExecute(StartCore, log);
        }

        private Form StartCore()
        {
            settings = YamlObjectLoader.Load<SyncApp1Settings>(ConfigPaths.MainConfig());

            schema = SchemaFactory.Create();
            
            log = LogStarter.Start(ConfigPaths.LogConfig(), "Main");

            ErrorHandler.Start(log);

            log.Debug("Start application");

            var backColor = Color.FromArgb(100, 110, 130);

            const string appName = "SyncApp1";

            var mainForm = new MainForm(appName, settings, backColor);
            QuitApp quitApp = msg => mainForm.Quit(msg);

            var engineComposer= CreateEngineComposer(quitApp);

            var engine = engineComposer.Compose();

            mainForm.Set(engine);

            return mainForm;
        }

        EngineComposer CreateEngineComposer(QuitApp quitApp)
        {
            var simpleDependecies = new SimpleDepencies(quitApp, settings, log);

            var loadObjectsFactory = new MsLoadObjectsFactory(schema, settings, log);

            var consumeObjectsFactory = new MsConsumeObjectsFactory(settings, log, consumerId: 1);

            var engineComposer = new EngineComposer(simpleDependecies,schema,
                new Load_GetPartComposer(loadObjectsFactory),
                new DefaultConsumePartComposer(consumeObjectsFactory));

            return engineComposer;
        }
    }
} 
