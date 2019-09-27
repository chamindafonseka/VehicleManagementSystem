namespace VehicleManagementSystem
{
    partial class frmViewDocument
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
            this.pbViewDocument = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // pbViewDocument
            // 
            this.pbViewDocument.Location = new System.Drawing.Point(13, 64);
            this.pbViewDocument.Name = "pbViewDocument";
            this.pbViewDocument.Size = new System.Drawing.Size(429, 577);
            this.pbViewDocument.TabIndex = 0;
            this.pbViewDocument.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(377, 35);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmViewDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 660);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pbViewDocument);
            this.Name = "frmViewDocument";
            this.Text = "frmViewDocument";
            this.Load += new System.EventHandler(this.frmViewDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbViewDocument)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbViewDocument;
        private System.Windows.Forms.Button btnPrint;
    }
}