namespace DataGen.Ui
{
    partial class DataGenForm
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
            this.insertCountFd = new System.Windows.Forms.TextBox();
            this.insertBn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.entityCountFd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.secondsFd = new System.Windows.Forms.TextBox();
            this.recordsFd = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.writesFd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertCountFd
            // 
            this.insertCountFd.Location = new System.Drawing.Point(39, 38);
            this.insertCountFd.Name = "insertCountFd";
            this.insertCountFd.Size = new System.Drawing.Size(73, 20);
            this.insertCountFd.TabIndex = 0;
            this.insertCountFd.Text = "2000";
            // 
            // insertBn
            // 
            this.insertBn.Location = new System.Drawing.Point(38, 83);
            this.insertBn.Name = "insertBn";
            this.insertBn.Size = new System.Drawing.Size(75, 23);
            this.insertBn.TabIndex = 1;
            this.insertBn.Text = "insert";
            this.insertBn.UseVisualStyleBackColor = true;
            this.insertBn.Click += new System.EventHandler(this.insertBn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.insertBn);
            this.groupBox1.Controls.Add(this.insertCountFd);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // entityCountFd
            // 
            this.entityCountFd.Location = new System.Drawing.Point(33, 141);
            this.entityCountFd.Name = "entityCountFd";
            this.entityCountFd.ReadOnly = true;
            this.entityCountFd.Size = new System.Drawing.Size(19, 20);
            this.entityCountFd.TabIndex = 3;
            this.entityCountFd.Text = "?";
            this.entityCountFd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.entityCountFd.TextChanged += new System.EventHandler(this.entityCountFd_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 18F);
            this.label4.Location = new System.Drawing.Point(18, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.secondsFd);
            this.groupBox2.Controls.Add(this.recordsFd);
            this.groupBox2.Location = new System.Drawing.Point(156, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(39, 101);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 18);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "insert periodically ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "records";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "seconds";
            // 
            // secondsFd
            // 
            this.secondsFd.Location = new System.Drawing.Point(42, 35);
            this.secondsFd.Name = "secondsFd";
            this.secondsFd.Size = new System.Drawing.Size(48, 20);
            this.secondsFd.TabIndex = 2;
            this.secondsFd.Text = "3";
            // 
            // recordsFd
            // 
            this.recordsFd.Location = new System.Drawing.Point(43, 65);
            this.recordsFd.Name = "recordsFd";
            this.recordsFd.Size = new System.Drawing.Size(48, 20);
            this.recordsFd.TabIndex = 3;
            this.recordsFd.Text = "100";
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // writesFd
            // 
            this.writesFd.Location = new System.Drawing.Point(134, 141);
            this.writesFd.Name = "writesFd";
            this.writesFd.ReadOnly = true;
            this.writesFd.Size = new System.Drawing.Size(55, 20);
            this.writesFd.TabIndex = 5;
            this.writesFd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "write:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(337, 172);
            this.Controls.Add(this.entityCountFd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.writesFd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataGen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox insertCountFd;
        private System.Windows.Forms.Button insertBn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox recordsFd;
        private System.Windows.Forms.TextBox secondsFd;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox writesFd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox entityCountFd;
        private System.Windows.Forms.Label label4;

    }
}

