using Dafist.Engine.FieldsData;
using Dafist.Engine.Schemas.Top;
using Dafist.Engine.Updates;
using Dafist.Shared;
using Dafist.Shared.Tools;

namespace Dafist.MessagingCommon
{
    public class GeneralObjectConverter<T> : MessageConverter<T>
    {
        const UpdateType updateType= UpdateType.Created;

        private readonly Schema schema;
        private readonly string sourceEntityName;
        public GeneralObjectConverter(Schema schema,string sourceEntityName)
        {
            this.sourceEntityName = sourceEntityName;
            this.schema = schema;
        }

        public SourceUpdate Convert(T obj)
        {
            var sourceEntity = schema.SourceEntity(sourceEntityName);
            if (sourceEntity==null)
            {
                return null;
            }

            var dataDic = obj.AsDictionary().ToFieldDataDictionary();
            
            var data = new SourceFieldDataSet(FieldsInclusiveness.All, dataDic);

            var update = new SourceUpdate(updateType, sourceEntity, data);

            return update;
        }
    }
}
