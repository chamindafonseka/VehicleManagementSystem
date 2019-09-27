namespace VehicleManagementSystem
{
    partial class frmUserRights
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
            this.dgvUserRights = new System.Windows.Forms.DataGridView();
            this.UserRight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.lstUserName = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUserNameDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRights)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserRights
            // 
            this.dgvUserRights.AllowUserToAddRows = false;
            this.dgvUserRights.AllowUserToDeleteRows = false;
            this.dgvUserRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserRights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserRight});
            this.dgvUserRights.Location = new System.Drawing.Point(309, 147);
            this.dgvUserRights.Name = "dgvUserRights";
            this.dgvUserRights.Size = new System.Drawing.Size(428, 485);
            this.dgvUserRights.TabIndex = 0;
            this.dgvUserRights.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserRights_CellContentClick);
            // 
            // UserRight
            // 
            this.UserRight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.NullValue = false;
            this.UserRight.DefaultCellStyle = dataGridViewCellStyle1;
            this.UserRight.HeaderText = "UserRight";
            this.UserRight.Name = "UserRight";
            this.UserRight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserRight.Width = 60;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(30, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 24);
            this.label15.TabIndex = 95;
            this.label15.Text = "User Rights ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "User Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "Full Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Password :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(413, 39);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(151, 20);
            this.txtUserName.TabIndex = 98;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(413, 72);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(324, 20);
            this.txtFullName.TabIndex = 98;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(413, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(151, 20);
            this.txtPassword.TabIndex = 98;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(570, 37);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(79, 23);
            this.btnNewUser.TabIndex = 99;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(569, 105);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(79, 23);
            this.btnChange.TabIndex = 99;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lstUserName
            // 
            this.lstUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUserName.FormattingEnabled = true;
            this.lstUserName.ItemHeight = 15;
            this.lstUserName.Location = new System.Drawing.Point(29, 73);
            this.lstUserName.MultiColumn = true;
            this.lstUserName.Name = "lstUserName";
            this.lstUserName.Size = new System.Drawing.Size(256, 559);
            this.lstUserName.TabIndex = 100;
            this.lstUserName.Click += new System.EventHandler(this.lstUserName_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(639, 639);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUserNameDisplay
            // 
            this.lblUserNameDisplay.AutoSize = true;
            this.lblUserNameDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameDisplay.ForeColor = System.Drawing.Color.Salmon;
            this.lblUserNameDisplay.Location = new System.Drawing.Point(326, 9);
            this.lblUserNameDisplay.Name = "lblUserNameDisplay";
            this.lblUserNameDisplay.Size = new System.Drawing.Size(16, 17);
            this.lblUserNameDisplay.TabIndex = 101;
            this.lblUserNameDisplay.Text = "..";
            // 
            // frmUserRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 674);
            this.Controls.Add(this.lblUserNameDisplay);
            this.Controls.Add(this.lstUserName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgvUserRights);
            this.Name = "frmUserRights";
            this.Text = "User Rights";
            this.Load += new System.EventHandler(this.frmUserRights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserRights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserRights;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UserRight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ListBox lstUserName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserNameDisplay;
    }
}