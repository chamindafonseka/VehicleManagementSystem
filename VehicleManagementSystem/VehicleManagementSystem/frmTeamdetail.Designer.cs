namespace VehicleManagementSystem
{
    partial class frmTeamdetail
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
            this.btnDissolve = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvTeamDetails = new System.Windows.Forms.DataGridView();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVehicleNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDissolve
            // 
            this.btnDissolve.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnDissolve.Location = new System.Drawing.Point(297, 332);
            this.btnDissolve.Name = "btnDissolve";
            this.btnDissolve.Size = new System.Drawing.Size(100, 23);
            this.btnDissolve.TabIndex = 120;
            this.btnDissolve.Text = "Dissolve";
            this.btnDissolve.UseVisualStyleBackColor = false;
            this.btnDissolve.Click += new System.EventHandler(this.btnDissolve_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 116;
            this.label3.Text = "Dessolve the team";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(312, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 114;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(137, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 24);
            this.label15.TabIndex = 113;
            this.label15.Text = "Team Details";
            // 
            // dgvTeamDetails
            // 
            this.dgvTeamDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamDetails.Location = new System.Drawing.Point(141, 147);
            this.dgvTeamDetails.Name = "dgvTeamDetails";
            this.dgvTeamDetails.Size = new System.Drawing.Size(344, 158);
            this.dgvTeamDetails.TabIndex = 121;
            this.dgvTeamDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeamDetails_CellClick);
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Location = new System.Drawing.Point(138, 85);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(51, 16);
            this.lblTeamName.TabIndex = 122;
            this.lblTeamName.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(221, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 123;
            this.label1.Text = "      ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Team Driver";
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleNo.Location = new System.Drawing.Point(138, 110);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(51, 16);
            this.lblVehicleNo.TabIndex = 124;
            this.lblVehicleNo.Text = "label5";
            // 
            // frmTeamdetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 449);
            this.Controls.Add(this.lblVehicleNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTeamName);
            this.Controls.Add(this.dgvTeamDetails);
            this.Controls.Add(this.btnDissolve);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Name = "frmTeamdetail";
            this.Text = "Team Details";
            this.Load += new System.EventHandler(this.frmTeamdetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDissolve;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvTeamDetails;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVehicleNo;
    }
}