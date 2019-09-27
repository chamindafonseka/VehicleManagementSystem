namespace VehicleManagementSystem
{
    partial class frmRunningChart
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
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtMeterReader = new System.Windows.Forms.TextBox();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.lblLastMeterReading = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTripLength = new System.Windows.Forms.Label();
            this.cboDriver = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCrDriver = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cboRptVehicleNo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnViewDriver = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(38, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 24);
            this.label15.TabIndex = 114;
            this.label15.Text = "Running Chart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Vehicle No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 115;
            this.label2.Text = "Odo Meter Reading";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(42, 234);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(393, 130);
            this.txtDescription.TabIndex = 116;
            this.txtDescription.Click += new System.EventHandler(this.txtDescription_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(360, 370);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 117;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtMeterReader
            // 
            this.txtMeterReader.Location = new System.Drawing.Point(173, 106);
            this.txtMeterReader.Name = "txtMeterReader";
            this.txtMeterReader.Size = new System.Drawing.Size(161, 20);
            this.txtMeterReader.TabIndex = 118;
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVehicleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(173, 77);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(161, 21);
            this.cboVehicleNo.Sorted = true;
            this.cboVehicleNo.TabIndex = 119;
            this.cboVehicleNo.DropDownClosed += new System.EventHandler(this.cboVehicleNo_DropDownClosed);
            // 
            // lblLastMeterReading
            // 
            this.lblLastMeterReading.AutoSize = true;
            this.lblLastMeterReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMeterReading.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblLastMeterReading.Location = new System.Drawing.Point(170, 131);
            this.lblLastMeterReading.Name = "lblLastMeterReading";
            this.lblLastMeterReading.Size = new System.Drawing.Size(19, 13);
            this.lblLastMeterReading.TabIndex = 120;
            this.lblLastMeterReading.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Checked = false;
            this.dtpDate.CustomFormat = "\" \"";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(173, 154);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(161, 20);
            this.dtpDate.TabIndex = 121;
            this.dtpDate.DropDown += new System.EventHandler(this.dtpDate_DropDown);
            // 
            // lblTripLength
            // 
            this.lblTripLength.AutoSize = true;
            this.lblTripLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTripLength.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTripLength.Location = new System.Drawing.Point(170, 218);
            this.lblTripLength.Name = "lblTripLength";
            this.lblTripLength.Size = new System.Drawing.Size(19, 13);
            this.lblTripLength.TabIndex = 122;
            this.lblTripLength.Text = "...";
            // 
            // cboDriver
            // 
            this.cboDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDriver.FormattingEnabled = true;
            this.cboDriver.Location = new System.Drawing.Point(173, 183);
            this.cboDriver.Name = "cboDriver";
            this.cboDriver.Size = new System.Drawing.Size(161, 21);
            this.cboDriver.TabIndex = 123;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.btnViewAll);
            this.groupBox1.Controls.Add(this.btnViewDriver);
            this.groupBox1.Controls.Add(this.cboCrDriver);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.cboRptVehicleNo);
            this.groupBox1.Location = new System.Drawing.Point(42, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 150);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            // 
            // cboCrDriver
            // 
            this.cboCrDriver.FormattingEnabled = true;
            this.cboCrDriver.Location = new System.Drawing.Point(228, 87);
            this.cboCrDriver.Name = "cboCrDriver";
            this.cboCrDriver.Size = new System.Drawing.Size(118, 21);
            this.cboCrDriver.TabIndex = 132;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(202, 13);
            this.label10.TabIndex = 131;
            this.label10.Text = "Distance traveled  report for all vehicles  :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 13);
            this.label9.TabIndex = 129;
            this.label9.Text = "Distance traveled  report for selected Driver :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label12.Location = new System.Drawing.Point(6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 128;
            this.label12.Text = "Milage Reports";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(351, 57);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(42, 23);
            this.btnView.TabIndex = 126;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 125;
            this.label7.Text = "End Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 125;
            this.label6.Text = "Start Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Distance traveled  report for selected  Vehicle no:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(289, 26);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(104, 20);
            this.dtpEndDate.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(88, 26);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(97, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // cboRptVehicleNo
            // 
            this.cboRptVehicleNo.FormattingEnabled = true;
            this.cboRptVehicleNo.Location = new System.Drawing.Point(249, 58);
            this.cboRptVehicleNo.Name = "cboRptVehicleNo";
            this.cboRptVehicleNo.Size = new System.Drawing.Size(97, 21);
            this.cboRptVehicleNo.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 115;
            this.label8.Text = "Driver :";
            // 
            // btnViewDriver
            // 
            this.btnViewDriver.Location = new System.Drawing.Point(351, 87);
            this.btnViewDriver.Name = "btnViewDriver";
            this.btnViewDriver.Size = new System.Drawing.Size(40, 23);
            this.btnViewDriver.TabIndex = 133;
            this.btnViewDriver.Text = "View";
            this.btnViewDriver.UseVisualStyleBackColor = true;
            this.btnViewDriver.Click += new System.EventHandler(this.btnViewDriver_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(228, 116);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(45, 23);
            this.btnViewAll.TabIndex = 134;
            this.btnViewAll.Text = "View";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // frmRunningChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboDriver);
            this.Controls.Add(this.lblTripLength);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblLastMeterReading);
            this.Controls.Add(this.cboVehicleNo);
            this.Controls.Add(this.txtMeterReader);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Name = "frmRunningChart";
            this.Text = "Running Chart";
            this.Load += new System.EventHandler(this.frmRunningChart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtMeterReader;
        private System.Windows.Forms.ComboBox cboVehicleNo;
        private System.Windows.Forms.Label lblLastMeterReading;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTripLength;
        private System.Windows.Forms.ComboBox cboDriver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cboRptVehicleNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboCrDriver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnViewDriver;
    }
}