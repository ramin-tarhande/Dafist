namespace Dafist.SqlCommon
{
    public interface CommonSqlSettings
    {
        int? DbCommandTimeout_s { get; set; }
        bool LogAffectedRows { get; set; }
    }
}