using System.Drawing;
using System.Windows.Forms;
using log4net;
using SyncApp2.Authors;
using SyncApp2.SchemaDef;
using CsLoggingTools;
using CsYamlTools;
using Dafist.Engine;
using Dafist.Engine.Composing;
using Dafist.Engine.Composing.ConsumePart;
using Dafist.Engine.Composing.GetPart;
using Dafist.Engine.Composing.Root;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Schemas.Top;
using Dafist.MsSqlAdp.ObjectFactories;
using Dafist.RabbitAdp.ObjectFactories;
using Dafist.Ui;
using Dafist.Ui.Tools;
namespace SyncApp2.Run

{
    class AppStarter
    {
        private Schema schema;
        private SyncApp2Settings settings;
        private ILog log;
        public Form Start()
        {
            return DfDebugFriendly.TryExecute(StartCore, log);
        }

        private Form StartCore()
        {
            settings = YamlObjectLoader.Load<SyncApp2Settings>(ConfigPaths.MainConfig()); 

            schema = CreateSchema(settings);
            
            log = LogStarter.Start(ConfigPaths.LogConfig(), "Main");

            ErrorHandler.Start(log);

            log.Debug("Start application");

            var backColor = Color.FromArgb(150, 120, 120);

            const string appName = "SyncApp2";

            var mainForm = new MainForm(appName, settings, backColor);
            QuitApp quitApp = msg => mainForm.Quit(msg);

            var engineComposer = CreateEngineComposer(quitApp);
            
            var engine = engineComposer.Compose();

            mainForm.Set(engine);

            return mainForm;
        }

        static Schema CreateSchema(SyncApp2Settings settings)
        {
            var authorsDao = new AuthorsDao(settings.SourceConnectionString);

            var schemaFactory = new SchemaFactory(new MySourceSf(), new CommentSf(authorsDao));

            var schema = schemaFactory.Create();

            return schema;
        }

        EngineComposer CreateEngineComposer(QuitApp quitApp)
        {
            var simpleDependecies = new SimpleDepencies(quitApp, settings, log);

            var loadObjectsFactory = new MsLoadObjectsFactory(schema, settings, log);

            var mss1 = new MyMsTargetSqlSettings(settings.TargetConnectionString1, settings);
            var mss2 = new MyMsTargetSqlSettings(settings.TargetConnectionString2, settings);
            var consumeObjectsFactories = new ConsumeObjectsFactory[]
                        {
                            new MsConsumeObjectsFactory(mss1,log,ConsumerIds.Ms1),
                            new MsConsumeObjectsFactory(mss2,log,ConsumerIds.Ms2),
                            new RbConsumeObjectsFactory(settings,ConsumerIds.Rb)
                        };

            var engineComposer = new EngineComposer(simpleDependecies,schema,
                new Load_GetPartComposer(loadObjectsFactory),
                new DefaultConsumePartComposer(consumeObjectsFactories));

            return engineComposer;
        }
    }
} 
