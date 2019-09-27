namespace VehicleManagementSystem
{
    partial class frmDocumentStore
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
            this.pbDocumentStore = new System.Windows.Forms.PictureBox();
            this.btnSelectDoc = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.cbovehicleNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDocumentType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvDocumentStore = new System.Windows.Forms.DataGridView();
            this.lblSourcePath = new System.Windows.Forms.Label();
            this.lblDetinationPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocumentStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentStore)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDocumentStore
            // 
            this.pbDocumentStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDocumentStore.Location = new System.Drawing.Point(83, 98);
            this.pbDocumentStore.Name = "pbDocumentStore";
            this.pbDocumentStore.Size = new System.Drawing.Size(209, 277);
            this.pbDocumentStore.TabIndex = 0;
            this.pbDocumentStore.TabStop = false;
            // 
            // btnSelectDoc
            // 
            this.btnSelectDoc.BackColor = System.Drawing.Color.MistyRose;
            this.btnSelectDoc.Location = new System.Drawing.Point(83, 381);
            this.btnSelectDoc.Name = "btnSelectDoc";
            this.btnSelectDoc.Size = new System.Drawing.Size(130, 23);
            this.btnSelectDoc.TabIndex = 1;
            this.btnSelectDoc.Text = "Select a scanned doc.";
            this.btnSelectDoc.UseVisualStyleBackColor = false;
            this.btnSelectDoc.Click += new System.EventHandler(this.btnSelectDoc_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(49, 435);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(62, 13);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Vehicle No.";
            // 
            // cbovehicleNo
            // 
            this.cbovehicleNo.FormattingEnabled = true;
            this.cbovehicleNo.Location = new System.Drawing.Point(158, 428);
            this.cbovehicleNo.Name = "cbovehicleNo";
            this.cbovehicleNo.Size = new System.Drawing.Size(183, 21);
            this.cbovehicleNo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document Type";
            // 
            // cboDocumentType
            // 
            this.cboDocumentType.FormattingEnabled = true;
            this.cboDocumentType.Location = new System.Drawing.Point(158, 459);
            this.cboDocumentType.Name = "cboDocumentType";
            this.cboDocumentType.Size = new System.Drawing.Size(183, 21);
            this.cboDocumentType.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Source File Path";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.SystemColors.Info;
            this.btnView.Location = new System.Drawing.Point(213, 62);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(59, 20);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(48, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 24);
            this.label15.TabIndex = 113;
            this.label15.Text = "Document Store";
            // 
            // dgvDocumentStore
            // 
            this.dgvDocumentStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentStore.Location = new System.Drawing.Point(376, 65);
            this.dgvDocumentStore.Name = "dgvDocumentStore";
            this.dgvDocumentStore.Size = new System.Drawing.Size(615, 415);
            this.dgvDocumentStore.TabIndex = 114;
            this.dgvDocumentStore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentStore_CellClick);
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSourcePath.Location = new System.Drawing.Point(155, 491);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(25, 13);
            this.lblSourcePath.TabIndex = 115;
            this.lblSourcePath.Text = "......";
            // 
            // lblDetinationPath
            // 
            this.lblDetinationPath.AutoSize = true;
            this.lblDetinationPath.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDetinationPath.Location = new System.Drawing.Point(155, 518);
            this.lblDetinationPath.Name = "lblDetinationPath";
            this.lblDetinationPath.Size = new System.Drawing.Size(25, 13);
            this.lblDetinationPath.TabIndex = 116;
            this.lblDetinationPath.Text = "......";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destination File Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "Document ID";
            // 
            // txtDocID
            // 
            this.txtDocID.Enabled = false;
            this.txtDocID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocID.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtDocID.Location = new System.Drawing.Point(128, 62);
            this.txtDocID.Name = "txtDocID";
            this.txtDocID.Size = new System.Drawing.Size(79, 21);
            this.txtDocID.TabIndex = 118;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(670, 489);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(78, 23);
            this.btnAdd.TabIndex = 119;
            this.btnAdd.Text = "Add / Refresh";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(916, 489);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 119;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(835, 489);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 119;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(754, 489);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(916, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 120;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboSearch
            // 
            this.cboSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearch.BackColor = System.Drawing.Color.MistyRose;
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Location = new System.Drawing.Point(800, 38);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(110, 21);
            this.cboSearch.TabIndex = 121;
            // 
            // frmDocumentStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 566);
            this.Controls.Add(this.cboSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDocID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDetinationPath);
            this.Controls.Add(this.lblSourcePath);
            this.Controls.Add(this.dgvDocumentStore);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.cboDocumentType);
            this.Controls.Add(this.cbovehicleNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnSelectDoc);
            this.Controls.Add(this.pbDocumentStore);
            this.Name = "frmDocumentStore";
            this.Tag = "asas";
            this.Text = "Document Store";
            this.Load += new System.EventHandler(this.frmDocumentStore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDocumentStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentStore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDocumentStore;
        private System.Windows.Forms.Button btnSelectDoc;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cbovehicleNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDocumentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvDocumentStore;
        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.Label lblDetinationPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboSearch;
    }
}