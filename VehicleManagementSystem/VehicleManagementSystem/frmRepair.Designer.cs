namespace VehicleManagementSystem
{
    partial class frmRepair
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dgvRepairing = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpRepairDate = new System.Windows.Forms.DateTimePicker();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.cboGarage = new System.Windows.Forms.ComboBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNosOfItems = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboDriver = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.brnDateRepairHistory = new System.Windows.Forms.Button();
            this.btnInvoiceSearch = new System.Windows.Forms.Button();
            this.btnVehiRepairHistory = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairing)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            label15.Location = new System.Drawing.Point(49, 9);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(160, 24);
            label15.TabIndex = 87;
            label15.Text = "Vehicle Repairing";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Vehicle No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Garage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Amount (Rs.) ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Invoice No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(159, 215);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(388, 47);
            this.txtRemarks.TabIndex = 89;
            // 
            // dgvRepairing
            // 
            this.dgvRepairing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepairing.Location = new System.Drawing.Point(53, 392);
            this.dgvRepairing.Name = "dgvRepairing";
            this.dgvRepairing.Size = new System.Drawing.Size(494, 200);
            this.dgvRepairing.TabIndex = 90;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(472, 598);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 91;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(159, 134);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(164, 20);
            this.txtAmount.TabIndex = 92;
            // 
            // dtpRepairDate
            // 
            this.dtpRepairDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRepairDate.Location = new System.Drawing.Point(159, 79);
            this.dtpRepairDate.Name = "dtpRepairDate";
            this.dtpRepairDate.Size = new System.Drawing.Size(164, 20);
            this.dtpRepairDate.TabIndex = 93;
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(159, 51);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(164, 21);
            this.cboVehicleNo.TabIndex = 94;
            // 
            // cboGarage
            // 
            this.cboGarage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGarage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGarage.FormattingEnabled = true;
            this.cboGarage.Location = new System.Drawing.Point(159, 106);
            this.cboGarage.Name = "cboGarage";
            this.cboGarage.Size = new System.Drawing.Size(164, 21);
            this.cboGarage.TabIndex = 94;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(159, 161);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(164, 20);
            this.txtInvoiceNo.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Item";
            // 
            // cboItemName
            // 
            this.cboItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(158, 282);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(204, 21);
            this.cboItemName.TabIndex = 94;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 88;
            this.label8.Text = "Number of Items";
            // 
            // txtNosOfItems
            // 
            this.txtNosOfItems.Location = new System.Drawing.Point(158, 309);
            this.txtNosOfItems.Name = "txtNosOfItems";
            this.txtNosOfItems.Size = new System.Drawing.Size(204, 20);
            this.txtNosOfItems.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 88;
            this.label9.Text = "Serial Number";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(157, 337);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(204, 20);
            this.txtSerialNo.TabIndex = 92;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.PeachPuff;
            this.btnAdd.Location = new System.Drawing.Point(450, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 95;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(21, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(565, 13);
            this.label10.TabIndex = 96;
            this.label10.Text = "................................................................................." +
    "................................................................................" +
    ".........................";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 88;
            this.label11.Text = "Driver";
            // 
            // cboDriver
            // 
            this.cboDriver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDriver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDriver.FormattingEnabled = true;
            this.cboDriver.Location = new System.Drawing.Point(159, 188);
            this.cboDriver.Name = "cboDriver";
            this.cboDriver.Size = new System.Drawing.Size(164, 21);
            this.cboDriver.TabIndex = 94;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(391, 598);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 97;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // brnDateRepairHistory
            // 
            this.brnDateRepairHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.brnDateRepairHistory.Location = new System.Drawing.Point(329, 79);
            this.brnDateRepairHistory.Name = "brnDateRepairHistory";
            this.brnDateRepairHistory.Size = new System.Drawing.Size(68, 20);
            this.brnDateRepairHistory.TabIndex = 98;
            this.brnDateRepairHistory.Text = "History";
            this.brnDateRepairHistory.UseVisualStyleBackColor = false;
            this.brnDateRepairHistory.Click += new System.EventHandler(this.brnDateRepairHistory_Click);
            // 
            // btnInvoiceSearch
            // 
            this.btnInvoiceSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnInvoiceSearch.Location = new System.Drawing.Point(329, 161);
            this.btnInvoiceSearch.Name = "btnInvoiceSearch";
            this.btnInvoiceSearch.Size = new System.Drawing.Size(68, 20);
            this.btnInvoiceSearch.TabIndex = 98;
            this.btnInvoiceSearch.Text = "Search";
            this.btnInvoiceSearch.UseVisualStyleBackColor = false;
            // 
            // btnVehiRepairHistory
            // 
            this.btnVehiRepairHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnVehiRepairHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehiRepairHistory.Location = new System.Drawing.Point(329, 51);
            this.btnVehiRepairHistory.Name = "btnVehiRepairHistory";
            this.btnVehiRepairHistory.Size = new System.Drawing.Size(68, 22);
            this.btnVehiRepairHistory.TabIndex = 98;
            this.btnVehiRepairHistory.Text = "History";
            this.btnVehiRepairHistory.UseVisualStyleBackColor = false;
            this.btnVehiRepairHistory.Click += new System.EventHandler(this.btnVehiRepairHistory_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(55, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 99;
            this.label12.Text = "Supplier";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(157, 363);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(204, 21);
            this.cboSupplier.TabIndex = 100;
            // 
            // frmRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 631);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnInvoiceSearch);
            this.Controls.Add(this.btnVehiRepairHistory);
            this.Controls.Add(this.brnDateRepairHistory);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboItemName);
            this.Controls.Add(this.cboDriver);
            this.Controls.Add(this.cboGarage);
            this.Controls.Add(this.cboVehicleNo);
            this.Controls.Add(this.dtpRepairDate);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.txtNosOfItems);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvRepairing);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(label15);
            this.Name = "frmRepair";
            this.Text = "Vehicle Repairing";
            this.Load += new System.EventHandler(this.frmVehicleRepairing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridView dgvRepairing;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpRepairDate;
        private System.Windows.Forms.ComboBox cboVehicleNo;
        private System.Windows.Forms.ComboBox cboGarage;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNosOfItems;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboDriver;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button brnDateRepairHistory;
        private System.Windows.Forms.Button btnInvoiceSearch;
        private System.Windows.Forms.Button btnVehiRepairHistory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSupplier;
    }
}