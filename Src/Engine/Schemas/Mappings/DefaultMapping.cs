using System.Collections.Generic;
using System.Linq;
using log4net;
using Dafist.Engine.FieldsData;
using Dafist.Engine.Schemas.Source;
using Dafist.Engine.Updates;
using Dafist.Shared;

namespace Dafist.Engine.Schemas.Mappings
{
    public class DefaultMapping : Mapping
    {
        public string TargetName { get; private set; }
        public IEnumerable<ActiveTargetField> AllFields { get; private set; }
        internal IEnumerable<ActiveTargetField> CorrelationFields { get; private set; }
        private readonly HashSet<string> correlationFieldNames;
        private readonly SourceEntity source;
        public DefaultMapping(string targetName, IEnumerable<ActiveTargetField> allFields,
              IEnumerable<ActiveTargetField> correlationFields, SourceEntity source)
        {
            this.source = source;
            TargetName = targetName;
            AllFields = allFields;

            CorrelationFields = correlationFields;
            correlationFieldNames = correlationFields.Select(x => x.FieldName).ToHashSet();
        }

        public TargetUpdate Map(SourceUpdate sourceUpdate, ILog log)
        {
            var sourceData = sourceUpdate.Data;
            TargetFieldDataSet correlationData;
            TargetFieldDataSet allData;

            if (sourceData.FieldsInclusiveness == FieldsInclusiveness.CorrelationOnly)
            {
                correlationData = CorrelationFields.Compute(sourceData, log);
                allData = correlationData;
            }
            else
            {
                allData = AllFields.Compute(sourceData, log);
                correlationData = ExtractCorrelationData(allData);
            }

            return new TargetUpdate(sourceUpdate.UpdateType, TargetName, correlationData, allData);
        }

        public void CheckCorrelationCompleteness()
        {
            AllFields.CheckCorrelationCompleteness(source.IdFields);
        }

        public TargetFieldDataSet ExtractCorrelationData(TargetFieldDataSet allData)
        {
            return allData.Where(x => correlationFieldNames.Contains(x.Name))
                            .ToTargetFieldDataSet(FieldsInclusiveness.CorrelationOnly);
        }

        /*
        TargetFieldDataSet ComputeData(SourceFieldDataSet sourceData, ILog log)
        {
            if (sourceData.FieldsInclusiveness == FieldsInclusiveness.CorrelationOnly)
            {
                return CorrelationFields.Compute(sourceData, log);
            }
            else
            {
                return AllFields.Compute(sourceData, log);
            }
        }

        public bool IsCorrelationField(string fieldName)
        {
            return correlationFieldNames.Contains(fieldName);
        }*/


    }
}
