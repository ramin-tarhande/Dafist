using System.Collections.Generic;
using System.Linq;
using Dafist.Shared;

namespace Dafist.Engine.FieldsData
{
    public struct FieldData
    {
        public string Name { get; private set; }
        public object Value { get; private set; }
        public FieldData(string name, object value) : this()
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Text();
        }

        public string Text()
        {
            return string.Format("{0}={1}", Name, Value);
        }
    }

    public static class FieldDataExtension
    {
        public static SourceFieldDataSet ToSourceFieldDataSet(this IEnumerable<FieldData> fieldsData,
            FieldsInclusiveness fieldsInclusiveness)
        {
            return new SourceFieldDataSet(
                fieldsInclusiveness,
                fieldsData.ToDictionary());
        }

        public static TargetFieldDataSet ToTargetFieldDataSet(this IEnumerable<FieldData> fieldsData, 
            FieldsInclusiveness fieldsInclusiveness)
        {
            return new TargetFieldDataSet(
                fieldsInclusiveness,
                fieldsData.ToDictionary());
        }

        public static IDictionary<string, FieldData> ToDictionary(this IEnumerable<FieldData> fieldsData)
        {
            return fieldsData.ToDictionary(x => x.Name, x => x);
        }

    }
}
