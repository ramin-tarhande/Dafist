using System;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    public class SchemaErrorException : Exception
    {
        public SchemaErrorException(string message, Exception innerException=null) 
            : base(message, innerException)
        {
        }
    }
}
