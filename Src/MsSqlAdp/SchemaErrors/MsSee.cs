using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using log4net;
using Dafist.Engine.Resilience.SchemaErrors;

namespace Dafist.MsSqlAdp.SchemaErrors
{
    class MsSee : ActiveSee
    {
        private readonly HashSet<int> schemaErrors;
        public MsSee(ILog log) : base(log)
        {
            schemaErrors = new HashSet<int>()
            {
                208, //invalid object
                207, //invalid column
                102, //incorrect syntax near...
                156, //incorrect syntax near the keyword...
                8102,//Cannot update identity column
            };
        }
        
        protected override bool IsSchemaErrorCore(Exception x)
        {
            if (x.IsInternalSchemaError())
            {
                return true;
            }

            var sx = x as SqlException;
            if (sx != null)
            {
                return IsSchemaError(sx);
            }

            return false;
        }

        bool IsSchemaError(SqlException sx)
        {
            return schemaErrors.Contains(sx.Number);
        }
    }
}
