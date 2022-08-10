using System;
using System.Windows.Forms;
using DataGen.Data;

namespace DataGen.Ui
{
    public partial class DataGenForm : Form
    {
        private readonly MyProgress progress;
        private readonly Generator g;
        private readonly DgSettings settings;
        internal DataGenForm(Generator g, MyProgress progress, DgSettings settings)
        {
            this.settings = settings;
            this.progress = progress;
            this.g = g;
            InitializeComponent();

            timer1.Tick += timer1_Tick;

        }

        async void timer1_Tick(object sender, EventArgs e)
        {
            await g.Insert(int.Parse(recordsFd.Text));
        }
        
        private async void insertBn_Click(object sender, EventArgs e)
        {
            await g.Insert(int.Parse(insertCountFd.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //entityCountFd.Text = settings.EntitiesCount().ToString();
            entityCountFd.Text = 2.ToString();
            this.Left -= 370;
            timer2.Start();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Interval = int.Parse(secondsFd.Text)*1000;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            writesFd.Text = progress.Writes.ToString();
        }

        private void entityCountFd_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
