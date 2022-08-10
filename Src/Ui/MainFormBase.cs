using System.ComponentModel;
using System.Windows.Forms;

namespace Dafist.Ui
{
    public partial class MainFormBase : Form
    {
        private readonly string appName;
        private readonly UiSettings settings;
        public MainFormBase(string appName, UiSettings settings)
        {
            this.settings = settings;
            this.appName = appName;
            
            InitializeComponent();

            this.Closing += MainForm_Closing;
        }

        void MainForm_Closing(object sender, CancelEventArgs e)
        {
            if (quitting || !settings.ConfirmExit)
            {
                ShowStoppingState();
                e.Cancel = false;
                return;
            }

            var r = MessageBox.Show(this, string.Format("Stop {0}?", appName), appName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                ShowStoppingState();
            }
            else
            {
                e.Cancel = true;
            }
        }

        void ShowStoppingState()
        {
            Text = "Stopping...";
        }

        private bool quitting;
        public void Quit(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                quitting = true;

                QuitMessageShower.Show(message);

                Close();
            });
        }
    }
}
