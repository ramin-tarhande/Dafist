namespace Dafist.SqlCommon
{
    public interface SourceSqlSettings : CommonSqlSettings
    {
        string SourceConnectionString { get; set; }
    }
}