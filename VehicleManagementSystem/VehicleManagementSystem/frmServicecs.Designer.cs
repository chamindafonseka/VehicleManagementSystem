namespace VehicleManagementSystem
{
    partial class frmServicecs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMeterReading = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.cboServiceCenter = new System.Windows.Forms.ComboBox();
            this.cboDriver = new System.Windows.Forms.ComboBox();
            this.dtpServiceDate = new System.Windows.Forms.DateTimePicker();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnServiceHistory = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtServiceID = new System.Windows.Forms.TextBox();
            this.dgvService = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(57, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 24);
            this.label15.TabIndex = 87;
            this.label15.Text = "Service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Vehicle No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Serviced Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Service Center";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Meter Reading";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Invoice No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Invoice Amount(Rs.)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Driver";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 88;
            this.label8.Text = "Remarks";
            // 
            // txtMeterReading
            // 
            this.txtMeterReading.Location = new System.Drawing.Point(193, 184);
            this.txtMeterReading.Name = "txtMeterReading";
            this.txtMeterReading.Size = new System.Drawing.Size(169, 20);
            this.txtMeterReading.TabIndex = 89;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(193, 213);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(169, 20);
            this.txtInvoiceNo.TabIndex = 89;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(193, 242);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(169, 20);
            this.txtAmount.TabIndex = 89;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(193, 301);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(226, 69);
            this.txtRemarks.TabIndex = 89;
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(193, 90);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(121, 21);
            this.cboVehicleNo.TabIndex = 90;
            // 
            // cboServiceCenter
            // 
            this.cboServiceCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboServiceCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServiceCenter.FormattingEnabled = true;
            this.cboServiceCenter.Location = new System.Drawing.Point(193, 155);
            this.cboServiceCenter.Name = "cboServiceCenter";
            this.cboServiceCenter.Size = new System.Drawing.Size(169, 21);
            this.cboServiceCenter.TabIndex = 90;
            // 
            // cboDriver
            // 
            this.cboDriver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDriver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDriver.FormattingEnabled = true;
            this.cboDriver.Location = new System.Drawing.Point(193, 271);
            this.cboDriver.Name = "cboDriver";
            this.cboDriver.Size = new System.Drawing.Size(169, 21);
            this.cboDriver.TabIndex = 90;
            // 
            // dtpServiceDate
            // 
            this.dtpServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpServiceDate.Location = new System.Drawing.Point(193, 123);
            this.dtpServiceDate.Name = "dtpServiceDate";
            this.dtpServiceDate.Size = new System.Drawing.Size(121, 20);
            this.dtpServiceDate.TabIndex = 91;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(57, 404);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 92;
            this.btnNew.Text = "New/Refresh";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 92;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(252, 404);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 92;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(344, 404);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 92;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnServiceHistory
            // 
            this.btnServiceHistory.BackColor = System.Drawing.Color.PeachPuff;
            this.btnServiceHistory.Location = new System.Drawing.Point(320, 90);
            this.btnServiceHistory.Name = "btnServiceHistory";
            this.btnServiceHistory.Size = new System.Drawing.Size(89, 23);
            this.btnServiceHistory.TabIndex = 93;
            this.btnServiceHistory.Text = "Service History";
            this.btnServiceHistory.UseVisualStyleBackColor = false;
            this.btnServiceHistory.Click += new System.EventHandler(this.btnServiceHistory_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 94;
            this.label9.Text = "Service ID";
            // 
            // txtServiceID
            // 
            this.txtServiceID.Enabled = false;
            this.txtServiceID.Location = new System.Drawing.Point(193, 61);
            this.txtServiceID.Name = "txtServiceID";
            this.txtServiceID.Size = new System.Drawing.Size(121, 20);
            this.txtServiceID.TabIndex = 95;
            // 
            // dgvService
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Location = new System.Drawing.Point(444, 60);
            this.dgvService.Name = "dgvService";
            this.dgvService.Size = new System.Drawing.Size(817, 310);
            this.dgvService.TabIndex = 96;
            this.dgvService.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvService_CellClick);
            // 
            // frmServicecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 481);
            this.Controls.Add(this.dgvService);
            this.Controls.Add(this.txtServiceID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnServiceHistory);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dtpServiceDate);
            this.Controls.Add(this.cboDriver);
            this.Controls.Add(this.cboServiceCenter);
            this.Controls.Add(this.cboVehicleNo);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.txtMeterReading);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Name = "frmServicecs";
            this.Text = "Servicecs";
            this.Load += new System.EventHandler(this.frmServicecs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMeterReading;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cboVehicleNo;
        private System.Windows.Forms.ComboBox cboServiceCenter;
        private System.Windows.Forms.ComboBox cboDriver;
        private System.Windows.Forms.DateTimePicker dtpServiceDate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnServiceHistory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtServiceID;
        private System.Windows.Forms.DataGridView dgvService;
    }
}