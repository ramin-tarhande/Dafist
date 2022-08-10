using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using log4net;

namespace Dafist.Ui.Tools
{
    public class ErrorHandler
    {
        public static ErrorHandler Start(ILog log)
        {
            if (Debugger.IsAttached)
                return null;

            var x = new ErrorHandler(log);

            x.Initialize();

            return x;
        }

        private readonly ILog log;
        public ErrorHandler(ILog log)
        {
            this.log = log;
        }

        //from MSDN
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        void Initialize()
        {
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += Application_ThreadException;

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Handle(e.ExceptionObject);
        }

        void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Handle(e.Exception);
        }

        void Handle(object exception)
        {
            Exception x = exception as Exception;

            const string title = "Error in application";

            this.log.Fatal(title, x);

            string msg = title;
            if (x != null)
                msg = msg + ":\r\n" + x.Message;

            this.log.Info("");
            this.log.Info("Quitting the application");

            //this.errorShower.ShowQuitting(msg);
            QuitMessageShower.Show(msg);

            //Application.Exit();
            //Process.GetCurrentProcess().Kill();
            Environment.Exit(1);
        }
    }
}
