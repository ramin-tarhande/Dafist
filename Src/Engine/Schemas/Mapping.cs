using log4net;
using Dafist.Engine.Updates;

namespace Dafist.Engine.Schemas
{
    public interface Mapping
    {
        void CheckCorrelationCompleteness();

        TargetUpdate Map(SourceUpdate sourceUpdate, ILog log);
    }
}
