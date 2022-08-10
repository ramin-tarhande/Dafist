namespace DataGen2
{
    partial class Form1
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
            this.sendBn = new System.Windows.Forms.Button();
            this.empIdTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sendBn
            // 
            this.sendBn.Location = new System.Drawing.Point(20, 64);
            this.sendBn.Name = "sendBn";
            this.sendBn.Size = new System.Drawing.Size(75, 23);
            this.sendBn.TabIndex = 0;
            this.sendBn.Text = "send";
            this.sendBn.UseVisualStyleBackColor = true;
            this.sendBn.Click += new System.EventHandler(this.sendBn_Click);
            // 
            // empIdTb
            // 
            this.empIdTb.Location = new System.Drawing.Point(37, 22);
            this.empIdTb.Name = "empIdTb";
            this.empIdTb.Size = new System.Drawing.Size(43, 20);
            this.empIdTb.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 106);
            this.Controls.Add(this.empIdTb);
            this.Controls.Add(this.sendBn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atd data gen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendBn;
        private System.Windows.Forms.TextBox empIdTb;
    }
}

