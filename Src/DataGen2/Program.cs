using System;
using System.Windows.Forms;

namespace DataGen2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            using (var sender=new Sender())
            {
                sender.Start();

                var form = new Form1(sender);
                form.Load += (x, y) => form.Left -= 200;
                
                Application.Run(form);    
            }
        }

        
    }
}
