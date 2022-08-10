using System;
using System.Windows.Forms;
using SimpleTypes;

namespace DataGen2
{
    public partial class Form1 : Form
    {
        private readonly Sender sender;
        internal Form1(Sender sender)
        {
            InitializeComponent();

            this.sender = sender;

            empIdTb.Text = "1";
        }

        private void sendBn_Click(object zsender, EventArgs e)
        {
            var empId=int.Parse(empIdTb.Text);

            var atdLog = new AttendanceLog
            {
                EmployeeId = empId, PunchTime = DateTime.Now
            };

            sender.Send(atdLog);
        }
    }
}
