using System;
using log4net;
using Dafist.Engine.Consume;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.Problems;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Progress;
using Dafist.MsSqlAdp.Consume;
using Dafist.MsSqlAdp.SchemaErrors;
using Dafist.SqlCommon;
using Dafist.SqlCommon.Basics;
using Dafist.SqlCommon.Consume;

namespace Dafist.MsSqlAdp.ObjectFactories
{
    public class MsConsumeObjectsFactory : ConsumeObjectsFactory
    {
        private readonly MsTargetSqlSettings settings;
        private readonly ILog log;
        private readonly RobustDaBasicsFactory robustDaBasicsFactory;
        private readonly object consumerId;
        public MsConsumeObjectsFactory(MsTargetSqlSettings settings, ILog log, object consumerId)
        {
            this.consumerId = consumerId;
            this.settings = settings;
            this.log = log;
            robustDaBasicsFactory = new MsRobustDaBasicsFactory(settings, log);
        }

        public ProblemTypeExpert CreateProblemTypeExpert()
        {
            return new MsConsumePte(
                schemaErrorExpert: new MsSee(log));
        }

        public Consumer CreateConsumer(SafeExecuter safeExecuter, ProgressMeter progress)
        {
            Func<RobustDaBasics> createBasics = () => robustDaBasicsFactory.Create(
                settings.TargetConnectionString, safeExecuter);

            var transactionTextAdder = TransactionTextAdder.Create(settings);
            var fieldDataHelper=new FieldDataHelper("@");
            var upsertDao = new MsUpsertDao(createBasics(), transactionTextAdder, fieldDataHelper);
            var deleteDao = new DeleteDao(createBasics(), fieldDataHelper);
            var consumer = new SqlConsumer(upsertDao, deleteDao, progress,consumerId);

            return consumer;
        }

    }
}
