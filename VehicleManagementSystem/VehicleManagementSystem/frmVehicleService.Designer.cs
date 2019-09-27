namespace VehicleManagementSystem
{
    partial class frmVehicleService
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
            System.Windows.Forms.Label label15;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMeterReading = new System.Windows.Forms.TextBox();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.dtpServiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtNextServiceReading = new System.Windows.Forms.TextBox();
            this.cboServiceCenter = new System.Windows.Forms.ComboBox();
            this.btnSumbit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            label15.Location = new System.Drawing.Point(56, 40);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(142, 24);
            label15.TabIndex = 86;
            label15.Text = "Vehicle Service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Vehicle No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Meter Reading";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Service Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Next Service Meter Reading";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "Service Center";
            // 
            // txtMeterReading
            // 
            this.txtMeterReading.Location = new System.Drawing.Point(211, 136);
            this.txtMeterReading.Name = "txtMeterReading";
            this.txtMeterReading.Size = new System.Drawing.Size(134, 20);
            this.txtMeterReading.TabIndex = 88;
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(211, 104);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(134, 21);
            this.cboVehicleNo.TabIndex = 89;
            // 
            // dtpServiceDate
            // 
            this.dtpServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpServiceDate.Location = new System.Drawing.Point(211, 165);
            this.dtpServiceDate.Name = "dtpServiceDate";
            this.dtpServiceDate.Size = new System.Drawing.Size(134, 20);
            this.dtpServiceDate.TabIndex = 90;
            // 
            // txtNextServiceReading
            // 
            this.txtNextServiceReading.Location = new System.Drawing.Point(211, 196);
            this.txtNextServiceReading.Name = "txtNextServiceReading";
            this.txtNextServiceReading.Size = new System.Drawing.Size(134, 20);
            this.txtNextServiceReading.TabIndex = 88;
            // 
            // cboServiceCenter
            // 
            this.cboServiceCenter.FormattingEnabled = true;
            this.cboServiceCenter.Location = new System.Drawing.Point(211, 225);
            this.cboServiceCenter.Name = "cboServiceCenter";
            this.cboServiceCenter.Size = new System.Drawing.Size(134, 21);
            this.cboServiceCenter.TabIndex = 89;
            // 
            // btnSumbit
            // 
            this.btnSumbit.Location = new System.Drawing.Point(211, 406);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(75, 23);
            this.btnSumbit.TabIndex = 91;
            this.btnSumbit.Text = "Submit";
            this.btnSumbit.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Details";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(211, 265);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(290, 109);
            this.txtDetails.TabIndex = 88;
            // 
            // frmVehicleService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 490);
            this.Controls.Add(this.btnSumbit);
            this.Controls.Add(this.dtpServiceDate);
            this.Controls.Add(this.cboServiceCenter);
            this.Controls.Add(this.cboVehicleNo);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.txtNextServiceReading);
            this.Controls.Add(this.txtMeterReading);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(label15);
            this.Name = "frmVehicleService";
            this.Text = "Vehicle Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMeterReading;
        private System.Windows.Forms.ComboBox cboVehicleNo;
        private System.Windows.Forms.DateTimePicker dtpServiceDate;
        private System.Windows.Forms.TextBox txtNextServiceReading;
        private System.Windows.Forms.ComboBox cboServiceCenter;
        private System.Windows.Forms.Button btnSumbit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDetails;
    }
}