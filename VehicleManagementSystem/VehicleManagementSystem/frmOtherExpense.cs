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
    public partial class frmOtherExpense : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = vmsuser; Password = 890";
        public int otherexpid = 0;
        public static int vid = 0;
        public frmOtherExpense()
        {
            InitializeComponent();
        }

        private void frmOtherExpense_Load(object sender, EventArgs e)
        {
            comboboxBindData();
           
          
            dgvOtherExpensesRefresh();
            dgvOtherExpenses.AllowUserToAddRows = false;
            dgvOtherExpenses.ClearSelection();
            dgvOtherExpenses.RowHeadersVisible = false;

            dgvOtherExpenses.Columns[0].HeaderText = "ExpID";
            dgvOtherExpenses.Columns[1].HeaderText = "VehicleNo";
            dgvOtherExpenses.Columns[6].HeaderText = "Respon.Person";
            dgvOtherExpenses.Columns[7].HeaderText = "Entered by";

            dgvOtherExpenses.Columns[0].Width = 40;
            dgvOtherExpenses.Columns[1].Width = 80;
            dgvOtherExpenses.Columns[2].Width = 80;
            dgvOtherExpenses.Columns[3].Width = 120;
            dgvOtherExpenses.Columns[4].Width = 80;
            dgvOtherExpenses.Columns[6].Width = 100;

            dgvOtherExpenses.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(cboVehicle.Text, "^[a-zA-Z0-9]").Success)  
            {
                MessageBox.Show("Vehicle No. must not be empty or \nEntered value is not valid.", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicle.Focus();
                return;
            }

            else if (!Regex.Match(txtReceiptNo.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Receipt No. must not be empty or \nEntered value is not valid.", "Receipt No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReceiptNo.Focus();
                return;
            }

            else if (!Regex.Match(txtAmount.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Amount must not be empty or \nEntered value is not valid.", "Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            else if (!Regex.Match(cboEmployee.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Employee Name must not be empty or \nEntered value is not valid.", "Employee name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboEmployee.Focus();
                return;
            }

            if (!Regex.Match(txtDetails.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Details must not be empty or \nEntered value is not valid.", "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDetails.Focus();
                return;
            }

            else
            {
                try
                {
                    string qry = "insert into OtherExpense (VID, Date, ReceiptNo, Amount, Details, EmpNo,Deleted,UserID) values (@VID, @Date, @ReceiptNo, @Amount, @Details, @EmpNo,@Deleted, @UserID)";
                    SqlConnection con = new SqlConnection(cs);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@VID", ( cboVehicle.SelectedValue));
                    cmd.Parameters.AddWithValue("@Date",dtpDate.Value.ToString("yyyyMMdd")); // get the value member ofthe combobox
                    cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Details", txtDetails.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmpNo",  cboEmployee.SelectedValue);
                    cmd.Parameters.AddWithValue("@Deleted",0);
                    cmd.Parameters.AddWithValue("@UserID",frmLogin.userid);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();
                    dgvOtherExpensesRefresh();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void comboboxBindData()  // load data into combo box
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            string qry = "SELECT   VID, RegistrationNo FROM Vehicle where Status <> 'Retired' order by RegistrationNo ";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboVehicle.DataSource = ds.Tables[0];
            cboVehicle.DisplayMember = "RegistrationNo";
            cboVehicle.ValueMember = "VID";
            cboVehicle.Enabled = true;
            cboVehicle.SelectedItem = null;


            SqlDataAdapter da3 = new SqlDataAdapter(qry, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            cboVehicleNoHistory.DataSource = ds3.Tables[0];
            cboVehicleNoHistory.DisplayMember = "RegistrationNo";
            cboVehicleNoHistory.ValueMember = "VID";
            cboVehicleNoHistory.Enabled = true;
            cboVehicleNoHistory.SelectedItem = null;



            string qry2 = "select EmpNo, Name from Employee order by Name ";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            cboEmployee.DataSource = ds2.Tables[0];
            cboEmployee.DisplayMember = "Name";
            cboEmployee.ValueMember = "EmpNo";
            cboEmployee.Enabled = true;
            cboEmployee.SelectedItem = null;


            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            dgvOtherExpensesRefresh();
            btnAdd.Enabled = true;
        }

        private void dgvOtherExpensesRefresh()
        {
            try
            {
                string qry = "select o.OtherExpID,v.RegistrationNo,o.Date,o.ReceiptNo,o.Amount, o.Details,   e.Name, a.Name from OtherExpense o, Employee e, Vehicle v , AppUser a where o.VID = v.VID and o.EmpNo = e.EmpNo and a.userid = o.UserID and o.Deleted = 0 order by o.OtherExpID";

                SqlConnection con = new SqlConnection(cs);

                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                con.Open();
                DataTable tbl = new DataTable();

                da.Fill(tbl);
                dgvOtherExpenses.DataSource = tbl;
                con.Close();

                dgvOtherExpenses.AllowUserToAddRows = false;
                dgvOtherExpenses.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dgvOtherExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvOtherExpenses.Rows[e.RowIndex];

                otherexpid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtOtherExpenseID.Text = dgvRow.Cells[0].Value.ToString();
                cboVehicle.Text = dgvRow.Cells[1].Value.ToString();
                dtpDate.Text = dgvRow.Cells[2].Value.ToString();
                txtReceiptNo.Text = dgvRow.Cells[3].Value.ToString();
                txtAmount.Text = dgvRow.Cells[4].Value.ToString();
                txtDetails.Text = dgvRow.Cells[5].Value.ToString();
                cboEmployee.Text = dgvRow.Cells[6].Value.ToString();

                btnSave.Enabled = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Please click on ExpenseID ........ " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!Regex.Match(cboVehicle.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Vehicle No. must not be empty or \nEntered value is not valid.", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicle.Focus();
                return;
            }

            else if (!Regex.Match(txtReceiptNo.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Receipt No. must not be empty or \nEntered value is not valid.", "Receipt No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReceiptNo.Focus();
                return;
            }

            else if (!Regex.Match(txtAmount.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Amount must not be empty or \nEntered value is not valid.", "Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            else if (!Regex.Match(cboEmployee.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Employee Name must not be empty or \nEntered value is not valid.", "Employee name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboEmployee.Focus();
                return;
            }

            if (!Regex.Match(txtDetails.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Details must not be empty or \nEntered value is not valid.", "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDetails.Focus();
                return;
            }

            else
            {
                try
                {

                    string qry = "update OtherExpense set VID = @VID, Date = @Date, ReceiptNo = @ReceiptNo, Amount = @Amount, Details = @Details, EmpNo=@EmpNo where OtherExpID = @OtherExpID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@OtherExpID", otherexpid);

                    cmd.Parameters.AddWithValue("@VID", cboVehicle.SelectedValue);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text.Trim());
                    cmd.Parameters.AddWithValue("@Details", txtDetails.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmpNo", cboEmployee.SelectedValue);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvOtherExpensesRefresh();
                    cleartextboxes();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the record ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {

                try
                {
                    string qry = " update  OtherExpense set Deleted=@Deleted where OtherExpID=@OtherExpID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@OtherExpID ", otherexpid);
                    cmd.Parameters.AddWithValue("@Deleted", 1);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been removed successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvOtherExpensesRefresh();
                    cleartextboxes();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(cboVehicleNoHistory.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Vehicle No. must not be empty or \nEntered value is not valid.", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicle.Focus();
                
            }

            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    string qry = "select o.OtherExpID,v.RegistrationNo,o.Date,o.ReceiptNo,o.Amount, o.Details,   e.Name from OtherExpense o, Employee e, Vehicle v where o.VID = v.VID and o.EmpNo = e.EmpNo and o.Deleted=0 and v.VID=@VID    order by o.OtherExpID";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@VID", cboVehicleNoHistory.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable tbl = new DataTable();
                    da.Fill(tbl);

                    dgvOtherExpenses.DataSource = tbl;
                    con.Close();

                    

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

            
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

            if (!Regex.Match(cboVehicleNoHistory.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Vehicle No.  must not be empty or \nEntered value is not valid.", "Vehicle No", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNoHistory.Focus();
                return;
            }

            vid = Convert.ToInt32(cboVehicleNoHistory.SelectedValue);


            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrOtherExpense")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrOtherExpense f = new frmCrOtherExpense();
                f.Show();
            }

        }
    }
}
