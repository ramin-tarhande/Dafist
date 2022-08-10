using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Schemas.Mappings
{
    public class TargetEntity
    {
        public string Name { get; private set; }
        public IEnumerable<TargetField> Fields { get; private set; }
        public TargetEntity(string name, IEnumerable<TargetField> fields)
        {
            //name.ValidateEntityName();
            fields.ValidateNonEmpty();

            Name = name;
            Fields = fields;
        }

        public TargetEntity(IEnumerable<TargetField> fields)
            : this(null, fields)
        {
        }

        internal IEnumerable<ActiveTargetField> ActiveFields()
        {
            return Fields.OfType<ActiveTargetField>().ToList();
        }
    }
}
