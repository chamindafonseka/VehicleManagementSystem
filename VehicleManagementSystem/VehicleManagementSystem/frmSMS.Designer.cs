namespace VehicleManagementSystem
{
    partial class frmSMS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cboPhoneNo = new System.Windows.Forms.ComboBox();
            this.lblSent = new System.Windows.Forms.Label();
            this.cboCOMName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mobile No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtMessage.Location = new System.Drawing.Point(102, 125);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(323, 217);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(102, 348);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cboPhoneNo
            // 
            this.cboPhoneNo.FormattingEnabled = true;
            this.cboPhoneNo.Location = new System.Drawing.Point(102, 91);
            this.cboPhoneNo.Name = "cboPhoneNo";
            this.cboPhoneNo.Size = new System.Drawing.Size(121, 21);
            this.cboPhoneNo.TabIndex = 4;
            this.cboPhoneNo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cboPhoneNo.Click += new System.EventHandler(this.cboPhoneNo_Click);
            // 
            // lblSent
            // 
            this.lblSent.AutoSize = true;
            this.lblSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSent.ForeColor = System.Drawing.Color.Maroon;
            this.lblSent.Location = new System.Drawing.Point(99, 374);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(13, 17);
            this.lblSent.TabIndex = 3;
            this.lblSent.Text = ".";
            // 
            // cboCOMName
            // 
            this.cboCOMName.FormattingEnabled = true;
            this.cboCOMName.Location = new System.Drawing.Point(102, 57);
            this.cboCOMName.Name = "cboCOMName";
            this.cboCOMName.Size = new System.Drawing.Size(121, 21);
            this.cboCOMName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "COM Port :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Location = new System.Drawing.Point(213, 362);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 47);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Find the COM port, by following  steps: Control Panel>Administrative Tools>Comput" +
    "er Management>Device Manager>Modems";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(23, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(163, 24);
            this.label15.TabIndex = 104;
            this.label15.Text = "Message Sending";
            // 
            // frmSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 440);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCOMName);
            this.Controls.Add(this.cboPhoneNo);
            this.Controls.Add(this.lblSent);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSMS";
            this.Text = "Send Message";
            this.Load += new System.EventHandler(this.frmSMS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cboPhoneNo;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.ComboBox cboCOMName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label15;
    }
}