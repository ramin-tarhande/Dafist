using Dafist.Engine.FieldsData;
using Dafist.Engine.Schemas.Source;
using Dafist.Shared;

namespace Dafist.Engine.Updates
{
    public class SourceUpdate
    {
        public UpdateType UpdateType { get; private set; }
        public SourceEntity Entity { get; private set; }
        public SourceFieldDataSet Data { get; private set; }
        public SourceUpdate(UpdateType updateType, SourceEntity entity, SourceFieldDataSet data)
        {
            UpdateType = updateType;
            Data = data;
            Entity = entity;
        }

        public string Text()
        {
            return string.Format("{0}:  {1}  ({2})", Entity.Name, Data.Text(), this.UpdateType);
        }
    }
}
