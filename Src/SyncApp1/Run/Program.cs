using System;
using System.Windows.Forms;

namespace SyncApp1.Run
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Intro();

            var mainForm = new AppStarter().Start();

            if (mainForm != null)
            {
                Application.Run(mainForm);
            }

        }

        private static void Intro()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException); //required here!
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
