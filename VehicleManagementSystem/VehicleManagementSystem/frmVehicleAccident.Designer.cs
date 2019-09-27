namespace VehicleManagementSystem
{
    partial class frmVehicleAccident
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.cboDriver = new System.Windows.Forms.ComboBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvVehicleAccident = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpAccidentDatetime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVAID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboVehicleSearch = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAllFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAllTo = new System.Windows.Forms.DateTimePicker();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCrVehicleNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnViewVehicle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleAccident)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(35, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(162, 24);
            this.label15.TabIndex = 95;
            this.label15.Text = "Vehicle Accidents";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Vehicle No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Reported By (Driver)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "Location";
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(160, 88);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(197, 21);
            this.cboVehicleNo.TabIndex = 97;
            // 
            // cboDriver
            // 
            this.cboDriver.FormattingEnabled = true;
            this.cboDriver.Location = new System.Drawing.Point(160, 163);
            this.cboDriver.Name = "cboDriver";
            this.cboDriver.Size = new System.Drawing.Size(197, 21);
            this.cboDriver.TabIndex = 97;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(160, 201);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(197, 115);
            this.txtLocation.TabIndex = 99;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(39, 324);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 100;
            this.btnAdd.Text = "Add/Refresh";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(201, 324);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 100;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(282, 324);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 100;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvVehicleAccident
            // 
            this.dgvVehicleAccident.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleAccident.Location = new System.Drawing.Point(379, 53);
            this.dgvVehicleAccident.Name = "dgvVehicleAccident";
            this.dgvVehicleAccident.Size = new System.Drawing.Size(689, 251);
            this.dgvVehicleAccident.TabIndex = 101;
            this.dgvVehicleAccident.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicleAccident_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Accident Date - time";
            // 
            // dtpAccidentDatetime
            // 
            this.dtpAccidentDatetime.CustomFormat = "yyyy-mm-dd HH:mm";
            this.dtpAccidentDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccidentDatetime.Location = new System.Drawing.Point(160, 127);
            this.dtpAccidentDatetime.Name = "dtpAccidentDatetime";
            this.dtpAccidentDatetime.ShowUpDown = true;
            this.dtpAccidentDatetime.Size = new System.Drawing.Size(197, 20);
            this.dtpAccidentDatetime.TabIndex = 98;
            this.dtpAccidentDatetime.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "VAID";
            // 
            // txtVAID
            // 
            this.txtVAID.Enabled = false;
            this.txtVAID.Location = new System.Drawing.Point(160, 53);
            this.txtVAID.Name = "txtVAID";
            this.txtVAID.Size = new System.Drawing.Size(197, 20);
            this.txtVAID.TabIndex = 103;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(994, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 148;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboVehicleSearch
            // 
            this.cboVehicleSearch.BackColor = System.Drawing.Color.PeachPuff;
            this.cboVehicleSearch.FormattingEnabled = true;
            this.cboVehicleSearch.Location = new System.Drawing.Point(865, 25);
            this.cboVehicleSearch.Name = "cboVehicleSearch";
            this.cboVehicleSearch.Size = new System.Drawing.Size(121, 21);
            this.cboVehicleSearch.TabIndex = 147;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(759, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 15);
            this.label12.TabIndex = 146;
            this.label12.Text = "Search Vehicle :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox1.Controls.Add(this.dtpAllFrom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpAllTo);
            this.groupBox1.Controls.Add(this.btnViewAll);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(380, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 54);
            this.groupBox1.TabIndex = 149;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(148, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "To:";
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
            this.label11.Size = new System.Drawing.Size(132, 13);
            this.label11.TabIndex = 102;
            this.label11.Text = "Vehicles\' accident-history :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox2.Controls.Add(this.cboType);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnViewVehicle);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(761, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 54);
            this.groupBox2.TabIndex = 150;
            this.groupBox2.TabStop = false;
            // 
            // cboCrVehicleNo
            // 
            this.cboCrVehicleNo.BackColor = System.Drawing.Color.Bisque;
            this.cboCrVehicleNo.FormattingEnabled = true;
            this.cboCrVehicleNo.Location = new System.Drawing.Point(33, 253);
            this.cboCrVehicleNo.Name = "cboCrVehicleNo";
            this.cboCrVehicleNo.Size = new System.Drawing.Size(121, 21);
            this.cboCrVehicleNo.TabIndex = 148;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 104;
            this.label7.Text = "Vehicle Type:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
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
            this.label9.Size = new System.Drawing.Size(132, 13);
            this.label9.TabIndex = 102;
            this.label9.Text = "Vehicle\'s accident-history :";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(90, 23);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 21);
            this.cboType.TabIndex = 108;
            // 
            // frmVehicleAccident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 376);
            this.Controls.Add(this.cboCrVehicleNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboVehicleSearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtVAID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvVehicleAccident);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.dtpAccidentDatetime);
            this.Controls.Add(this.cboDriver);
            this.Controls.Add(this.cboVehicleNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Name = "frmVehicleAccident";
            this.Text = "Vehicle Accident";
            this.Load += new System.EventHandler(this.frmVehicleAccident_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleAccident)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboVehicleNo;
        private System.Windows.Forms.ComboBox cboDriver;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvVehicleAccident;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpAccidentDatetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVAID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboVehicleSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpAllFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAllTo;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCrVehicleNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnViewVehicle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboType;
    }
}