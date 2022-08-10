using System;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    public class IgnorantSee : SchemaErrorExpert
    {
        public bool IsSchemaError(Exception x)
        {
            return false;
        }
    }
}
