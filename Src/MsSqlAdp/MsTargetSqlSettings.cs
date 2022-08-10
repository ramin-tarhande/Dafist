using Dafist.SqlCommon;

namespace Dafist.MsSqlAdp
{
    public interface MsTargetSqlSettings : TargetSqlSettings
    {
        /// <summary>
        /// set to true if others may write to target tables 
        /// otherwise set to false because it has a performance penalty (~20%)
        /// </summary>
        bool UseTransactions { get; set; }

    }
}