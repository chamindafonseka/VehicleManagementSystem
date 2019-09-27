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
    public partial class frmInsuranceEmissionRevenue : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int id=0;
        public frmInsuranceEmissionRevenue()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            cboVehicle.Focus();
            btnSave.Enabled = true;
            dgvInsuranceEmissionRevenueRefresh();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!Regex.Match(txtReferenceNo.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Name must not be empty or \nEntered value is not valid.", "Reference No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReferenceNo.Focus();
                return;
            }

            else if(cboVehicle.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicle.Focus();
                return;
            }

            else if (cboInstitute.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "Institute name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboInstitute.Focus();
                return;
            }

            else if (cboLicenseDocType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "License Document Type.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboInstitute.Focus();
                return;
            }

            else if (!Regex.Match(txtMeterReading.Text, "^[0-9]+$").Success) // acept only    numbers  
            {
                MessageBox.Show("Meter reading must not be empty or \nEntered value is not valid.", "Meter reading.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReading.Focus();
                return;
            }

            else if (!Regex.Match(txtFee.Text, @"^(\d*\.)?\d+$").Success) // acept only    numbers  
            {
                MessageBox.Show("Fees must not be empty or \nEntered value is not valid.", "Fees.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFee.Focus();
                return;
            }

            else if (cboDriver.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "Driver Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }

            //validation the date period
            else if ( Convert.ToDateTime( dtpStartDate.Text) > Convert.ToDateTime(dtpEndDate.Text))
            {
                MessageBox.Show("Pls check the start-date and end-date. ", "False date range", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpStartDate.Focus();
                return;
            }

            //validation the date period
            else if (Convert.ToDateTime(dtpIssuedDate.Text) > Convert.ToDateTime(dtpEndDate.Text))
            {
                MessageBox.Show("Pls check the issued-date and end-date. ", "False date range", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpIssuedDate.Focus();
                return;
              
            }


            else
            {

                string qry = "insert into InsuranceEmissionRevenue (ReferanceNo, VID, LPID, IssuedDate, FromDate, ToDate, MeterReading, Fee, DriverID, DocName, EnteredBy,Deleted ) values(  @ReferanceNo, @VID, @LPID, @IssuedDate, @FromDate, @ToDate, @MeterReading, @Fee, @DriverID, @DocName, @EnteredBy,@Deleted )  ";

                

                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@VID", cboVehicle.SelectedValue);
                cmd.Parameters.AddWithValue("@ReferanceNo", txtReferenceNo.Text.Trim());
                cmd.Parameters.AddWithValue("@LPID", cboInstitute.SelectedValue);
                cmd.Parameters.AddWithValue("@DocName", cboLicenseDocType.SelectedValue);
                cmd.Parameters.AddWithValue("@IssuedDate", dtpIssuedDate.Text);
                cmd.Parameters.AddWithValue("@FromDate", dtpStartDate.Text);
                cmd.Parameters.AddWithValue("@ToDate", dtpEndDate.Text);
                cmd.Parameters.AddWithValue("@MeterReading", txtMeterReading.Text.Trim());
                cmd.Parameters.AddWithValue("@Fee", txtFee.Text.Trim());
                cmd.Parameters.AddWithValue("@DriverID", cboDriver.SelectedValue);
                cmd.Parameters.AddWithValue("@EnteredBy", frmLogin.userid);
                cmd.Parameters.AddWithValue("@Deleted", 0);
                
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cleartextboxes();
                dgvInsuranceEmissionRevenueRefresh();

            }

        }

        public void BindComboboxData()
        {
            SqlConnection con = new SqlConnection(cs);
            // vehicle no for dropsown list
            con.Open();
            string qry = "select VID, RegistrationNo from Vehicle where  status not like 'Retired%'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboVehicle.DataSource = dt;
            
            cboVehicle.DisplayMember = "RegistrationNo";
            cboVehicle.ValueMember = "VID";
            cboVehicle.Enabled = true;
            cboVehicle.SelectedItem = null;


            //vehicle search combo box
            string qry5 = "select VID, RegistrationNo from Vehicle where  status not like 'Retired%'";
            SqlCommand cmd5 = new SqlCommand(qry5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            cboVehicleSearch.DataSource = dt5;
            cboVehicleSearch.DisplayMember = "RegistrationNo";
            cboVehicleSearch.ValueMember = "VID";
            cboVehicleSearch.Enabled = true;
            cboVehicleSearch.SelectedItem = null;



            // Institute name for combo box
            string qry2 = "select LPID, Name  from LicenseProvider where deleted = 0";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cboInstitute.DataSource = dt2;

            cboInstitute.DisplayMember = "Name";
            cboInstitute.ValueMember = "LPID";
            cboInstitute.Enabled = true;
            cboInstitute.SelectedItem = null;

            // License Types for combo box
            string qry3 = "SELECT   LDocID, Name FROM   LicenseDocType";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cboLicenseDocType.DataSource = dt3;

            cboLicenseDocType.DisplayMember = "Name";
            cboLicenseDocType.ValueMember = "LDocID";
            cboLicenseDocType.Enabled = true;
            cboLicenseDocType.SelectedItem = null;

            // Driver names for combo box
            string qry4 = "select e.Name,e.EmpNo from Driver d, Employee e where e.EmpNo = d.EmpNo and d.IsDeleted =0 and e.Status =1";
            SqlCommand cmd4 = new SqlCommand(qry4, con);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            cboDriver.DataSource = dt4;

            cboDriver.DisplayMember = "Name";
            cboDriver.ValueMember = "EmpNo";
            cboDriver.Enabled = true;
            cboDriver.SelectedItem = null;

            
            con.Close();

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
        public void dgvInsuranceEmissionRevenueRefresh()
        {
            string qry = "select i.id, i.ReferanceNo,v.RegistrationNo[VehicleNo],Lt.Name[LicenseType],i.IssuedDate,i.FromDate,i.ToDate,i.MeterReading,i.Fee,e.Name[Driver],l.Name[LicenseInstitute]  from  InsuranceEmissionRevenue i, Vehicle v ,LicenseProvider l, Employee e, LicenseDocType lt where i.VID = v.VID and i.LPID = l.LPID and i.DriverID = e.EmpNo and lt.LDocID = i.DocName and i.Deleted=0";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvInsurEmissionRevenue.DataSource = tbl;
            con.Close();

            //dgvInsurEmissionRevenue.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInsurEmissionRevenue.AllowUserToAddRows = false;
            dgvInsurEmissionRevenue.RowHeadersVisible = false;
            dgvInsurEmissionRevenue.ClearSelection();

            dgvInsurEmissionRevenue.Columns[0].Width =40;
            dgvInsurEmissionRevenue.Columns[1].Width = 80;
            dgvInsurEmissionRevenue.Columns[2].Width = 60;
            dgvInsurEmissionRevenue.Columns[3].Width = 150;
            dgvInsurEmissionRevenue.Columns[4].Width = 70;
            dgvInsurEmissionRevenue.Columns[5].Width = 70;
            dgvInsurEmissionRevenue.Columns[6].Width = 70;
            dgvInsurEmissionRevenue.Columns[7].Width = 80;
            dgvInsurEmissionRevenue.Columns[8].Width = 60;
            dgvInsurEmissionRevenue.Columns[9].Width = 110;
            dgvInsurEmissionRevenue.Columns[10].Width = 120;

            dgvInsurEmissionRevenue.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvInsurEmissionRevenue.EnableHeadersVisualStyles = false;

        }

        

        private void frmInsuranceEmissionRevenue_Load(object sender, EventArgs e)
        {
           
            BindComboboxData();
            dgvInsuranceEmissionRevenueRefresh();
        }

        private void dgvInsurEmissionRevenue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                { 
                    btnUpdate.Enabled = true;
                    DataGridViewRow dgvRow = dgvInsurEmissionRevenue.Rows[e.RowIndex];

                    id = Convert.ToInt32(dgvRow.Cells[0].Value.ToString()); // how i extract ID for sql queries, it should be a public int
                    txtID.Text = dgvRow.Cells[0].Value.ToString();
                    txtReferenceNo.Text = dgvRow.Cells[1].Value.ToString();
                    cboVehicle.Text = dgvRow.Cells[2].Value.ToString();
                    cboLicenseDocType.Text = dgvRow.Cells[3].Value.ToString();
                    dtpIssuedDate.Text = dgvRow.Cells[4].Value.ToString();
                    dtpIssuedDate.Text = dgvRow.Cells[5].Value.ToString();
                    dtpIssuedDate.Text = dgvRow.Cells[6].Value.ToString();
                    txtMeterReading.Text = dgvRow.Cells[7].Value.ToString();
                    txtFee.Text = dgvRow.Cells[8].Value.ToString();
                    cboDriver.Text = dgvRow.Cells[9].Value.ToString();
                    cboInstitute.Text = dgvRow.Cells[10].Value.ToString();

                }

                btnSave.Enabled = false;
                btnUpdate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select ID. " + ex.Message, "Select ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtReferenceNo.Text, "^[a-zA-Z]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Name must not be empty or \nEntered value is not valid.", "Reference No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReferenceNo.Focus();
                return;
            }

            else if (cboVehicle.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicle.Focus();
                return;
            }

            else if (cboInstitute.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "Institute name.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboInstitute.Focus();
                return;
            }

            else if (cboLicenseDocType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "License Document Type.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboInstitute.Focus();
                return;
            }

            else if (!Regex.Match(txtMeterReading.Text, "^[0-9]+$").Success) // acept only    numbers  
            {
                MessageBox.Show("Meter reading must not be empty or \nEntered value is not valid.", "Meter reading.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReading.Focus();
                return;
            }

            else if (!Regex.Match(txtFee.Text, @"^(\d*\.)?\d+$").Success) // acept only    numbers  
            {
                MessageBox.Show("Fees must not be empty or \nEntered value is not valid.", "Fees.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFee.Focus();
                return;
            }

            else if (cboDriver.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value", "Driver Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }

            else
            {
                string qry = "  update InsuranceEmissionRevenue  set  ReferanceNo = @ReferanceNo ,   VID=@VID,  LPID=@LPID,  IssuedDate=@IssuedDate ,  FromDate=@FromDate,  ToDate=@ToDate, MeterReading= @MeterReading,  Fee = @Fee, DriverID = @DriverID, DocName = @DocName, EnteredBy = @EnteredBy , Deleted =  @Deleted  where ID = @ID ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ReferanceNo",txtReferenceNo.Text.Trim());
                cmd.Parameters.AddWithValue("@VID", this.cboVehicle.SelectedValue);
                cmd.Parameters.AddWithValue("@LPID", this.cboInstitute.SelectedValue);
                cmd.Parameters.AddWithValue("@IssuedDate",this.dtpIssuedDate.Text);
                cmd.Parameters.AddWithValue("@FromDate", this.dtpStartDate.Text);
                cmd.Parameters.AddWithValue("@ToDate",this.dtpEndDate.Text.Trim());
                cmd.Parameters.AddWithValue("@MeterReading", this.txtMeterReading.Text.Trim());
                cmd.Parameters.AddWithValue("@Fee",this.txtFee.Text.Trim());
                cmd.Parameters.AddWithValue("@DriverID",this.cboDriver.SelectedValue);
                cmd.Parameters.AddWithValue("@DocName",this.cboLicenseDocType.SelectedValue);
                cmd.Parameters.AddWithValue("@EnteredBy",frmLogin.userid);
                cmd.Parameters.AddWithValue("@Deleted", 0);



                cmd.ExecuteNonQuery();

                con.Close();
                dgvInsuranceEmissionRevenueRefresh();
                

                MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cleartextboxes();

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Plese select a raw.", "Select raw", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    string qry = " update InsuranceEmissionRevenue set Deleted=1 where ID=@ID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Deleted", 1);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    dgvInsuranceEmissionRevenueRefresh();
                    MessageBox.Show("Record has been deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();

                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string qry = "select i.id, i.ReferanceNo,v.RegistrationNo[VehicleNo],Lt.Name[LicenseType],i.IssuedDate,i.FromDate,i.ToDate,i.MeterReading,i.Fee, e.Name[Driver],l.Name[LicenseInstitute]  from InsuranceEmissionRevenue i, Vehicle v, LicenseProvider l, Employee e, LicenseDocType lt where i.VID = v.VID and i.LPID = l.LPID and i.DriverID = e.EmpNo and lt.LDocID = i.DocName  and v.RegistrationNo = @RegistrationNo order by i.id ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RegistrationNo",  cboVehicleSearch.Text.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();
            da.Fill(tbl);

            dgvInsurEmissionRevenue.DataSource = tbl;
            con.Close();
        }
    }
}
