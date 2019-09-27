namespace VehicleManagementSystem
{
    partial class frmInsuranceClaim
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClaimID = new System.Windows.Forms.TextBox();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.cboVAID = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtchequeNo = new System.Windows.Forms.TextBox();
            this.dtpPaydate = new System.Windows.Forms.DateTimePicker();
            this.dgvInsuranceClaim = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboVehicleSearch = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAllFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpAllTo = new System.Windows.Forms.DateTimePicker();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCrVehicleNo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnViewVehicle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboInsuCompany = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsuranceClaim)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "ClaimID";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(267, 294);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 106;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(186, 294);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 107;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 294);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 108;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(24, 294);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 109;
            this.btnAdd.Text = "Add/Refresh";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "Amount (Rs.)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "Vehicle No";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(26, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 24);
            this.label15.TabIndex = 103;
            this.label15.Text = "Insurance Claims";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 111;
            this.label3.Text = "Accident no";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Cheque No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Paydate";
            // 
            // txtClaimID
            // 
            this.txtClaimID.Enabled = false;
            this.txtClaimID.Location = new System.Drawing.Point(174, 67);
            this.txtClaimID.Name = "txtClaimID";
            this.txtClaimID.Size = new System.Drawing.Size(168, 20);
            this.txtClaimID.TabIndex = 114;
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(174, 97);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(168, 21);
            this.cboVehicleNo.TabIndex = 115;
            // 
            // cboVAID
            // 
            this.cboVAID.FormattingEnabled = true;
            this.cboVAID.Location = new System.Drawing.Point(174, 159);
            this.cboVAID.Name = "cboVAID";
            this.cboVAID.Size = new System.Drawing.Size(168, 21);
            this.cboVAID.TabIndex = 116;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(174, 190);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(168, 20);
            this.txtAmount.TabIndex = 117;
            // 
            // txtchequeNo
            // 
            this.txtchequeNo.Location = new System.Drawing.Point(174, 220);
            this.txtchequeNo.Name = "txtchequeNo";
            this.txtchequeNo.Size = new System.Drawing.Size(168, 20);
            this.txtchequeNo.TabIndex = 118;
            // 
            // dtpPaydate
            // 
            this.dtpPaydate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaydate.Location = new System.Drawing.Point(175, 250);
            this.dtpPaydate.Name = "dtpPaydate";
            this.dtpPaydate.Size = new System.Drawing.Size(168, 20);
            this.dtpPaydate.TabIndex = 119;
            this.dtpPaydate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dgvInsuranceClaim
            // 
            this.dgvInsuranceClaim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsuranceClaim.Location = new System.Drawing.Point(373, 63);
            this.dgvInsuranceClaim.Name = "dgvInsuranceClaim";
            this.dgvInsuranceClaim.Size = new System.Drawing.Size(689, 254);
            this.dgvInsuranceClaim.TabIndex = 120;
            this.dgvInsuranceClaim.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsuranceClaim_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(986, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 151;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboVehicleSearch
            // 
            this.cboVehicleSearch.BackColor = System.Drawing.Color.PeachPuff;
            this.cboVehicleSearch.FormattingEnabled = true;
            this.cboVehicleSearch.Location = new System.Drawing.Point(857, 34);
            this.cboVehicleSearch.Name = "cboVehicleSearch";
            this.cboVehicleSearch.Size = new System.Drawing.Size(121, 21);
            this.cboVehicleSearch.TabIndex = 150;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(751, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 15);
            this.label12.TabIndex = 149;
            this.label12.Text = "Search Vehicle :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox1.Controls.Add(this.dtpAllFrom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpAllTo);
            this.groupBox1.Controls.Add(this.btnViewAll);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(373, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 54);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // dtpAllFrom
            // 
            this.dtpAllFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAllFrom.Location = new System.Drawing.Point(42, 23);
            this.dtpAllFrom.Name = "dtpAllFrom";
            this.dtpAllFrom.Size = new System.Drawing.Size(103, 20);
            this.dtpAllFrom.TabIndex = 103;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 104;
            this.label10.Text = "From :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(148, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "To:";
            // 
            // dtpAllTo
            // 
            this.dtpAllTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAllTo.Location = new System.Drawing.Point(178, 23);
            this.dtpAllTo.Name = "dtpAllTo";
            this.dtpAllTo.Size = new System.Drawing.Size(103, 20);
            this.dtpAllTo.TabIndex = 106;
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAll.Location = new System.Drawing.Point(285, 22);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(81, 23);
            this.btnViewAll.TabIndex = 107;
            this.btnViewAll.Text = "View";
            this.btnViewAll.UseVisualStyleBackColor = false;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(0, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 13);
            this.label11.TabIndex = 102;
            this.label11.Text = "Accidents claim-historyhistory :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox2.Controls.Add(this.cboCrVehicleNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnViewVehicle);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(755, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 54);
            this.groupBox2.TabIndex = 153;
            this.groupBox2.TabStop = false;
            // 
            // cboCrVehicleNo
            // 
            this.cboCrVehicleNo.BackColor = System.Drawing.Color.Bisque;
            this.cboCrVehicleNo.FormattingEnabled = true;
            this.cboCrVehicleNo.Location = new System.Drawing.Point(90, 20);
            this.cboCrVehicleNo.Name = "cboCrVehicleNo";
            this.cboCrVehicleNo.Size = new System.Drawing.Size(121, 21);
            this.cboCrVehicleNo.TabIndex = 148;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 104;
            this.label8.Text = "Vehicle No:";
            // 
            // btnViewVehicle
            // 
            this.btnViewVehicle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewVehicle.Location = new System.Drawing.Point(217, 20);
            this.btnViewVehicle.Name = "btnViewVehicle";
            this.btnViewVehicle.Size = new System.Drawing.Size(75, 23);
            this.btnViewVehicle.TabIndex = 107;
            this.btnViewVehicle.Text = "View";
            this.btnViewVehicle.UseVisualStyleBackColor = false;
            this.btnViewVehicle.Click += new System.EventHandler(this.btnViewVehicle_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(1, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 13);
            this.label9.TabIndex = 102;
            this.label9.Text = "Vehicle\'s accident claim-history :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 154;
            this.label13.Text = "Insurance Company";
            // 
            // cboInsuCompany
            // 
            this.cboInsuCompany.FormattingEnabled = true;
            this.cboInsuCompany.Location = new System.Drawing.Point(174, 128);
            this.cboInsuCompany.Name = "cboInsuCompany";
            this.cboInsuCompany.Size = new System.Drawing.Size(168, 21);
            this.cboInsuCompany.TabIndex = 155;
            // 
            // frmInsuranceClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 382);
            this.Controls.Add(this.cboInsuCompany);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboVehicleSearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvInsuranceClaim);
            this.Controls.Add(this.dtpPaydate);
            this.Controls.Add(this.txtchequeNo);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cboVAID);
            this.Controls.Add(this.cboVehicleNo);
            this.Controls.Add(this.txtClaimID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Name = "frmInsuranceClaim";
            this.Text = "Insurance Claim";
            this.Load += new System.EventHandler(this.frmInsuranceClaim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsuranceClaim)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClaimID;
        private System.Windows.Forms.ComboBox cboVehicleNo;
        private System.Windows.Forms.ComboBox cboVAID;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtchequeNo;
        private System.Windows.Forms.DateTimePicker dtpPaydate;
        private System.Windows.Forms.DataGridView dgvInsuranceClaim;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboVehicleSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpAllFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpAllTo;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCrVehicleNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnViewVehicle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboInsuCompany;
    }
}