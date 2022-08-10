using System.Collections.Generic;
using System.Linq;

namespace Dafist.Engine.FieldsData
{
    public static class IDictionaryExtensions
    {
        public static IDictionary<string, FieldData> ToFieldDataDictionary(this IDictionary<string, object> dictionary)
        {
            return dictionary.ToDictionary(p => p.Key, p => new FieldData(p.Key, p.Value));
        }

    }
}
