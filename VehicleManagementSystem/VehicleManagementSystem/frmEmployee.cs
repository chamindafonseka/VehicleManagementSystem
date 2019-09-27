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
    public partial class frmRegEmployee : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int empid = 0;
        public frmRegEmployee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {          
            DateTime DoB = new DateTime();

            if (dtpDoB.Text == string.Empty)
            {
                dtpDoB.Value = DateTime.Now;
            }
                        
            DoB = Convert.ToDateTime(dtpDoB.Value);
            DateTime CDate = new DateTime();
            CDate = DateTime.Now;
            int y = CDate.Year - DoB.Year;  //this part need for DoB validation

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, @"[a-zA-Z]")) // acept only letters
            {
                MessageBox.Show("Employee Name must not be empty or \nPlease enter valid Name..", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                txtName.Text = string.Empty;
                return;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtContactNo.Text, @"[0-9]{10}")    )
            {
                MessageBox.Show("Contact Number must not be empty or \nPlease enter valid Number..", "Contact Number.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            } 

            else if (String.IsNullOrEmpty(txtAddress.Text))
            { 
                MessageBox.Show("Address must not be empty or \nPlease enter valid Address..", "Address.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }

            else if (y < 17 || String.IsNullOrEmpty(dtpDoB.Text)) //txtDoB validation
            {

                MessageBox.Show("Under age employee ? / Check the DoB. Employee age: " + y.ToString(), "DoB.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpDoB.Value = DateTime.Now;
                dtpDoB.Focus();
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtNIC.Text, @"[A-Z0-9]"))
            {
                MessageBox.Show("NIC Number must not be empty or \nPlease enter valid NIC Number..", "Address.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNIC.Focus();
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))  //if enter the email it will validate , otherwise keep the null
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            else
            {
                try
                {
                    string qry = "insert into Employee (Name,ContactNo,ResidentialAddress,DoB,NIC,  EPFNo,Sex,CivilStatus,Email,SpouseName,SpouseContactNo,Status,IsAllocated) values (@Name,@ContactNo,@ResidentialAddress,@DoB,@NIC , @EPFNo,@Sex,@CivilStatus,@Email,@SpouseName,@SpouseContactNo,@Status,@IsAllocated)";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@Name", this.txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNo", this.txtContactNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ResidentialAddress", this.txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@DoB", this.dtpDoB.Value.ToString("MM/dd/yyyy").Trim());
                    cmd.Parameters.AddWithValue("@NIC", this.txtNIC.Text.Trim());
                    cmd.Parameters.AddWithValue("@EPFNo", this.txtEPFNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sex", this.cboSex.Text.Trim());
                    cmd.Parameters.AddWithValue("@CivilStatus", this.cboCivilStatus.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", this.txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@SpouseName", this.txtSpouseName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SpouseContactNo", this.txtSpouseContactNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", this.cboStatus.Text.Trim());
                    cmd.Parameters.AddWithValue("@IsAllocated", this.cboTeamAllocated.Text.Trim());

                    cmd.ExecuteNonQuery();

                    con.Close();

                    DialogResult result = MessageBox.Show("Do you want to save the data ?", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Focus();
                        dgvEmployeeRefresh();
                        cleartextboxes();

                        dtpDoB.Value = DateTime.Now;
                     }
                    else
                    {
                        txtName.Focus();
                    } 
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
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

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvEmployee.RowHeadersVisible = false;
                DataGridViewRow dgvRow = dgvEmployee.Rows[e.RowIndex];

                empid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtEmpNo.Text = dgvRow.Cells[0].Value.ToString();

                txtName.Text = dgvRow.Cells[1].Value.ToString();
                txtContactNo.Text = dgvRow.Cells[2].Value.ToString();
                txtAddress.Text = dgvRow.Cells[3].Value.ToString();
                dtpDoB.Text = dgvRow.Cells[4].Value.ToString();
                txtNIC.Text = dgvRow.Cells[5].Value.ToString();
                txtEPFNo.Text = dgvRow.Cells[6].Value.ToString();
                cboSex.Text = dgvRow.Cells[7].Value.ToString();
                cboCivilStatus.Text = dgvRow.Cells[8].Value.ToString();
                txtEmail.Text = dgvRow.Cells[9].Value.ToString();
                txtSpouseName.Text = dgvRow.Cells[10].Value.ToString();
                txtSpouseContactNo.Text = dgvRow.Cells[11].Value.ToString();

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a EmpNo "+ ex.Message);
            }
           
        }

        private void dgvEmployeeRefresh()
        {
            string qry = "select * from Employee";
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvEmployee.DataSource = tbl;
            con.Close();

            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.ClearSelection();

        }

        private void frmRegEmployee_Load(object sender, EventArgs e)
        {
            dgvEmployee.AllowUserToAddRows = false;

            //retrieve value from ComboBox 
            DataTable dt = new DataTable();
            dt.Columns.Add("value");
            dt.Columns.Add("name");
            dt.Rows.Add(0, "Vacated");
            dt.Rows.Add(1, "Active");

            cboStatus.DataSource = dt;
            cboStatus.DisplayMember = "name";
            cboStatus.ValueMember = "value";


            cleartextboxes();
            dgvEmployeeRefresh();
            dgvEmployee.RowHeadersVisible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cleartextboxes();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string qry = " delete from Employee where   EmpNo  = @EmpNo  ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@EmpNo", empid);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvEmployeeRefresh();

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;

                //clear all textboxes
                cleartextboxes();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime DoB = new DateTime();
            if (dtpDoB.Text == string.Empty)
                {
                    dtpDoB.Value = DateTime.Now;
                }
            DoB = Convert.ToDateTime(dtpDoB.Value);
            DateTime CDate = new DateTime();
            CDate = DateTime.Now;
            int y = CDate.Year - DoB.Year;

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, @"[a-zA-Z]")) // acept only letters
            {
                MessageBox.Show("Employee Name must not be empty or \nPlease enter valid Name..", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                txtName.Text = string.Empty;
                return;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtContactNo.Text, @"[0-9]{10}"))
            {
                MessageBox.Show("Contact Number must not be empty or \nPlease enter valid Number..", "Contact Number.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Address must not be empty or \nPlease enter valid Address..", "Address.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }


            else if (y < 17 || String.IsNullOrEmpty(dtpDoB.Text)) //txtDoB validation
            {

                MessageBox.Show("Under age employee ? / Check the DoB. Employee age: " + y.ToString(), "DoB.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpDoB.Value = DateTime.Now;
                dtpDoB.Focus();
                return;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtNIC.Text, @"[A-Z0-9]"))
            {
                MessageBox.Show("NIC Number must not be empty or \nPlease enter valid NIC Number..", "NIC.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNIC.Focus();
                return;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtEPFNo.Text, @"[0-9]"))
            {
                MessageBox.Show("EPF Number must not be empty or \nPlease enter valid NIC Number..", "EPF.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNIC.Focus();
                return;
            }

            else if (!IsValidEmail(txtEmail.Text.ToString()))  //if enter the email it will validate , otherwise keep the null
            {
                MessageBox.Show("Email address must not be empty or \nEntered value is not valid.", "Branch Name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            else
            {
               
                    if (!String.IsNullOrEmpty(txtEmpNo.Text))
                    {
                        string qry = " update Employee set   Name = @Name , ContactNo = @ContactNo , ResidentialAddress = @ResidentialAddress , DoB = @DoB , NIC = @NIC  ,EPFNo = @EPFNo , Sex = @Sex , CivilStatus = @CivilStatus , Email = @Email , SpouseName = @SpouseName , SpouseContactNo = @SpouseContactNo,Status=@Status where EmpNo = @EmpNo ";

                        SqlConnection con = new SqlConnection(cs);
                        SqlCommand cmd = new SqlCommand(qry, con);

                        con.Open();

                        cmd.Parameters.AddWithValue("@EmpNo", empid);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@ResidentialAddress", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@DoB", dtpDoB.Text.Trim());
                        cmd.Parameters.AddWithValue("@NIC", txtNIC.Text.Trim());
                        cmd.Parameters.AddWithValue("@EPFNo", txtEPFNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Sex", cboSex.Text.Trim());
                        cmd.Parameters.AddWithValue("@CivilStatus", cboCivilStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@SpouseName", txtSpouseName.Text.Trim());
                        cmd.Parameters.AddWithValue("@SpouseContactNo", txtSpouseContactNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedValue.ToString());
                        //https://social.msdn.microsoft.com/Forums/en-US/b14cf4d7-025e-459c-ac41-1e503fcdcc99/how-to-retrieve-value-from-combobox-in-c?forum=vssmartdevicesvbcs

                        cmd.ExecuteNonQuery();
                        con.Close();

                        dgvEmployeeRefresh();
                        cleartextboxes();

                        btnSave.Enabled = true;
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Please select the EmpID in the grid", "Employee ID.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        return;
                    }

                    
                
            
            }

            btnSave.Enabled = false;
            cleartextboxes();
         }


        private void btnSearch_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string qry = "select * from Employee where EPFNo = @EPFNo ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EPFNo", txtEPFSearch.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();
            da.Fill(tbl);

            dgvEmployee.DataSource = tbl;
            con.Close();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            dgvEmployeeRefresh();
            txtEPFSearch.Text = string.Empty;
        }
    }
}
 
   

