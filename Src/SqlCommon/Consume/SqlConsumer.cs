using Dafist.Engine.Consume;
using Dafist.Engine.Progress;
using Dafist.Engine.Schemas;
using Dafist.Engine.Updates;
using Dafist.Shared;

namespace Dafist.SqlCommon.Consume
{
    public class SqlConsumer : Consumer
    {
        private readonly UpsertDao upsertDao;
        private readonly DeleteDao deleteDao;
        private readonly ProgressMeter progress;
        public SqlConsumer(UpsertDao upsertDao, DeleteDao deleteDao, ProgressMeter progress, object consumerId)
            : base(consumerId)
        {
            this.progress = progress;
            this.upsertDao = upsertDao;
            this.deleteDao = deleteDao;
        }

        public override void Check(Mapping mapping)
        {
            mapping.CheckCorrelationCompleteness();
        }

        public override void Start()
        {
        }

        public override bool Consume(TargetUpdate update)
        {
            bool r;

            if (update.UpdateType == UpdateType.Deleted)
            {
                r = deleteDao.Delete(update);
            }
            else
            {
                r = upsertDao.Upsert(update);
            }

            if (!r)
            {
                progress.InvalidData();
            }

            return r;
        }

        public override void Stop()
        {
        }

        public override void Dispose()
        {
        }
    }
}
