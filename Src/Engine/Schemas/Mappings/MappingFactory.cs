using System;
using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.Resilience.SchemaErrors;
using Dafist.Engine.Schemas.Source;

namespace Dafist.Engine.Schemas.Mappings
{
    public static class MappingFactory
    {
        public static Mapping CreateIdentical(SourceEntity source, string targetEntityName = null)
        {
            var targetFields = source.AllFields.Select(f => new Copy(f)).ToList();

            var target = new TargetEntity(targetEntityName, targetFields);

            return Create(source, target);
        }

        public static Mapping Create(SourceEntity source, TargetEntity target)
        {
            var activeTargetFields = target.ActiveFields();

            var targetName = target.Name ?? source.Name;

            targetName.ValidateEntityName();

            var correlationFields = activeTargetFields.FindBasedOn(source.IdFields);

            CheckDependencies(activeTargetFields, source);

            return new DefaultMapping(targetName, activeTargetFields, correlationFields,source);
        }

        static void CheckDependencies(IEnumerable<ActiveTargetField> activeTargetFields, SourceEntity source)
        {
            foreach (var targetField in activeTargetFields)
            {
                var sourceFieldName = targetField.SingleSourceFieldName;
                if (sourceFieldName != null)
                {
                    if (!source.HasField(sourceFieldName))
                    {
                        throw new Exception(string.Format("Source field '{0}' not defined in SourceEntity", sourceFieldName));
                    }
                }
            }
        }
    }
}
