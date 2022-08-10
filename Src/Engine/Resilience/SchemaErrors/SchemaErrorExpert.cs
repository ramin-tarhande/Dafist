using System;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    public interface SchemaErrorExpert
    {
        bool IsSchemaError(Exception x);
    }
}