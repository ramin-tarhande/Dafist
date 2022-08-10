using System.Collections.Generic;
using Dafist.Shared;

namespace Dafist.Engine.FieldsData
{
    public class TargetFieldDataSet : FieldDataSet
    {
        public TargetFieldDataSet(FieldsInclusiveness fieldsInclusiveness, IDictionary<string, FieldData> dic) 
            : base(fieldsInclusiveness,dic)
        {
        }
    }
}
