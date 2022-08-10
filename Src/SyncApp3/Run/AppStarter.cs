using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using SyncApp3.SchemaDef;
using TDCS.Logging;
using TDCS.Yaml;
using Dafist.Engine;
using Dafist.Engine.Composing;
using Dafist.Engine.Composing.ConsumePart;
using Dafist.Engine.Composing.GetPart;
using Dafist.Engine.Composing.Root;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Schemas;
using Dafist.Engine.Schemas.Top;
using Dafist.MessagingCommon;
using Dafist.MsSqlAdp.ObjectFactories;
using Dafist.RabbitAdp;
using Dafist.RabbitAdp.ObjectFactories;
using Dafist.Shared.Messages;
using Dafist.Ui;
using Dafist.Ui.Tools;

namespace SyncApp3.Run
{
    class AppStarter
    {
        const string appName = "SyncApp3";
        private Schema schema;
        private SyncApp3Settings settings;
        private ILog log;
        public Form Start()
        {
            return DebugFriendly.TryExecute(StartCore, log);
        }

        private Form StartCore()
        {
            settings = YamlObjectLoader.Load<SyncApp3Settings>(ConfigPaths.MainConfig());

            schema = SchemaFactory.Create();
            
            log = LogStarter.Start(ConfigPaths.LogConfig(), "Main");

            ErrorHandler.Start(log);

            log.Debug("Start application");

            var backColor = Color.FromArgb(130, 140, 170);

            var mainForm = new MainForm(appName, settings, backColor);
            QuitApp quitApp = msg => mainForm.Quit(msg);


            var engineComposer = CreateEngineComposer(quitApp);
            
            var engine = engineComposer.Compose();

            mainForm.Set(engine);

            mainForm.Load += (x, y) =>mainForm.Left += 350;

            return mainForm;
        }

        EngineComposer CreateEngineComposer(QuitApp quitApp)
        {
            var simpleDependecies = new SimpleDepencies(quitApp, settings, log);

            var messageConverter = new UpdateMessageCoverter(schema);
            var receiveObjectsFactory = new RbReceiveObjectsFactory<UpdateMessage>(messageConverter, appName, settings);

            //
            var consumeObjectsFactories = new List<ConsumeObjectsFactory>
            {
                new MsConsumeObjectsFactory(settings, log, consumerId: 1)
            };

            if (settings.ConsumptionDelay)
            {
                consumeObjectsFactories.Add(
                  new SimpleConsumeObjectsFactory(new DelayerConsumer(settings.ConsumptionDelayTime, consumerId: 2,log)));
            }

            var engineComposer = new EngineComposer(simpleDependecies,schema,
                new Receive_GetPartComposer(receiveObjectsFactory),
                new DefaultConsumePartComposer(consumeObjectsFactories));

            return engineComposer;
        }
    }
} 
