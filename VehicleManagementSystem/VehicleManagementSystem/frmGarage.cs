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
    public partial class frmGarage : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int gid = 0;

        public frmGarage()
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
                string qry = "insert into Garage (Name,Address,ContactNo,ContactPerson,Email,Fax,Deleted) values (@Name,@Address,@ContactNo,@ContactPerson,@Email,@Fax,@Deleted)";

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
                        cmd.Parameters.AddWithValue("@Deleted",0);

                        int k = cmd.ExecuteNonQuery();
                        con.Close();
                        dgvGaragefresh();
                        if (k > 0)
                        {
                            MessageBox.Show("Record added sucessfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtGID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Failed to added the record.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
        }


        public void dgvGaragefresh()
        {
            string qry = "select GID, Name, Address, ContactNo, ContactPerson, Email, Fax from Garage where Deleted =0";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvGarage.DataSource = tbl;
            con.Close();
            dgvGarage.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGarage.AllowUserToAddRows = false;
            dgvGarage.ClearSelection();
            dgvGarage.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvGarage.EnableHeadersVisualStyles = false;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtGID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = string.Empty;
        }

        private void frmGarage_Load(object sender, EventArgs e)
        {
            dgvGaragefresh();
            dgvGarage.RowHeadersVisible = false;
        }

        private void dgvGarage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    btnUpdate.Enabled = true;
                    DataGridViewRow dgvRow = dgvGarage.Rows[e.RowIndex];

                    gid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString()); // how i extract SCID for sql queries, it should be a public int
                    txtGID.Text = dgvRow.Cells[0].Value.ToString();
                    txtName.Text = dgvRow.Cells[1].Value.ToString();
                    txtAddress.Text = dgvRow.Cells[2].Value.ToString();
                    txtContactNo.Text = dgvRow.Cells[3].Value.ToString();
                    txtContactPerson.Text = dgvRow.Cells[4].Value.ToString();
                    txtEmail.Text = dgvRow.Cells[5].Value.ToString();
                    txtFax.Text = dgvRow.Cells[6].Value.ToString();
                }

                btnSave.Enabled = false;
                btnUpdate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select BranchID. " + ex.Message, "Select GID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtName.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Name must not be empty or \nEntered value is not valid.", "Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            if (!Regex.Match(txtAddress.Text, "^[a-zA-Z0-9]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Address must not be empty or \nEntered value is not valid.", "Address.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!Regex.Match(txtContactNo.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Phone Number must not be empty or \nEntered value is not valid. ", "Contact No", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }

            else if (!Regex.Match(txtContactPerson.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Contact Person Name must not be empty or \nEntered value is not valid.", "Cont Person.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactPerson.Focus();
                return;
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))  //if enter the email it will validate , otherwise keep the null
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Email.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            else if (!Regex.Match(txtFax.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Fax Number must not be empty or \nEntered value is not valid. ", "Fax Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFax.Focus();
                return;
            }

            else
            {
                string qry = " update Garage set Name = @Name ,  Address=@Address, ContactNo=@ContactNo, ContactPerson=@ContactPerson , Email=@Email, Fax=@Fax where   GID  = @GID  ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@GID", gid);
                cmd.Parameters.AddWithValue("@Name", this.txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", this.txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", this.txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactPerson", this.txtContactPerson.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Fax", this.txtFax.Text.Trim());
                cmd.Parameters.AddWithValue("@Deleted",0);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvGaragefresh();

                MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtGID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = string.Empty;

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string qry = " Update Garage set Deleted=@Deleted where  GID  = @GID  ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@GID", gid);
                cmd.Parameters.AddWithValue("@Deleted",1);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvGaragefresh();
                MessageBox.Show("Record has been deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGID.Text = txtName.Text = txtAddress.Text = txtContactNo.Text = txtContactPerson.Text = txtEmail.Text = txtFax.Text = string.Empty;

            }
        }
    }
}
