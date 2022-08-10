using log4net;
using Dafist.Engine.Get.Load;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Schemas.Top;
using Dafist.MsSqlAdp.Get;
using Dafist.MsSqlAdp.SchemaErrors;
using Dafist.SqlCommon.Basics;

namespace Dafist.MsSqlAdp.ObjectFactories
{
    public class MsLoadObjectsFactory : LoadObjectsFactory
    {
        private readonly Schema schema;
        private readonly MsSourceSqlSettings settings;
        private readonly ILog log;
        private readonly RobustDaBasicsFactory robustDaBasicsFactory;
        public MsLoadObjectsFactory(Schema schema, MsSourceSqlSettings settings, ILog log)
        {
            this.schema = schema;
            this.settings = settings;
            this.log = log;
            robustDaBasicsFactory=new MsRobustDaBasicsFactory(settings,log);
        }

        public ProblemTypeExpert CreateProblemTypeExpert()
        {
            return new FixedNonSchemaPte(
                schemaErrorExpert:  new MsSee(log), 
                nonSchemaPt: ProblemType.RetriableFailure);
        }

        public Loader CreateLoader(SafeExecuter safeExecuter)
        {
            var daBasics = robustDaBasicsFactory.Create(settings.SourceConnectionString, safeExecuter);

            var changeTrackingDao = new ChangeTrackingDao(daBasics);
            var versionRangeExpert = new VersionRangeExpert(changeTrackingDao, settings, log);

            var loader = new MsLoader(changeTrackingDao, versionRangeExpert, schema, log);

            return loader;
        }
    }
}
