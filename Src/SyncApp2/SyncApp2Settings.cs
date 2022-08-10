using System;
using Dafist.Engine;
using Dafist.MsSqlAdp;
using Dafist.RabbitAdp;
using Dafist.Ui;

namespace SyncApp2
{
    class SyncApp2Settings : 
        EngineSettings, 
        MsSourceSqlSettings, 
        RbSettings, //MsTargetSqlSettings,
        UiSettings 
    {
        public int BufferSizeThreshold { get; set; }
        
        public TimeSpan LoadIdleSleepTime { get; set; }
        public TimeSpan FailureSleepTime { get; set; }
        public int CountWrapping { get; set; }
        public int? DbCommandTimeout_s { get; set; }
        public bool LogAffectedRows { get; set; }
        public string SourceConnectionString { get; set; }
        public int LoadMaxVersionDiff { get; set; }
        
        public bool UseTransactions { get; set; }
        public string RabbitMq_Host { get; set; }
        public string RabbitMq_Exchange { get; set; }
        public bool ConfirmExit { get; set; }

        public string TargetConnectionString1 { get; set; }
        public string TargetConnectionString2 { get; set; }
    }
}