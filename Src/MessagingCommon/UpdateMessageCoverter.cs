using Dafist.Engine.FieldsData;
using Dafist.Engine.Schemas.Top;
using Dafist.Engine.Updates;
using Dafist.Shared.Messages;

namespace Dafist.MessagingCommon
{
    public class UpdateMessageCoverter : MessageConverter<UpdateMessage>
    {
        private readonly Schema schema;
        public UpdateMessageCoverter(Schema schema)
        {
            this.schema = schema;
        }

        public SourceUpdate Convert(UpdateMessage msg)
        {
            var def=schema.SourceEntity(msg.EntityType);
            if (def==null)
            {
                return null;
            }

            var dataDic = msg.Data.ToFieldDataDictionary();
            var data = new SourceFieldDataSet(msg.FieldsInclusiveness, dataDic);
            var update=new SourceUpdate(msg.UpdateType,def,data);
            return update;
        }
    }
}
