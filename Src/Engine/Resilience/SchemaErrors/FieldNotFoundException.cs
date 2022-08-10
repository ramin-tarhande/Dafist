using System;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    class FieldNotFoundException : Exception
    {
        public string FieldName { get; private set; }
        public FieldNotFoundException(string fieldName, Exception innerException) 
            : base("Field not found",innerException)
        {
            FieldName = fieldName;
        }

        public FieldNotFoundException(string fieldName)
            : this(fieldName, null)
        {
        }
    }
}
