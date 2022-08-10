using System;
using System.Drawing;
using System.Windows.Forms;
using Dafist.Engine;
using Dafist.Engine.Facade;

namespace Dafist.Ui
{
    public partial class MainUc : UserControl
    {
        private EngineFacade engine;
        private SyncProgress progress;
        private readonly Color? backColor;
        public MainUc(Color? backColor)
        {
            this.backColor = backColor;
            
            InitializeComponent();

            timer1.Tick += timer1_Tick;
        }

        public void Set(EngineFacade pEngine)
        {
            this.engine = pEngine;
            this.progress = engine.Progress;
        }

        public void Start()
        {
            if (backColor.HasValue)
            {
                this.BackColor = backColor.Value;
            }

            engine.Start();

            timer1.Start();
        }

        public void Stop()
        {
            engine.Stop();
        }
        
        void timer1_Tick(object sender, EventArgs e)
        {
            getFd.Text = progress.Gets.ToString();
            consumesFd.Text = progress.Consumes.ToString();
            failuresFd.Text = progress.Failures.ToString();
            bufferFd.Text = progress.BufferSize.ToString();
            getStateFd.Text=progress.GetState.ToString();
            consumeStateFd.Text = progress.ConsumeState.ToString();
            invalidsFd.Text = progress.Invalids.ToString();
        }
    }
}
