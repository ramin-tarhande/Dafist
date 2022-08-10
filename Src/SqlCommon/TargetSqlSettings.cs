namespace Dafist.SqlCommon
{
    public interface TargetSqlSettings : CommonSqlSettings
    {
        string TargetConnectionString { get; set; }
    }
}