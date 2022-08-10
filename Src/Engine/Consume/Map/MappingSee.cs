using System;
using log4net;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.Engine.Consume.Map
{
    class MappingSee : ActiveSee
    {
        public MappingSee(ILog log) : base(log)
        {
        }

        protected override bool IsSchemaErrorCore(Exception x)
        {
            return x.IsInternalSchemaError();
        }
    }
}
