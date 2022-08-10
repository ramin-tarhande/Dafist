using System;

namespace Dafist.Engine
{
    public interface EngineSettings
    {
        int BufferSizeThreshold { get; set; }

        TimeSpan LoadIdleSleepTime { get; set; }
        
        TimeSpan FailureSleepTime { get; set; }

        int CountWrapping { get; set; }
    }
}