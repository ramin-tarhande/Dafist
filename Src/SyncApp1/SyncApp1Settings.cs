using System;
using Dafist.Engine;
using Dafist.MsSqlAdp;
using Dafist.Ui;

namespace SyncApp1
{
    class SyncApp1Settings:
        EngineSettings,
        MsSourceSqlSettings, 
        MsTargetSqlSettings,
        UiSettings 
    {
        public int BufferSizeThreshold { get; set; }

        public TimeSpan LoadIdleSleepTime { get; set; }
        public TimeSpan FailureSleepTime { get; set; }
        public int CountWrapping { get; set; }
        
        public int? DbCommandTimeout_s { get; set; }
        public bool LogAffectedRows { get; set; }
        public string SourceConnectionString { get; set; }
        public string TargetConnectionString { get; set; }
        public int LoadMaxVersionDiff { get; set; }
        public bool UseTransactions { get; set; }

        public string RabbitMq_Host { get; set; }
        public string RabbitMq_Exchange { get; set; }
        public bool ConfirmExit { get; set; }
    }
}
