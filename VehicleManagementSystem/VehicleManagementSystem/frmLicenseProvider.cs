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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace VehicleManagementSystem
{
    public partial class frmLicenseProvider : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int lpid = 0;
        public frmLicenseProvider()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtName.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            if (!Regex.Match(txtAddress.Text, "^[a-zA-Z0-9]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!Regex.Match(txtContactNo.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Phone Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }

            else if (!Regex.Match(txtContactPerson.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Contact Person Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactPerson.Focus();
                return;
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))  //if enter the email it will validate , otherwise keep the null
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            else if (!Regex.Match(txtFax.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Fax Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFax.Focus();
                return;
            }


            else
            {
                string qry = "insert into LicenseProvider (Name,Address,ContactNo,ContactPerson,Email,Fax,DocumentType) values (@Name,@Address,@ContactNo,@ContactPerson,@Email,@Fax,@DocumentType)";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Name", this.txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", this.txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNo", this.txtContactNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactPerson", this.txtContactPerson.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fax", this.txtFax.Text.Trim());
                        cmd.Parameters.AddWithValue("@DocumentType", this.cboDocumentType.Text.Trim());

                        int k = cmd.ExecuteNonQuery();
                        con.Close();
                        dgvLicenseProviderRefresh();


                        if (k > 0)
                        {
                            MessageBox.Show("Record added sucessfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtLPID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Failed to added the record.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }







        }

        public bool IsValidEmail(string emailaddress)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                try
                {
                    MailAddress m = new MailAddress(emailaddress);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        private void dgvLicenseProviderRefresh()
        {
            string qry = "select * from LicenseProvider";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvLicenseProvider.DataSource = tbl;
            con.Close();
            dgvLicenseProvider.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLicenseProvider.AllowUserToAddRows = false;
            dgvLicenseProvider.ClearSelection();

        }

        private void dgvLicenseProvider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    btnUpdate.Enabled = true;
                    DataGridViewRow dgvRow = dgvLicenseProvider.Rows[e.RowIndex];

                    lpid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString()); // how i extract SCID for sql queries, it should be a public int
                    txtLPID.Text = dgvRow.Cells[0].Value.ToString();
                    txtName.Text = dgvRow.Cells[1].Value.ToString();
                    txtAddress.Text = dgvRow.Cells[2].Value.ToString();
                    txtContactNo.Text = dgvRow.Cells[3].Value.ToString();
                    txtContactPerson.Text = dgvRow.Cells[4].Value.ToString();
                    txtEmail.Text = dgvRow.Cells[5].Value.ToString();
                    txtFax.Text = dgvRow.Cells[6].Value.ToString();
                    cboDocumentType.Text = dgvRow.Cells[7].Value.ToString();
                }

                btnSave.Enabled = false;
                btnUpdate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select LPID. " + ex.Message);
            }
        }

        private void frmLicenseProvider_Load(object sender, EventArgs e)
        {

            dgvLicenseProviderRefresh();
            dgvLicenseProvider.RowHeadersVisible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtName.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            if (!Regex.Match(txtAddress.Text, "^[a-zA-Z0-9]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!Regex.Match(txtContactNo.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Phone Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }

            else if (!Regex.Match(txtContactPerson.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Contact Person Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactPerson.Focus();
                return;
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))  //if enter the email it will validate , otherwise keep the null
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            else if (!Regex.Match(txtFax.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Fax Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFax.Focus();
                return;
            }


            else
            {
                string qry = " update LicenseProvider set Name = @Name ,  Address=@Address, ContactNo=@ContactNo, ContactPerson=@ContactPerson , Email=@Email, Fax=@Fax, DocumentType=@DocumentType  where   LPID = @LPID  ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@LPID", lpid);
                cmd.Parameters.AddWithValue("@Name", this.txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", this.txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", this.txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactPerson", this.txtContactPerson.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Fax", this.txtFax.Text.Trim());
                cmd.Parameters.AddWithValue("@DocumentType", this.cboDocumentType.Text.Trim());
                cmd.ExecuteNonQuery();

                con.Close();
                dgvLicenseProviderRefresh();

                MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtLPID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = string.Empty;

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtLPID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = string.Empty;
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string qry = " delete from LicenseProvider where   LPID  = @LPID  ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@LPID", lpid);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvLicenseProviderRefresh();
                MessageBox.Show("Record has been deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLPID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = cboDocumentType.Text =      string.Empty;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
