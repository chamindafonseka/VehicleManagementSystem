using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace VehicleManagementSystem
{
    public partial class frmDriver : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int driverid = 0;
        public frmDriver()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cboEmployeeName.Enabled = true;

            if (string.IsNullOrEmpty(cboEmployeeName.Text)) // acept only  numbers  
            {
                MessageBox.Show("Employee name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboEmployeeName.Focus();
            }

            else if (!Regex.Match(txtDLNo.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Driving Licence Number must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDLNo.Focus();
                return;
            }

            else if (!Regex.Match(txtCategories.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Licence Categories must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategories.Focus();
                return;
            }


            else if (string.IsNullOrEmpty(dtpExpiry.Text))
            {
                MessageBox.Show("Date of Ecpiry must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpExpiry.Focus();
            }


            else
            {
                try
                {
                    string qry = "insert into Driver (EmpNo,DLNo,LicenceCategories,DateoOfExpiry,IsDeleted) values (@EmpNo,@DLNo,@LicenceCategories,@DateoOfExpiry,@IsDeleted)";
                    SqlConnection con = new SqlConnection(cs);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@EmpNo", cboEmployeeName.SelectedValue);
                    cmd.Parameters.AddWithValue("@DLNo", this.txtDLNo.Text.ToString());
                    cmd.Parameters.AddWithValue("@LicenceCategories", this.txtCategories.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateoOfExpiry", this.dtpExpiry.Text.Trim());
                    cmd.Parameters.AddWithValue("@IsDeleted", false);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();
                    dgvDriverRefresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               


            }
        }


        private void cleartextboxes()
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


        private void dgvDriverRefresh()
        {

            string qry = "select d.DriverID,e.Name,d.DLNo,d.LicenceCategories,d.DateoOfExpiry,d.IsDeleted from Driver d, Employee e where d.EmpNo = e.EmpNo and isdeleted=0";
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvDriver.DataSource = tbl;
            con.Close();
            dgvDriver.AllowUserToAddRows = false;
            dgvDriver.Columns[0].Width = 70;
            dgvDriver.Columns[2].Width = 90;
            dgvDriver.Columns[1].Width = 200;
            dgvDriver.Columns[3].Width = 200;
            dgvDriver.ClearSelection();

        }

        private void frmDriver_Load(object sender, EventArgs e)
        {
            ComboBoxData();

            dgvDriverRefresh();
            dgvDriver.RowHeadersVisible = false;
            dgvDriver.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(cboEmployeeName.Text)) // acept only  numbers  
            {
                MessageBox.Show("EPF Number must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboEmployeeName.Focus();
            }

            else if (!Regex.Match(txtDLNo.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Driving Licence Number must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDLNo.Focus();
                return;
            }

            else if (!Regex.Match(txtCategories.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Licence Categories must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategories.Focus();
                return;
            }


            else if (string.IsNullOrEmpty(dtpExpiry.Text))
            {
                MessageBox.Show("Date of Ecpiry must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpExpiry.Focus();
            }



            else
            {
                try
                {
                   
                    string qry = "update Driver set  EmpNo=@EmpNo, DLNo=@DLNo, LicenceCategories=@LicenceCategories,DateoOfExpiry=@DateoOfExpiry where DriverID=@DriverID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@DriverID", driverid);
                    cmd.Parameters.AddWithValue("@EmpNo", cboEmployeeName.SelectedValue);
                    cmd.Parameters.AddWithValue("@DLNo", txtDLNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@LicenceCategories", txtCategories.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateoOfExpiry",dtpExpiry.Text);

                     
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvDriverRefresh();
                    cleartextboxes();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,"exception");
                }

            }

        }

        private void dgvDriver_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            try
            {
                DataGridViewRow dgvRow = dgvDriver.Rows[e.RowIndex];

                driverid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtDriverID.Text = dgvRow.Cells[0].Value.ToString();
                cboEmployeeName.Text = dgvRow.Cells[1].Value.ToString();
                txtDLNo.Text = dgvRow.Cells[2].Value.ToString();
                txtCategories.Text = dgvRow.Cells[3].Value.ToString();
                dtpExpiry.Text = dgvRow.Cells[4].Value.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please enter a DriverID.  " + ex.Message);
            }
        }

        private void ComboBoxData()
        {
           

            SqlConnection con = new SqlConnection(cs);
            string qry = "select EmpNo, Name from Employee  where EmpNo not in (select d.EmpNo from Driver d) order by name";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboEmployeeName.DataSource = ds.Tables[0];
            cboEmployeeName.DisplayMember = "Name";
            cboEmployeeName.ValueMember = "EmpNo";
            cboEmployeeName.Enabled = true;
            cboEmployeeName.SelectedItem = null;
            con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvDriverRefresh();
            cleartextboxes();
            cboEmployeeName.Focus();
            cboEmployeeName.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "update Driver set  IsDeleted = @IsDeleted  where DriverID = @DriverID ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@DriverID", driverid);
                cmd.Parameters.AddWithValue("@IsDeleted", true);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been removed successfully.. ", "Delete records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvDriverRefresh();
                cleartextboxes();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
