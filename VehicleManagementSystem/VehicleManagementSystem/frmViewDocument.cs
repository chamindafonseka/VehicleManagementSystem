using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;



namespace VehicleManagementSystem
{
    public partial class frmViewDocument : Form
    {
        public frmViewDocument()
        {
            InitializeComponent();
        }

        private void frmViewDocument_Load(object sender, EventArgs e)
        {
             


            if ( string.IsNullOrEmpty(frmDocumentStore.filename))
            {
                MessageBox.Show("You haven't selected a document. \n Please select a Document for view.", "Select Document", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            else
            {
                pbViewDocument.Image = new Bitmap(frmDocumentStore.filename.ToString().Trim());
                pbViewDocument.SizeMode = PictureBoxSizeMode.StretchImage;
                
            }

           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPage;
                pd.Print();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Printer is not available. \n"+    ex.Message);
            }

            

        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(frmDocumentStore.filename.ToString().Trim());
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(img, loc);
        }





    }
}
