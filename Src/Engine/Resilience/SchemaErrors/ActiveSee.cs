using System;
using log4net;

namespace Dafist.Engine.Resilience.SchemaErrors
{
    public abstract class ActiveSee : SchemaErrorExpert
    {
        private readonly ILog log;
        protected ActiveSee(ILog log)
        {
            this.log = log;
        }

        public bool IsSchemaError(Exception x)
        {
            var r = IsSchemaErrorCore(x);
            if (r)
            {
                log.FatalFormat("Exception is due to an error in Schema: {0}", x.Message);
            }

            return r;
        }

        protected abstract bool IsSchemaErrorCore(Exception x);
    }
}