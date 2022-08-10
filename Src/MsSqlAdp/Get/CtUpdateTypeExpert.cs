using System;
using System.Collections.Generic;
using Dafist.Shared;

namespace Dafist.MsSqlAdp.Get
{
    class CtUpdateTypeExpert
    {
        private readonly Dictionary<string, UpdateType> dic;

        public CtUpdateTypeExpert()
        {
            dic=new Dictionary<string, UpdateType>
            {
                {"I", UpdateType.Created},
                {"U", UpdateType.Modified},
                {"D", UpdateType.Deleted}
            };
        }

        public UpdateType GetFor(string operationType)
        {
            UpdateType updateType;
            var found=dic.TryGetValue(operationType, out updateType);
            if (!found)
            {
                throw new ArgumentException(
                    string.Format("unexpected sysChangeOperation:'{0}'", operationType), "operationType");
            }
            return updateType;
        }
    }
}
