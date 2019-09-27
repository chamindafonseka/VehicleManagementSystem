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
    public partial class frmSupplier : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = vmsuser; Password = 890";
        public int supid = 0;
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {

            dgvSupplierRefresh();

        }

        private void dgvSupplierRefresh()
        {
            string qry = "select * from Supplier where deleted=0";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvSupplier.DataSource = tbl;
            con.Close();
            dgvSupplier.AllowUserToAddRows = false;
            dgvSupplier.ClearSelection();
            dgvSupplier.RowHeadersVisible = false;
            dgvSupplier.Columns[0].Width = 60;
            dgvSupplier.Columns[1].Width = 120;
            dgvSupplier.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            btnSave.Enabled = true;

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

        private void clearTextboxes()
        {
            foreach (Control b in this.Controls)
            {
                if (b is TextBox)                       // clear all the text boxes i the form.
                {
                    ((TextBox)b).Text = string.Empty;
                }
            }
            foreach (Control a in this.Controls)
            {
                if (a is ComboBox)                       // clear all the text boxes i the form.
                {
                    ((ComboBox)a).Text = string.Empty;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtName.Text, "^[a-zA-Z0-9-d]").Success)  
            {
                MessageBox.Show("Supplier name must not be empty or \nEntered value is not valid.", "Supplier name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            else if (!Regex.Match(txtAddress.Text, "^[a-zA-Z0-9-d]").Success)  
            {
                MessageBox.Show("Address must not be empty or \nEntered value is not valid.", "Address ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!Regex.Match(txtContactNo.Text, "^[0-9]{10}").Success)
            {
                MessageBox.Show("Contact number  must not be empty or \nEntered value is not valid.", "Contact number ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))  //if enter the email it will validate , otherwise keep the null
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;                
            }
            else
            {
                string qry = "insert into   Supplier (Name, Address, ContactPerson, ContactNo, Email, Deleted) values (@Name, @Address, @ContactPerson, @ContactNo, @Email, @Deleted)";
                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@Name",txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address",txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactPerson",txtContactPerson.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Email",txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Deleted", 0);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTextboxes();

                dgvSupplierRefresh();

            }

        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvSupplier.Rows[e.RowIndex];

                supid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtSupplierID.Text = dgvRow.Cells[0].Value.ToString();
                txtName.Text = dgvRow.Cells[1].Value.ToString();
                txtAddress.Text = dgvRow.Cells[2].Value.ToString();
                txtContactPerson.Text =  dgvRow.Cells[3].Value.ToString();
                txtContactNo.Text = dgvRow.Cells[4].Value.ToString();
                txtEmail.Text= dgvRow.Cells[5].Value.ToString();

                btnSave.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please select  SupplierID.  " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtName.Text, "^[a-zA-Z0-9-d]").Success)
            {
                MessageBox.Show("Supplier name must not be empty or \nEntered value is not valid.", "Supplier name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            else if (!Regex.Match(txtAddress.Text, "^[a-zA-Z0-9-d]").Success)
            {
                MessageBox.Show("Address must not be empty or \nEntered value is not valid.", "Address ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!Regex.Match(txtContactNo.Text, "^[0-9]{10}").Success)
            {
                MessageBox.Show("Contact number  must not be empty or \nEntered value is not valid.", "Contact number ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!Regex.Match(txtContactPerson.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Contact Person must not be empty or \nEntered value is not valid.", "Address ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))  //if enter the email it will validate , otherwise keep the null
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            else
            {
                try
                {
                    string qry = " update Supplier set Name=@Name, Address=@Address, ContactPerson=@ContactPerson, ContactNo=@ContactNo, Email=@Email  where SupID = @SupID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@SupID", supid);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email",txtEmail.Text.Trim());


                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvSupplierRefresh();
                    clearTextboxes();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearTextboxes();
            dgvSupplierRefresh(); 
                btnSave.Enabled = false;
        }

        private void brnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                
                try
                {
                    string qry = " update Supplier set Deleted=@Deleted where SupID = @SupID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@SupID ", supid);
                    cmd.Parameters.AddWithValue("@Deleted", 1);

                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been removed successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSupplierRefresh();
                    clearTextboxes();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    
}
