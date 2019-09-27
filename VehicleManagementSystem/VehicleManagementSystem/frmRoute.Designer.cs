namespace VehicleManagementSystem
{
    partial class frmRoute
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvRoute = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCoveredArea = new System.Windows.Forms.TextBox();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRouteLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRouteID = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRouteIDSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(306, 359);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 99;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(220, 359);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 98;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(48, 359);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 97;
            this.btnNew.Text = "New/Refresh";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvRoute
            // 
            this.dgvRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoute.Location = new System.Drawing.Point(446, 111);
            this.dgvRoute.Name = "dgvRoute";
            this.dgvRoute.ReadOnly = true;
            this.dgvRoute.Size = new System.Drawing.Size(755, 271);
            this.dgvRoute.TabIndex = 95;
            this.dgvRoute.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoute_CellClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(49, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(168, 24);
            this.label15.TabIndex = 94;
            this.label15.Text = "Route Registration ";
            // 
            // txtCoveredArea
            // 
            this.txtCoveredArea.Location = new System.Drawing.Point(207, 204);
            this.txtCoveredArea.Multiline = true;
            this.txtCoveredArea.Name = "txtCoveredArea";
            this.txtCoveredArea.Size = new System.Drawing.Size(186, 125);
            this.txtCoveredArea.TabIndex = 89;
            // 
            // txtRouteName
            // 
            this.txtRouteName.Location = new System.Drawing.Point(207, 146);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(186, 20);
            this.txtRouteName.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 85;
            this.label4.Text = "Route Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 83;
            this.label3.Text = "Route Length";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 81;
            this.label1.Text = "Covered areas";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(134, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 97;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRouteLength
            // 
            this.txtRouteLength.Location = new System.Drawing.Point(207, 174);
            this.txtRouteLength.Name = "txtRouteLength";
            this.txtRouteLength.Size = new System.Drawing.Size(186, 20);
            this.txtRouteLength.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 85;
            this.label2.Text = "Route ID";
            // 
            // txtRouteID
            // 
            this.txtRouteID.Enabled = false;
            this.txtRouteID.Location = new System.Drawing.Point(207, 111);
            this.txtRouteID.Name = "txtRouteID";
            this.txtRouteID.Size = new System.Drawing.Size(186, 20);
            this.txtRouteID.TabIndex = 88;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1117, 71);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 20);
            this.btnRefresh.TabIndex = 103;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(818, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 15);
            this.label17.TabIndex = 102;
            this.label17.Text = "Registration No:";
            // 
            // txtRouteIDSearch
            // 
            this.txtRouteIDSearch.BackColor = System.Drawing.Color.PeachPuff;
            this.txtRouteIDSearch.Location = new System.Drawing.Point(921, 71);
            this.txtRouteIDSearch.Name = "txtRouteIDSearch";
            this.txtRouteIDSearch.Size = new System.Drawing.Size(101, 20);
            this.txtRouteIDSearch.TabIndex = 101;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1036, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 20);
            this.btnSearch.TabIndex = 100;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 436);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtRouteIDSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvRoute);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCoveredArea);
            this.Controls.Add(this.txtRouteLength);
            this.Controls.Add(this.txtRouteID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(40, 50);
            this.Name = "frmRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Route";
            this.Load += new System.EventHandler(this.frmRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvRoute;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCoveredArea;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRouteLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRouteID;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtRouteIDSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}