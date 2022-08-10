using System;
using Dafist.Engine;
using Dafist.MsSqlAdp;
using Dafist.RabbitAdp.Get;
using Dafist.Ui;

namespace SyncApp4
{
    class SyncApp4Settings:
        EngineSettings,
        RbReceiveSettings,
        MsTargetSqlSettings,
        UiSettings 
    {
        public int BufferSizeThreshold { get; set; }
        public TimeSpan LoadIdleSleepTime { get; set; }
        public TimeSpan FailureSleepTime { get; set; }
        public int CountWrapping { get; set; }
        public int? DbCommandTimeout_s { get; set; }
        public bool LogAffectedRows { get; set; }
        public string TargetConnectionString { get; set; }
        public bool UseTransactions { get; set; }
        public bool ConfirmExit { get; set; }
        public string RabbitMq_Host { get; set; }
        public string RabbitMq_Exchange { get; set; }
        public bool RabbitMq_AutoDeleteQueue { get; set; }
        public string RabbitMq_Topic { get; set; }

        public bool ConsumptionDelay { get; set; }
        public TimeSpan ConsumptionDelayTime { get; set; }
    }
}
