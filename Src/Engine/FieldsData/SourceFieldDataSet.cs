using System;
using System.Collections.Generic;
using Dafist.Engine.Resilience.SchemaErrors;
using Dafist.Shared;

namespace Dafist.Engine.FieldsData
{
    public class SourceFieldDataSet : FieldDataSet, SourceFieldValues
    {
        
        public SourceFieldDataSet(FieldsInclusiveness fieldsInclusiveness,IDictionary<string, FieldData> dic)
            : base(fieldsInclusiveness, dic)
        {
        }

        public object this[string fieldName]
        {
            get
            {
                fieldName.ValidateFieldName();

                var dic = GetDictionary();
                try
                {
                    return dic[fieldName].Value;
                }
                catch (Exception x)
                {
                    throw new FieldNotFoundException(fieldName, x);
                }
            }
        }
    }
}
