using System.Collections.Generic;
using System.Linq;
using log4net;
using Dafist.Engine.FieldsData;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Schemas.Mappings
{
    static class TargetFieldExtensions
    {
        public static IEnumerable<ActiveTargetField> FindBasedOn(this IEnumerable<ActiveTargetField> targetFields,
            IEnumerable<string> sourceFieldNames)
        {
            return sourceFieldNames.Select(sfn => targetFields.FindBasedOn(sfn)).Where(f => f != null).ToList();
        }

        public static void CheckCorrelationCompleteness(this IEnumerable<ActiveTargetField> targetFields,
            IEnumerable<string> sourceIdFieldNames)
        {
            var notCorrelated = sourceIdFieldNames.FirstOrDefault(sfn => targetFields.FindBasedOn(sfn) == null);
            if (notCorrelated != null)
            {
                throw new SchemaErrorException(
                    string.Format("Target field based on source field: {0} not defined", notCorrelated));
            }
        }

        public static ActiveTargetField FindBasedOn(this IEnumerable<ActiveTargetField> targetFields,
            string sourceFieldName)
        {
            return targetFields.FirstOrDefault(tf => tf.IsBasedOn(sourceFieldName));
        }

        public static TargetFieldDataSet Compute(this IEnumerable<ActiveTargetField> targetFields,
            SourceFieldDataSet sourceData, ILog log)
        {
            return targetFields.Select(df => df.Compute(sourceData, log))
                              .ToTargetFieldDataSet(sourceData.FieldsInclusiveness);
        }
    }
}
