using log4net;
using Dafist.Engine.Resilience.SafeExecution;
using Dafist.Engine.Schemas;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Consume.Map
{
    class ConsumeMapper
    {
        private readonly SafeExecuter safeExecuter;
        private readonly ILog log;
        public ConsumeMapper(SafeExecuter safeExecuter, ILog log)
        {
            this.safeExecuter = safeExecuter;
            this.log = log;
        }

        public TargetUpdate Map(SourceUpdate sourceUpdate, Mapping mapping)
        {
            TargetUpdate ds = null;

            safeExecuter.Execute(
                () => ds = mapping.Map(sourceUpdate, log), "Map");

            return ds;
        }
    }
}
