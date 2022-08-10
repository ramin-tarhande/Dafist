using Dafist.SqlCommon;

namespace Dafist.MsSqlAdp
{
    public interface MsSourceSqlSettings : SourceSqlSettings
    {
        int LoadMaxVersionDiff { get; set; }
    }
}