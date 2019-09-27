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
    public partial class frmInsuranceClaim : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int id = 0;
        public static DateTime fromDate;
        public static DateTime toDate;
        public static string VehicleNo;
        public frmInsuranceClaim()
        {
            InitializeComponent();
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
            cboVehicleNo.DataSource = dt;

            cboVehicleNo.DisplayMember = "RegistrationNo";
            cboVehicleNo.ValueMember = "VID";
            cboVehicleNo.Enabled = true;
            cboVehicleNo.SelectedItem = null;

            cboCrVehicleNo.DataSource = dt;
            cboCrVehicleNo.DisplayMember = "RegistrationNo";
            cboCrVehicleNo.ValueMember = "VID";
            cboCrVehicleNo.Enabled = true;
            cboCrVehicleNo.SelectedItem = null;

            //for vehicle search combobox

            // for search : cboSearch
            cboVehicleSearch.DataSource = dt;
            cboVehicleSearch.DisplayMember = "RegistrationNo";
            cboVehicleSearch.ValueMember = "VID";
            cboVehicleSearch.Enabled = true;
            cboVehicleSearch.SelectedItem = null;

            //Accident number dropdown list
            string qry2 = "select VAID,VID from VehicleAccident where Claimed = 0";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cboVAID.DataSource = dt2;
            cboVAID.ValueMember = "VAID";
            cboVAID.DisplayMember = "VAID";
            cboVAID.Enabled = true;
            cboVAID.SelectedItem = null;

            //Insurance company combobox
            string qry3 = "SELECT LPID, Name FROM LicenseProvider where DocumentType  like 'Insurance Policy'";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cboInsuCompany.DataSource = dt3;
            cboInsuCompany.ValueMember = "LPID";
            cboInsuCompany.DisplayMember = "Name";
            cboInsuCompany.Enabled = true;
            cboInsuCompany.SelectedItem = null;

            con.Close();

        }

        private void frmInsuranceClaim_Load(object sender, EventArgs e)
        {
            BindComboboxData();
            //dtpPaydate.CustomFormat = "";
            dgvInsuranceClaimRefresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboVehicleNo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the vehicle No.", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if (cboInsuCompany.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Insurance Company", "Insurance Company", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if(cboVAID.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Vehicle Accident No", "Accident No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVAID.Focus();
                return;
            }
            else if (!Regex.IsMatch(txtAmount.Text, @"^\d+(.\d+){0,1}$"))
            {
                MessageBox.Show("Please enter claim amount in correct format (eg: 12025.50)", "Claim Amount",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            else if (!Regex.IsMatch(txtchequeNo.Text, "^[0-9]{6}$"))
            {
                MessageBox.Show("Please enter valid cheque no.", "cheque no.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtchequeNo.Focus();
                return;
            }

            else if (dtpPaydate.Value == Convert.ToDateTime("1/1/2000")||dtpPaydate.Value >= DateTime.Now)
            {
                MessageBox.Show("Please enter valid Paydate.", "Paydate.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpPaydate.Focus();
                return;
            }           

            else
            {
                try
                {
                    string qry = "insert into InsuranceClaim (VID,LPID, Amount, ChequeNo, VAID, PayDate, EnteredBy, Entereddate) values(@VID,@LPID, @Amount, @ChequeNo, @VAID, @PayDate, @EnteredBy, @Entereddate)  ";

                    SqlConnection con = new SqlConnection(cs);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@VID", cboVehicleNo.SelectedValue);
                    cmd.Parameters.AddWithValue("@LPID", cboInsuCompany.SelectedValue);
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChequeNo", txtchequeNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@VAID", cboVAID.SelectedValue);

                    //to update VehicleAccident table claimed-column as claimed.
                    var z = cboVAID.SelectedValue;

                    cmd.Parameters.AddWithValue("@PayDate", dtpPaydate.Value);
                    cmd.Parameters.AddWithValue("@EnteredBy", frmLogin.userid);
                    cmd.Parameters.AddWithValue("@Entereddate", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    //update VehicleAccident with given VAID

                    string qry2 = "Update VehicleAccident set Claimed=1 where VAID=@VAID " ;
                    SqlCommand cmd2 = new SqlCommand(qry2, con);
                    cmd2.Parameters.AddWithValue("@VAID",z);

                    cmd2.ExecuteNonQuery();   

                    con.Close();

                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cleartextboxes();
                    dgvInsuranceClaimRefresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message );
                }               

            }
        }


        public void dgvInsuranceClaimRefresh()
        {
            string qry = "select i.ClaimID, v.RegistrationNo , l.Name[Insurance company], i.VAID [AccidentID],i.Amount, i.ChequeNo, i.PayDate ,ie.ReferanceNo[Policy No] from InsuranceClaim i, Vehicle v, LicenseProvider l ,InsuranceEmissionRevenue ie where i.VID = v.vid and l.LPID = i.LPID and i.VID = ie.VID and ie.DocName = 3 order by  i.ClaimID";

            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvInsuranceClaim.DataSource = tbl;
            con.Close();

            dgvInsuranceClaim.AllowUserToAddRows = false;
            dgvInsuranceClaim.RowHeadersVisible = false;
            dgvInsuranceClaim.ClearSelection();

            dgvInsuranceClaim.Columns[0].Width = 50;
            dgvInsuranceClaim.Columns[1].Width = 90;
            dgvInsuranceClaim.Columns[2].Width = 200;
            dgvInsuranceClaim.Columns[3].Width = 60;
            dgvInsuranceClaim.Columns[4].Width = 90;
            dgvInsuranceClaim.Columns[5].Width = 100;

            dgvInsuranceClaim.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvInsuranceClaim.EnableHeadersVisualStyles = false;
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

        private void dgvInsuranceClaim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    btnUpdate.Enabled = true;
                    DataGridViewRow dgvRow = dgvInsuranceClaim.Rows[e.RowIndex];

                    id = Convert.ToInt32(dgvRow.Cells[0].Value.ToString()); // how i extract ClaimID for sql queries, it should be a public int
                    txtClaimID.Text = dgvRow.Cells[0].Value.ToString();
                    cboVehicleNo.Text = dgvRow.Cells[1].Value.ToString();
                    cboInsuCompany.Text = dgvRow.Cells[2].Value.ToString();
                    cboVAID.Text = dgvRow.Cells[3].Value.ToString();
                    txtAmount.Text = dgvRow.Cells[4].Value.ToString();
                    txtchequeNo.Text = dgvRow.Cells[5].Value.ToString();
                    dtpPaydate.Text = dgvRow.Cells[6].Value.ToString();
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
            if (cboVehicleNo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the vehicle No.", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if (cboInsuCompany.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Insurance Company", "Insurance Company", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if (cboVAID.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Vehicle Accident No", "Accident No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVAID.Focus();
                return;
            }
            else if (!Regex.IsMatch(txtAmount.Text, @"^\d+(.\d+){0,1}$"))
            {
                MessageBox.Show("Please enter claim amount in correct format (eg: 12025.50)", "Claim Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            else if (!Regex.IsMatch(txtchequeNo.Text, "^[0-9]{6}$"))
            {
                MessageBox.Show("Please enter valid cheque no.", "cheque no.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtchequeNo.Focus();
                return;
            }

            else if (dtpPaydate.Value == Convert.ToDateTime("1/1/2000") || dtpPaydate.Value >= DateTime.Now)
            {
                MessageBox.Show("Please enter valid Paydate.", "Paydate.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpPaydate.Focus();
                return;
            }

            else
            {
                try
                {
                    string qry = " update InsuranceClaim set VID = @VID,LPID=@LPID, Amount=@Amount, ChequeNo=@ChequeNo, VAID=@VAID, PayDate=@PayDate where ClaimID = @ClaimID  ";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@ClaimID",id);
                    cmd.Parameters.AddWithValue("@VID", this.cboVehicleNo.SelectedValue);
                    cmd.Parameters.AddWithValue("@LPID", this.cboInsuCompany.SelectedValue);
                    cmd.Parameters.AddWithValue("@Amount", this.txtAmount.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChequeNo", this.txtchequeNo.Text.Trim());                    
                    cmd.Parameters.AddWithValue("@VAID", this.cboVAID.SelectedValue);
                    cmd.Parameters.AddWithValue("@PayDate", this.dtpPaydate.Text);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    dgvInsuranceClaimRefresh();
                    
                    MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cleartextboxes();

                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            cboVehicleNo.Focus();
            btnSave.Enabled = true;
            dgvInsuranceClaimRefresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do not allow users to delete records","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string qry = "select i.ClaimID, v.RegistrationNo , l.Name[Insurance company], i.VAID [AccidentID],i.Amount, i.ChequeNo, i.PayDate ,ie.ReferanceNo[Policy No] from InsuranceClaim i, Vehicle v, LicenseProvider l ,InsuranceEmissionRevenue ie where i.VID = v.vid and l.LPID = i.LPID and i.VID = ie.VID and ie.DocName = 3 and v.RegistrationNo =@RegistrationNo ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RegistrationNo", cboVehicleSearch.Text.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();
            da.Fill(tbl);

            dgvInsuranceClaim.DataSource = tbl;
            con.Close();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            fromDate =dtpAllFrom.Value;
            toDate = dtpAllTo.Value;

            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrInsuranceClaimsAll")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrInsuranceClaimsAll f = new frmCrInsuranceClaimsAll();
                f.Show();
            }
        }

        private void btnViewVehicle_Click(object sender, EventArgs e)
        {
            VehicleNo = cboCrVehicleNo.Text;
            bool Isopen = false;
            foreach (Form f2 in Application.OpenForms)
            {
                if (f2.Text == "frmCrInsuranceClaimsVehicleNo")
                {
                    Isopen = true;
                    f2.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrInsuranceClaimsVehicleNo f2 = new frmCrInsuranceClaimsVehicleNo();
                f2.Show();
            }

        }
    }
}
