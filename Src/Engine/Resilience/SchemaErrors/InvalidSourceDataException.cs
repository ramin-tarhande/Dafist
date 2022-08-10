using System;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    /// <summary>
    /// throw to indicate invalide source data -> a data problem
    /// </summary>
    public class InvalidSourceDataException : Exception
    {
        public InvalidSourceDataException(string message, Exception innerException=null) 
            : base(message, innerException)
        {
        }

    }
}
