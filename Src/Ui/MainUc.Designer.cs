namespace Dafist.Ui
{
    partial class MainUc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUc));
            this.getFd = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bufferFd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.consumesFd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.failuresFd = new System.Windows.Forms.TextBox();
            this.getStateFd = new System.Windows.Forms.Label();
            this.consumeStateFd = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.invalidsFd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getFd
            // 
            this.getFd.Location = new System.Drawing.Point(62, 21);
            this.getFd.Name = "getFd";
            this.getFd.ReadOnly = true;
            this.getFd.Size = new System.Drawing.Size(55, 20);
            this.getFd.TabIndex = 3;
            this.getFd.TabStop = false;
            this.getFd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Get:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Buffer:";
            // 
            // bufferFd
            // 
            this.bufferFd.Location = new System.Drawing.Point(62, 55);
            this.bufferFd.Name = "bufferFd";
            this.bufferFd.ReadOnly = true;
            this.bufferFd.Size = new System.Drawing.Size(55, 20);
            this.bufferFd.TabIndex = 5;
            this.bufferFd.TabStop = false;
            this.bufferFd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Consume:";
            // 
            // consumesFd
            // 
            this.consumesFd.Location = new System.Drawing.Point(62, 89);
            this.consumesFd.Name = "consumesFd";
            this.consumesFd.ReadOnly = true;
            this.consumesFd.Size = new System.Drawing.Size(55, 20);
            this.consumesFd.TabIndex = 7;
            this.consumesFd.TabStop = false;
            this.consumesFd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(192, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Failures:";
            // 
            // failuresFd
            // 
            this.failuresFd.Location = new System.Drawing.Point(242, 21);
            this.failuresFd.Name = "failuresFd";
            this.failuresFd.ReadOnly = true;
            this.failuresFd.Size = new System.Drawing.Size(35, 20);
            this.failuresFd.TabIndex = 9;
            this.failuresFd.TabStop = false;
            this.failuresFd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // getStateFd
            // 
            this.getStateFd.AutoSize = true;
            this.getStateFd.ForeColor = System.Drawing.Color.White;
            this.getStateFd.Location = new System.Drawing.Point(122, 24);
            this.getStateFd.Name = "getStateFd";
            this.getStateFd.Size = new System.Drawing.Size(56, 14);
            this.getStateFd.TabIndex = 11;
            this.getStateFd.Text = "get state";
            // 
            // consumeStateFd
            // 
            this.consumeStateFd.AutoSize = true;
            this.consumeStateFd.ForeColor = System.Drawing.Color.White;
            this.consumeStateFd.Location = new System.Drawing.Point(122, 92);
            this.consumeStateFd.Name = "consumeStateFd";
            this.consumeStateFd.Size = new System.Drawing.Size(63, 14);
            this.consumeStateFd.TabIndex = 12;
            this.consumeStateFd.Text = "consume st";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(194, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Invalids:";
            // 
            // invalidsFd
            // 
            this.invalidsFd.Location = new System.Drawing.Point(243, 89);
            this.invalidsFd.Name = "invalidsFd";
            this.invalidsFd.ReadOnly = true;
            this.invalidsFd.Size = new System.Drawing.Size(35, 20);
            this.invalidsFd.TabIndex = 13;
            this.invalidsFd.TabStop = false;
            this.invalidsFd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MainUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(291, 134);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.invalidsFd);
            this.Controls.Add(this.consumeStateFd);
            this.Controls.Add(this.getStateFd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.failuresFd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.consumesFd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bufferFd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getFd);
            this.Name = "MainUc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox getFd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bufferFd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox consumesFd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox failuresFd;
        private System.Windows.Forms.Label getStateFd;
        private System.Windows.Forms.Label consumeStateFd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox invalidsFd;
    }
}

