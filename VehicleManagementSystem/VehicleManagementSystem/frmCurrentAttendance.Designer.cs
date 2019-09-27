namespace VehicleManagementSystem
{
    partial class frmCurrentAttendance
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
            this.dgvCureentAttendance = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCurDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCureentAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCureentAttendance
            // 
            this.dgvCureentAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCureentAttendance.Location = new System.Drawing.Point(33, 80);
            this.dgvCureentAttendance.Name = "dgvCureentAttendance";
            this.dgvCureentAttendance.Size = new System.Drawing.Size(560, 672);
            this.dgvCureentAttendance.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(29, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(207, 24);
            this.label15.TabIndex = 76;
            this.label15.Text = "Employee Attendance  ";
            // 
            // lblCurDate
            // 
            this.lblCurDate.AutoSize = true;
            this.lblCurDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurDate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblCurDate.Location = new System.Drawing.Point(257, 41);
            this.lblCurDate.Name = "lblCurDate";
            this.lblCurDate.Size = new System.Drawing.Size(51, 20);
            this.lblCurDate.TabIndex = 77;
            this.lblCurDate.Text = "label1";
            // 
            // frmCurrentAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 781);
            this.Controls.Add(this.lblCurDate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgvCureentAttendance);
            this.Name = "frmCurrentAttendance";
            this.Text = "frmCurrentAttendance";
            this.Load += new System.EventHandler(this.frmCurrentAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCureentAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCureentAttendance;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCurDate;
    }
}