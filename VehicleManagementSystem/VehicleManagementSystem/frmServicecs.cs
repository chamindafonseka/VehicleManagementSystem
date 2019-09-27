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


namespace VehicleManagementSystem
{
    public partial class frmServicecs : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public static  int serviceid = 0;
        public static int vid = 0;
        
        public frmServicecs()
        {
            InitializeComponent();
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
            if (string.IsNullOrEmpty(cboVehicleNo.Text)) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Vehicle Number must not be empty or \nEntered value is not valid.", "Vehicle Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if (dtpServiceDate.Value >  DateTime.Now)   
            {
                MessageBox.Show("Serviced date must not be empty or \nEntered value is not valid.", "Serivced Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpServiceDate.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cboServiceCenter.Text))  
            {
                MessageBox.Show("Service Center must not be empty or \nEntered value is not valid.", "Service Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboServiceCenter.Focus();
                return;
            }

            else if (!Regex.Match(txtMeterReading.Text, "^[0-9]").Success) 
            {
                MessageBox.Show("Meter Reading must not be empty or \nEntered value is not valid.", "Meter Reading", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReading.Focus();
                return;
            }

            else if (!Regex.Match(txtInvoiceNo.Text, "^[a-zA-Z0-9-d]").Success)  
            {
                MessageBox.Show("Invoice number must not be empty or \nEntered value is not valid.", "Meter Reading", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReading.Focus();
                return;
            }

            else if (!Regex.Match(txtAmount.Text, "^[0-9-d]").Success)
            {
                MessageBox.Show("Amount must not be empty or \nEntered value is not valid.", "Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cboDriver.Text))
            {
                MessageBox.Show("Driver must not be empty or \nEntered value is not valid.", "Driver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }

            else
            {
                try
                {
                    string qry = "insert into Service(VID,ServiceDate,SCID,MeterReading,InvoiceNo,Amount,DriverID,Remarks ) values (@VID,@ServiceDate,@SCID,@MeterReading,@InvoiceNo,@Amount,@DriverID,@Remarks )";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@VID",cboVehicleNo.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ServiceDate", dtpServiceDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@SCID",cboServiceCenter.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MeterReading",txtMeterReading.Text.Trim());
                    cmd.Parameters.AddWithValue("@InvoiceNo",txtInvoiceNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amount",txtAmount.Text.Trim());
                    cmd.Parameters.AddWithValue("@DriverID",cboDriver.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Remarks",txtRemarks.Text.Trim());
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();
                    dgvServiceRefresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvServiceRefresh()
        {
            try
            {
                string qry = "select s.ServiceID, v.RegistrationNo, s.ServiceDate,sc.Name,s.MeterReading,s.InvoiceNo,s.Amount,e.Name,s.Remarks from Service s, vehicle v, ServiceCenter sc, Driver d, Employee e where s.vid = v.VID and s.SCID = sc.SCID and s.DriverID = d.EmpNo and e.EmpNo = d.EmpNo   order by s.ServiceID ";

                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                con.Open();
                DataTable tbl = new DataTable();

                da.Fill(tbl);
                dgvService.DataSource = tbl;
                con.Close();

                dgvService.AllowUserToAddRows = false;
                dgvService.ClearSelection();
                dgvService.RowHeadersVisible = false;

                dgvService.Columns[0].Width = 60;
                dgvService.Columns[1].Width = 80;
                dgvService.Columns[2].Width = 80;
                dgvService.Columns[3].Width = 150;
                dgvService.Columns[4].Width = 80;
                dgvService.Columns[5].Width = 80;
                dgvService.Columns[6].Width = 80;
                dgvService.Columns[7].Width = 150;



                btnSave.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public void BindData()  // load data into combo box
        { 
            //load data to combo box : cboVehicleno
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string qry = "select VID, RegistrationNo from Vehicle where status ='Active'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboVehicleNo.DataSource = ds.Tables[0];
            cboVehicleNo.DisplayMember = "RegistrationNo";
            cboVehicleNo.ValueMember = "VID";
            cboVehicleNo.Enabled = true;

            //load data to combo box : cboServiceCenter
            string qry2 = "select SCID, Name from ServiceCenter ";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            cboServiceCenter.DataSource = ds2.Tables[0];
            cboServiceCenter.DisplayMember = "Name";
            cboServiceCenter.ValueMember = "SCID";
            cboServiceCenter.Enabled = true;

            //load data to combo box : cboDriver
            string qry3 = "select e.EmpNo[EmpNo], e.Name[Name] from Driver d, Employee e where d.EmpNo = e.EmpNo ";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(qry3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            cboDriver.DataSource = ds3.Tables[0];
            cboDriver.DisplayMember = "Name";
            cboDriver.ValueMember = "EmpNo";
            cboDriver.Enabled = true;

            con.Close();
        }

        private void frmServicecs_Load(object sender, EventArgs e)
        {
            BindData();
            cboVehicleNo.Text = null;
            dtpServiceDate.Value = DateTime.Today.AddDays(-2);
            cleartextboxes();
            dgvServiceRefresh();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            dgvServiceRefresh();
            btnSave.Enabled = true;

        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvService.Rows[e.RowIndex];

                serviceid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtServiceID.Text = dgvRow.Cells[0].Value.ToString();
                cboVehicleNo.Text = dgvRow.Cells[1].Value.ToString();
                dtpServiceDate.Text = dgvRow.Cells[2].Value.ToString();
                cboServiceCenter.Text  = dgvRow.Cells[3].Value.ToString();
                txtMeterReading.Text = dgvRow.Cells[4].Value.ToString();
                txtInvoiceNo.Text = dgvRow.Cells[5].Value.ToString();
                txtAmount.Text = dgvRow.Cells[6].Value.ToString();
                cboDriver.Text = dgvRow.Cells[7].Value.ToString();
                txtRemarks.Text = dgvRow.Cells[8].Value.ToString();

                btnSave.Enabled = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Please enter a TeamID.  " + ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboVehicleNo.Text)) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Vehicle Number must not be empty or \nEntered value is not valid.", "Vehicle Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if (dtpServiceDate.Value > DateTime.Now)
            {
                MessageBox.Show("Serviced date must not be empty or \nEntered value is not valid.", "Serivced Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpServiceDate.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cboServiceCenter.Text))
            {
                MessageBox.Show("Service Center must not be empty or \nEntered value is not valid.", "Service Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboServiceCenter.Focus();
                return;
            }

            else if (!Regex.Match(txtMeterReading.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Meter Reading must not be empty or \nEntered value is not valid.", "Meter Reading", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReading.Focus();
                return;
            }

            else if (!Regex.Match(txtInvoiceNo.Text, "^[a-zA-Z0-9-d]").Success)
            {
                MessageBox.Show("Invoice number must not be empty or \nEntered value is not valid.", "Meter Reading", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReading.Focus();
                return;
            }

            else if (!Regex.Match(txtAmount.Text, "^[0-9-d]").Success)
            {
                MessageBox.Show("Amount must not be empty or \nEntered value is not valid.", "Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cboDriver.Text))
            {
                MessageBox.Show("Driver must not be empty or \nEntered value is not valid.", "Driver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }

            else
            {
                try
                {

                    string qry = " update service set vid = @vid, ServiceDate = @ServiceDate, SCID = @SCID, MeterReading = @MeterReading, InvoiceNo = @InvoiceNo, Amount = @Amount, DriverID = @DriverID, remarks = @Remarks where ServiceID = @ServiceID ";
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);                    

                    cmd.Parameters.AddWithValue("@ServiceID", serviceid); //get the value from row click event in "dgvService_CellClick()"

                    cmd.Parameters.AddWithValue("@vid",cboVehicleNo.SelectedValue );
                    cmd.Parameters.AddWithValue("@ServiceDate",dtpServiceDate.Value);
                    cmd.Parameters.AddWithValue("@SCID",cboServiceCenter.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MeterReading",txtMeterReading.Text.Trim());
                    cmd.Parameters.AddWithValue("@InvoiceNo",txtInvoiceNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amount",txtAmount.Text.Trim());
                    cmd.Parameters.AddWithValue("@DriverID",cboDriver.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Remarks",txtRemarks.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvServiceRefresh();
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the record ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                string qry = " delete from Service where   ServiceID  = @ServiceID   ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@ServiceID", serviceid);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvServiceRefresh();
                MessageBox.Show("Selected Record has been deleted. ", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartextboxes();

            }
        }

        private void btnServiceHistory_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(cboVehicleNo.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Vehicle No.  must not be empty or \nEntered value is not valid.", "Vehicle No", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }



            vid = Convert.ToInt32(cboVehicleNo.SelectedValue);


            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrServiceHistory")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrServiceHistory f = new frmCrServiceHistory();
                f.Show();
            }
        }
    }
}
