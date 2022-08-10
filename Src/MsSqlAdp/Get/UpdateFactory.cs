using System;
using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.FieldsData;
using Dafist.Engine.Schemas.Source;
using Dafist.MsSqlAdp.Updates;
using Dafist.Shared;
using Version = Dafist.MsSqlAdp.Updates.Version;

namespace Dafist.MsSqlAdp.Get
{
    class UpdateFactory
    {
        private readonly CtUpdateTypeExpert updateTypeExpert;
        public UpdateFactory()
        {
            updateTypeExpert=new CtUpdateTypeExpert();
        }

        public MsSourceUpdate Create(object pRowData, SourceEntity entity)
        {
            var rowData = (IDictionary<string, object>)pRowData;

            var version = FindVersion(rowData);

            var updateType=FindUpdateType(rowData);

            var sourceData = GetSourceData(entity, updateType, rowData);

            return new MsSourceUpdate(updateType, entity,sourceData, version);    
        }

        private static Version FindVersion(IDictionary<string, object> rowData)
        {
            var v = Convert.ToInt64(
                rowData[SpecialFieldNames.ChangeVersion]);

            return new Version(v);
        }

        private UpdateType FindUpdateType(IDictionary<string, object> rowData)
        {
            var operationType = Convert.ToString(
                rowData[SpecialFieldNames.ChangeOperation]);

            var updateType = updateTypeExpert.GetFor(operationType);

            return updateType;
        }

        private static SourceFieldDataSet GetSourceData(SourceEntity entity, UpdateType updateType, IDictionary<string, object> rowData)
        {
            if (updateType == UpdateType.Deleted)
            {
                return CreateIdFieldsData(rowData, entity);
            }
            else
            {
                return CreateAllFieldsData(rowData, entity);
            }
        }

        static SourceFieldDataSet CreateAllFieldsData(IDictionary<string, object> rowData, SourceEntity entity)
        {
            return entity.AllFields
                    .Select(fn => new FieldData(fn, rowData[fn]))
                    .ToSourceFieldDataSet(FieldsInclusiveness.All);
        }

        static SourceFieldDataSet CreateIdFieldsData(IDictionary<string, object> rowData, SourceEntity entity)
        {
            return entity.IdFields
                    .Select(fn => new FieldData(fn, rowData[PkPrefixer.Prefix(fn)]))
                    .ToSourceFieldDataSet(FieldsInclusiveness.CorrelationOnly);
        }

        /*
        static bool ContainsSourceTableData(IDictionary<string, object> rowData, SourceEntityDef entityDef)
        {
            var idValue = GetFieldValue(rowData, entityDef.IdFields.First());
            return idValue!= null;
        }

        static object GetFieldValue(IDictionary<string, object> rowData,string fieldName)
        {
            return rowData[fieldName];
        }*/
    }
}
