using Dafist.MsSqlAdp;

namespace SyncApp2
{
    class MyMsTargetSqlSettings : MsTargetSqlSettings
    {
        public int? DbCommandTimeout_s { get; set; }
        public string TargetConnectionString { get; set; }
        public bool UseTransactions { get; set; }
        public bool LogAffectedRows { get; set; }

        public MyMsTargetSqlSettings(string targetConnectionString,SyncApp2Settings appSettings)
        {
            DbCommandTimeout_s = appSettings.DbCommandTimeout_s;

            LogAffectedRows = appSettings.LogAffectedRows;

            UseTransactions = appSettings.UseTransactions;
            TargetConnectionString = targetConnectionString;
        }
    }
}
