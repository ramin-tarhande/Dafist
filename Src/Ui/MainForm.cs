using System;
using System.Drawing;
using Dafist.Engine.Facade;

namespace Dafist.Ui
{
    public partial class MainForm : MainFormBase
    {
        private readonly MainUc uc;
        private readonly string appName;

        public MainForm(string appName, UiSettings settings, Color? backColor)
            : this(appName, settings, new MainUc(backColor))
        {
        }

        public MainForm(string appName, UiSettings settings, MainUc uc)
            : base(appName, settings)
        {
            this.uc = uc;
            this.appName = appName;

            InitializeComponent();

            this.Load += MainUc_Load;
            this.Closed += MainForm_Closed;
            this.ClientSize = uc.Size;
            this.Controls.Add(uc);
        }

        public void Set(EngineFacade engine)
        {
            uc.Set(engine);
        }

        void MainUc_Load(object sender, EventArgs e)
        {
            //this.Text = appName + " [Dafist]";
            this.Text = appName;

            uc.Start();
        }
        
        void MainForm_Closed(object sender, EventArgs e)
        {
            uc.Stop();
        }
    }
}
