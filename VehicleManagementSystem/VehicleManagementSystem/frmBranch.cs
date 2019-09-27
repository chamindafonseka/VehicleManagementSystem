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
using System.Security.Cryptography;
using System.IO;
 

namespace VehicleManagementSystem
{
    public partial class frmBranch : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int brnachid = 0;  //  for dgvBranch_CellClick()
        public frmBranch()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtBranchName.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Branch Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBranchName.Focus();
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

            else if (!Regex.Match(txtBranchManager.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Branch Manager Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBranchManager.Focus();
                return;
            }

            else if(!IsValidEmail(txtEmail.Text.ToString()))
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (!Regex.Match(txtFax.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Fax Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }



            else
            {
                string qry = "insert into Branch (BranchName,Address,ContactNo,BranchManager,Email,Fax,Deleted) values (@BranchName,@Address,@ContactNo,@BranchManager,@Email,@Fax,@Deleted)";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@BranchName", this.txtBranchName.Text.Trim());
                        //cmd.Parameters.AddWithValue("@RegDate", this.dtpDateReg.Value.ToString("MM/dd/yyyy").Trim());
                        cmd.Parameters.AddWithValue("@Address", this.txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNo", this.txtContactNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@BranchManager", this.txtBranchManager.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fax", this.txtFax.Text.Trim());
                        cmd.Parameters.AddWithValue("@Deleted",0);


                        int k = cmd.ExecuteNonQuery();
                        if (k > 0)
                        {
                            MessageBox.Show("Saved sucessfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Falied to save data ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        dgvBranchRefresh();
                    }
                }      
            }
 
            txtBranchName.Text = txtAddress.Text = txtBranchManager.Text = txtContactNo.Text = txtEmail.Text = txtFax.Text = string.Empty;
            
        }

        //Instead of using a regular expression to validate an email address, we can use the System.Net.Mail.MailAddress class. To determine whether an email address is valid, pass the email address to the MailAddress.MailAddress(String) class constructor.
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





        private void frmBranch_Load(object sender, EventArgs e)
        {

            dgvBranchRefresh();
            dgvBranch.RowHeadersVisible = false;



        }

        private void dgvBranchRefresh()
        {
            

            string qry = "select BranchID, BranchName,Address,ContactNo,BranchManager,Email,Fax from Branch where deleted=0";    
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvBranch.DataSource = tbl;
            con.Close();
            dgvBranch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBranch.AllowUserToAddRows = false;
            dgvBranch.ClearSelection();

        }

        private void dgvBranch_CellClick(object sender, DataGridViewCellEventArgs e)   // grid cell click and load relavant data into text boxes 
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    btnUpdate.Enabled = true;

                    DataGridViewRow dgvRow = dgvBranch.Rows[e.RowIndex];

                    brnachid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString()); // how i extract Branchid for sql queries, it should be a public int
                    txtBranchID.Text = dgvRow.Cells[0].Value.ToString();
                    txtBranchName.Text = dgvRow.Cells[1].Value.ToString();
                    txtAddress.Text = dgvRow.Cells[2].Value.ToString();
                    txtContactNo.Text = dgvRow.Cells[3].Value.ToString();
                    txtBranchManager.Text = dgvRow.Cells[4].Value.ToString();
                    txtEmail.Text = dgvRow.Cells[5].Value.ToString();
                    txtFax.Text = dgvRow.Cells[6].Value.ToString();
                }

                btnSave.Enabled = false;
                btnUpdate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select BranchID. " +ex.Message);
            }

           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtBranchName.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Branch Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBranchName.Focus();
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

            else if (!Regex.Match(txtBranchManager.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Branch Manager Name must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBranchManager.Focus();
                return;
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else if (!Regex.Match(txtFax.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Fax Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }

            else
            {
                string qry = " update Branch set BranchName = @BranchName ,  Address=@Address, ContactNo=@ContactNo, BranchManager=@BranchManager , Email=@Email, Fax=@Fax where   BranchID  = @BranchID  ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@BranchID", brnachid);
                cmd.Parameters.AddWithValue("@BranchName", this.txtBranchName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", this.txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", this.txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@BranchManager", this.txtBranchManager.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Fax", this.txtFax.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();
                dgvBranchRefresh();

                MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBranchName.Text = txtAddress.Text = txtBranchManager.Text = txtContactNo.Text = txtEmail.Text = txtFax.Text = string.Empty;

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }
            
        }


        private void btnNew_Click(object sender, EventArgs e)
        {

            txtBranchName.Text = txtAddress.Text = txtBranchManager.Text = txtContactNo.Text = txtEmail.Text = txtFax.Text = string.Empty;
            txtBranchName.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Want to delete ?","delete", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                string qry = " update Branch set Deleted = @Deleted where   BranchID  = @BranchID  ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@BranchID", brnachid);
                cmd.Parameters.AddWithValue("@Deleted",1);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvBranchRefresh();
                txtBranchName.Text = txtAddress.Text = txtBranchManager.Text = txtContactNo.Text = txtEmail.Text = txtFax.Text = string.Empty;

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }


            
        }

      
    }
}
