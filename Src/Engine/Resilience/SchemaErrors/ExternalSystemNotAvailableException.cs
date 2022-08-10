using System;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    public class ExternalSystemNotAvailableException : Exception
    {
        public ExternalSystemNotAvailableException(string message, Exception innerException = null) 
            : base(message, innerException)
        {
        }

    }
}
