using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using SimpleTypes;
using SyncApp4.SchemaDef;
using TDCS.Logging;
using TDCS.Yaml;
using Dafist.Engine;
using Dafist.Engine.Composing;
using Dafist.Engine.Composing.ConsumePart;
using Dafist.Engine.Composing.GetPart;
using Dafist.Engine.Composing.Root;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Schemas.Top;
using Dafist.MessagingCommon;
using Dafist.MsSqlAdp.ObjectFactories;
using Dafist.RabbitAdp.ObjectFactories;
using Dafist.Ui;
using Dafist.Ui.Tools;

namespace SyncApp4.Run
{
    class AppStarter
    {
        const string appName = "SyncApp4";
        private Schema schema;
        private SyncApp4Settings settings;
        private ILog log;
        public Form Start()
        {
            return DfDebugFriendly.TryExecute(StartCore, log);
        }

        private Form StartCore()
        {
            settings = YamlObjectLoader.Load<SyncApp4Settings>(ConfigPaths.MainConfig());

            schema = SchemaFactory.Create();
            
            log = LogStarter.Start(ConfigPaths.LogConfig(), "Main");

            ErrorHandler.Start(log);

            log.Debug("Start application");

            var backColor = Color.FromArgb(170, 80, 120);

            var mainForm = new MainForm(appName, settings, backColor);
            QuitApp quitApp = msg => mainForm.Quit(msg);


            var engineComposer = CreateEngineComposer(quitApp);
            
            var engine = engineComposer.Compose();

            mainForm.Set(engine);

            mainForm.Load += (x, y) =>mainForm.Left += 200;

            return mainForm;
        }

        EngineComposer CreateEngineComposer(QuitApp quitApp)
        {
            var simpleDependecies = new SimpleDepencies(quitApp, settings, log);

            var messageConverter = new GeneralObjectConverter<AttendanceLog>(schema,"EmpAtd");
            var receiveObjectsFactory = new RbReceiveObjectsFactory<AttendanceLog>(messageConverter, appName, settings);

            //
            var consumeObjectsFactories = new List<ConsumeObjectsFactory>
            {
                new MsConsumeObjectsFactory(settings, log, consumerId: 1)
            };

            var engineComposer = new EngineComposer(simpleDependecies,schema,
                new Receive_GetPartComposer(receiveObjectsFactory),
                new DefaultConsumePartComposer(consumeObjectsFactories));

            return engineComposer;
        }
    }
} 
