using System;
using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Schemas.Source
{
    public class SourceEntity
    {
        private MappingFinder mappingFinder;

        public string Name { get; private set; }
        public IEnumerable<string> IdFields { get; private set; }
        private readonly HashSet<string> allFields;
        
        public SourceEntity(string name, IEnumerable<string> idFields, IEnumerable<string> ordinaryFields)
        {
            name.ValidateEntityName();
            //idFields.ValidateFieldNames();
            //ordinaryFields.ValidateFieldNames();

            Name = name;
            IdFields = idFields;
            //OrdinaryFields = ordinaryFields;
            allFields = idFields.Union(ordinaryFields).ToHashSet();
        }

        public IEnumerable<string> AllFields
        {
            get { return allFields; }
        }

        public bool HasField(string fieldName)
        {
            return allFields.Contains(fieldName);
        }

        public void SetMappings(MappingFinder mf)
        {
            if (mappingFinder!=null)
            {
                throw new InvalidOperationException("SetMappings should only be called once");
            }

            mappingFinder = mf;
        }

        public void SetFixedMapping(Mapping mapping)
        {
            SetMappings(
                new MappingFinder.Fixed(mapping));
        }

        internal Mapping GetMappingFor(ConsumerBasics consumer)
        {
            return mappingFinder.GetFor(consumer);
        }
    }
}
