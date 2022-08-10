using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Dafist.Engine.FieldsData;

namespace Dafist.SqlCommon.Consume
{
    public class FieldDataHelper
    {
        private readonly string paramPrefix;
        public FieldDataHelper(string paramPrefix)
        {
            this.paramPrefix = paramPrefix;
        }

        public string CreateWhere(FieldDataSet fieldDataSet)
        {
            var where = new StringBuilder();
            where.Append("WHERE ");

            var whereEquals = CreateSqlText(fieldDataSet,(fn, pv) => string.Format("{0}={1}", fn, pv), " and ");

            where.Append(whereEquals);

            return where.ToString();
        }

        public string CreateSqlText(FieldDataSet fieldDataSet, Func<string, string, string> map, string separator)
        {
            var equalsText = new List<string>();

            foreach (var fieldData in fieldDataSet)
            {
                var paramVariable = ParameterVariable(fieldData);

                var itemText = map(fieldData.Name, paramVariable);

                equalsText.Add(itemText);
            }

            var text = string.Join(separator, equalsText);

            return text;
        }

        public object CreateParams(FieldDataSet fieldDataSet)
        {
            var parameters = new DynamicParameters();
            foreach (var fd in fieldDataSet)
            {
                parameters.Add(ParameterVariable(fd), fd.Value);
            }

            return parameters;
        }

        public string ParameterVariable(FieldData fieldData)
        {
            return string.Format("{0}{1}",paramPrefix, fieldData.Name);
        }
    }
}
