using Dafist.Engine.Updates;

namespace Dafist.SqlCommon.Consume
{
    public interface UpsertDao
    {
        bool Upsert(TargetUpdate upsert);
    }
}