using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


namespace VehicleManagementSystem
{
    public partial class frmDocumentStore : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public static string filename = String.Empty;
        private string fname = String.Empty;
        int docid = 0;
        public frmDocumentStore()
        {
            InitializeComponent();
        }

        private void btnSelectDoc_Click(object sender, EventArgs e)
        {
            txtDocID.Text = cbovehicleNo.Text = cboDocumentType.Text = lblDetinationPath.Text = lblSourcePath.Text = string.Empty;
            // open file dialog   
            OpenFileDialog opnfd = new OpenFileDialog();
            // image filters  
            opnfd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pbDocumentStore.Image = new Bitmap(opnfd.FileName);
                // destination file path  
                
                lblSourcePath.Text = opnfd.FileName; // source file path

                fname = Path.GetFileName(opnfd.FileName); //extract file name only with extension 
                lblDetinationPath.Text = @"H:\MIT\Regain\VehicleManagementSystem\DocStore\" + fname;
                filename = opnfd.FileName;   // destination full file path with the file name
                pbDocumentStore.SizeMode = PictureBoxSizeMode.StretchImage;
                
                
                MessageBox.Show(fname, "Selected file name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbovehicleNo.Focus();
                return; 

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string destinationFile = @"H:\MIT\Regain\Project VMS\VehicleManagementSystem\DocStore\" + fname;
            string path = @"H:\MIT\Regain\Project VMS\VehicleManagementSystem\DocStore\";

            //MessageBox.Show(destinationFile);

           if ( pbDocumentStore == null || pbDocumentStore.Image==null)
            {
                MessageBox.Show("Picture box must not be empty .", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSelectDoc.Focus();
                return;
            }


           else if (!Regex.Match(cbovehicleNo.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Vehicle No. must not be empty or \nEntered value is not valid.", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbovehicleNo.Focus();
                return;
            }

            else if (!Regex.Match(cboDocumentType.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Document Type must not be empty or \nEntered value is not valid.", "Doc Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDocumentType.Focus();
                return;
            }
           

            else
            {
                try
                {
                    File.Copy(filename, destinationFile, true);  // file copy

                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string qry = "insert into DocumentStore (VID,DocTypeID,FilePath,Expired,SavedDate ) values (@VID,@DocTypeID,@FilePath,@Expired,@SavedDate)";
                    SqlCommand cmd = new SqlCommand(qry,con);
                    cmd.Parameters.AddWithValue("@VID", cbovehicleNo.SelectedValue);
                    cmd.Parameters.AddWithValue("@DocTypeID", cboDocumentType.SelectedValue);
                    cmd.Parameters.AddWithValue("@FilePath", destinationFile);
                    cmd.Parameters.AddWithValue("@Expired", 0);
                    cmd.Parameters.AddWithValue("@SavedDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(fname + " Saved successfully into "+ path, "Save File");

                    pbDocumentStore.Image.Dispose();
                    pbDocumentStore.Image = null;

                    cboDocumentType.Text = cbovehicleNo.Text = lblDetinationPath.Text = lblSourcePath.Text   = string.Empty;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                dgvDocumentStoreRefresh();
            }
        }


        public void BindData()  // load data into combo box
        {
            //documets type combo box
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string qry = "SELECT DocTypeID , Name FROM  DocumentType order by name ";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboDocumentType.DataSource = ds.Tables[0];
            cboDocumentType.DisplayMember = "Name";
            cboDocumentType.ValueMember = "DocTypeID";
            cboDocumentType.Enabled = true;
            cboDocumentType.SelectedItem = null;

            //vehicle number combo box
            
            string qry2 = "select VID, RegistrationNo from Vehicle where  status not like 'Retired%' order by RegistrationNo";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            cbovehicleNo.DataSource = ds2.Tables[0];
            cbovehicleNo.DisplayMember = "RegistrationNo";
            cbovehicleNo.ValueMember = "VID";
            cbovehicleNo.Enabled = true;
            cbovehicleNo.SelectedItem = null;

            //combo search >> vehicle numbers
            string qry3 = "select VID, RegistrationNo from Vehicle where  status not like 'Retired%'  order by RegistrationNo";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(qry3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            cboSearch.DataSource = ds2.Tables[0];
            cboSearch.DisplayMember = "RegistrationNo";
            cboSearch.ValueMember = "VID";
            cboSearch.Enabled = true;
            cboSearch.SelectedItem = null;





            con.Close();
        }

        private void frmDocumentStore_Load(object sender, EventArgs e)
        {
            dgvDocumentStore.AllowUserToAddRows = false;
           
            BindData();
            dgvDocumentStoreRefresh();


        }

        private void dgvDocumentStoreRefresh()
        {
            string qry = "select d.DocID, v.RegistrationNo,dt.Name,d.FilePath,d.Expired,d.SavedDate from DocumentStore d, Vehicle v , DocumentType dt where d.VID = v.VID and d.DocTypeID = dt.DocTypeID order by d.DocID";

            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvDocumentStore.DataSource = tbl;
            con.Close();
            dgvDocumentStore.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDocumentStore.RowHeadersVisible = false;

            dgvDocumentStore.AllowUserToAddRows = false;
            dgvDocumentStore.ClearSelection();


        }

        private void dgvDocumentStore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvDocumentStore.Rows[e.RowIndex];

                docid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtDocID.Text = dgvRow.Cells[0].Value.ToString();
                cbovehicleNo.Text = dgvRow.Cells[1].Value.ToString();
                cboDocumentType.Text = dgvRow.Cells[2].Value.ToString();
                lblDetinationPath.Text = dgvRow.Cells[3].Value.ToString();

                pbDocumentStore.Image = Image.FromFile(dgvRow.Cells[3].Value.ToString());
                pbDocumentStore.SizeMode = PictureBoxSizeMode.StretchImage;

                filename = lblDetinationPath.Text.Trim();



            }

            catch (Exception ex)
            {
                MessageBox.Show("Please select a Document ID. \n " + ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmViewDocument")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmViewDocument f = new frmViewDocument();
                f.Show();
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtDocID.Text = cbovehicleNo.Text = cboDocumentType.Text = lblDetinationPath.Text = lblSourcePath.Text = string.Empty;
            pbDocumentStore.Image = null;
            filename = string.Empty;
            fname = string.Empty;
            docid = 0;
            dgvDocumentStoreRefresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(cbovehicleNo.Text, "^[a-zA-Z]").Success) 
            {
                MessageBox.Show("Vehicle No. must not be empty or \nEntered value is not valid.", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbovehicleNo.Focus();
            }

            else if (!Regex.Match(cboDocumentType.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Document type must not be empty or \nEntered value is not valid.", "Document Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDocumentType.Focus();
            }

            else
            {
                try
                {
                    string qry = " update DocumentStore set   VID = @VID , DocTypeID = @DocTypeID, FilePath = @FilePath, Expired=@Expired   where DocID = @DocID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@DocID", docid.ToString());
                    cmd.Parameters.AddWithValue("@VID",cbovehicleNo.SelectedValue);
                    cmd.Parameters.AddWithValue("@DocTypeID",cboDocumentType.SelectedValue);
                    cmd.Parameters.AddWithValue("@FilePath", lblDetinationPath.Text);
                    cmd.Parameters.AddWithValue("@Expired",0);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvDocumentStoreRefresh();
                    txtDocID.Text = cbovehicleNo.Text = cboDocumentType.Text = lblDetinationPath.Text = lblSourcePath.Text = string.Empty;
                    pbDocumentStore.Image = null;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete the record ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                string qry = " delete from DocumentStore where   DocID  = @DocID  ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@DocID",docid);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvDocumentStoreRefresh();
                MessageBox.Show("Selected Record has been deleted. ", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //clear controls
                txtDocID.Text = cboDocumentType.Text = cbovehicleNo.Text = lblDetinationPath.Text = string.Empty;
                pbDocumentStore.Image = null;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string qry = "select * from DocumentStore where VID = @VID ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@VID", cboSearch.SelectedValue.ToString());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();
            da.Fill(tbl);

            dgvDocumentStore.DataSource = tbl;
            con.Close();
        }
    }
}
