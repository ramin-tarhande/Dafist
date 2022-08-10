using Dafist.Engine.FieldsData;
using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Updates;
using Dafist.Shared;

namespace Dafist.MsSqlAdp.Updates
{
    class MsSourceUpdate : SourceUpdate
    {
        public Version Version { get; private set; }
        public MsSourceUpdate(UpdateType type, SourceEntity entity, SourceFieldDataSet data, Version version) 
            : base(type, entity, data)
        {
            Version = version;
        }
    }
}
