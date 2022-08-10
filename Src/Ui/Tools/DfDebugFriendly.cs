using System;
using log4net;
using TDCS.General;

namespace Dafist.Ui.Tools
{
    public static class DfDebugFriendly
    {
        public static T TryExecute<T>(Func<T> code, ILog log)
        {
            return TDCS.General.DebugFriendly.TryExecute(code, 
                exceptionHandler:x =>
                {
                    if (log != null)
                    {
                        log.Fatal(null, x);
                    }
                    QuitMessageShower.InitShow(x.FullText());
                });
        }
    }
}
