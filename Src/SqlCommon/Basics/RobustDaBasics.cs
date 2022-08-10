using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.SqlCommon.Basics
{
    public class RobustDaBasics
    {
        private readonly BasicDaOperations inner;
        private readonly SafeExecuter safeExecuter;
        public RobustDaBasics(BasicDaOperations inner, SafeExecuter safeExecuter)
        {
            this.inner = inner;
            this.safeExecuter = safeExecuter;
        }

        public bool Execute(Sql sql, string operationName)
        {
            var r=safeExecuter.Execute(
                () => inner.Execute(sql), operationName);

            return r;
        }

        public IEnumerable<T> Query<T>(Sql sql, string operationName)
        {
            IEnumerable<T> data=Enumerable.Empty<T>();

            var r=safeExecuter.Execute(
                () => data = inner.Query<T>(sql), operationName);

            return data;
        }
    }
}
