using System.Collections.Generic;

namespace Dafist.Shared.Messages
{
    public class UpdateMessage
    {
        public string EntityType { get; set; }
        public UpdateType UpdateType { get; set; }
        public FieldsInclusiveness FieldsInclusiveness { get; set; }
        public IDictionary<string, object> Data { get; set; }
        public UpdateMessage(string entityTypeName, UpdateType updateType, FieldsInclusiveness fieldsInclusiveness,
            IDictionary<string, object> data)
        {
            EntityType = entityTypeName;
            UpdateType = updateType;
            FieldsInclusiveness = fieldsInclusiveness;
            Data = data;
        }
    }
}
