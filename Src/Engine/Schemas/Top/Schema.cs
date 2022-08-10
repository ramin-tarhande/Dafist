using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.Schemas.Source;

namespace Dafist.Engine.Schemas.Top
{
    public class Schema
    {
        public IEnumerable<SourceEntity> SourceEntities { get; private set; }

        private readonly IDictionary<string, SourceEntity> dic;
        public Schema(IEnumerable<SourceEntity> sourceEntities)
        {
            SourceEntities = sourceEntities;
            dic = sourceEntities.ToDictionary(x => x.Name, x => x);
        }

        public SourceEntity SourceEntity(string entityName)
        {
            SourceEntity def;
            dic.TryGetValue(entityName, out def);
            return def;
        }
    }
}
