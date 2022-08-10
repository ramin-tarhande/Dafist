using System;

namespace Dafist.Engine.Resilience.Problems
{
    public struct Problem
    {
        public Exception Exception { get; private set; }
        public Problem(Exception exception) : this()
        {
            Exception = exception;
        }
    }
}
