using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dafist.Shared;

namespace Dafist.Engine.FieldsData
{
    public abstract class FieldDataSet : IEnumerable<FieldData>
    {
        public FieldsInclusiveness FieldsInclusiveness { get; private set; }

        private readonly IDictionary<string, FieldData> dic;

        protected FieldDataSet(FieldsInclusiveness fieldsInclusiveness, IDictionary<string, FieldData> dic)
        {
            FieldsInclusiveness = fieldsInclusiveness;
            this.dic = dic;
        }

        public bool IsEmpy()
        {
            return dic.Count == 0;
        }

        protected IDictionary<string, FieldData> GetDictionary()
        {
            return dic;
        }

        public string Text()
        {
            return string.Join(", ",
                dic.Values.Select(fd => fd.Text()));
        }

        public IEnumerable<string> FieldNames()
        {
            return dic.Keys;
        }

        public IEnumerator<FieldData> GetEnumerator()
        {
            return dic.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(string fieldName)
        {
            return dic.ContainsKey(fieldName);
        }

    }
}
