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
    public partial class frmVehicleAccident : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int id = 0;

        public static DateTime fromDate;
        public static DateTime toDate;
        public static string VehicleNo;
        public static string type;
        public frmVehicleAccident()
        {
            InitializeComponent();
        }

        private void frmVehicleAccident_Load(object sender, EventArgs e)
        {
            BindComboboxData();
            this.dtpAccidentDatetime.Value = DateTime.FromOADate(0);

            dgvVehicleAccidentRefresh();


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


            //vehicle search combo box
            string qry5 = "select VID, RegistrationNo from Vehicle where  status not like 'Retired%'";
            SqlCommand cmd5 = new SqlCommand(qry5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            //cboVehicleSearch.DataSource = dt5;
            //cboVehicleSearch.DisplayMember = "RegistrationNo";
            //cboVehicleSearch.ValueMember = "VID";
            //cboVehicleSearch.Enabled = true;
            //cboVehicleSearch.SelectedItem = null;

            //Driver combo box
            string qry4 = "select e.Name,e.EmpNo from Driver d, Employee e where e.EmpNo = d.EmpNo and d.IsDeleted =0 ";
            SqlCommand cmd4 = new SqlCommand(qry4, con);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            cboDriver.DataSource = dt4;

            cboDriver.DisplayMember = "Name";
            cboDriver.ValueMember = "EmpNo";
            cboDriver.Enabled = true;
            cboDriver.SelectedItem = null;

            //vehicle type combo
            string qry6 = "SELECT TypeID, Name FROM VehicleType";
            SqlCommand cmd6 = new SqlCommand(qry6, con);
            SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            cboType.DataSource = dt6;

            cboType.DisplayMember = "Name";
            cboType.ValueMember = "TypeID";
            cboType.Enabled = true;




            con.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboVehicleNo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the vehicle", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }
            else if (cboDriver.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Driver", "Driver.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtLocation.Text))
            {
                MessageBox.Show("Please enter the accident occured area", "Location.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }

            else if (dtpAccidentDatetime.Value == DateTime.FromOADate(0))
            {
                MessageBox.Show("Please enter valid accident Date & time..", "Accident date and  time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpAccidentDatetime.Focus();
                return;
            }

            else if ( Convert.ToDateTime( dtpAccidentDatetime.Text) > DateTime.Now)
            {
               
                MessageBox.Show("Please enter valid accident Date & time.", "Accident date and  time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpAccidentDatetime.Focus();
                return;
            }

           

            else
            {
                string qry = "insert into VehicleAccident (VID, AccidentDateTime, DriverID, Location, SysEnteredTime, Claimed ) values(  @VID, @AccidentDateTime,@DriverID , @Location, @SysEnteredTime, @Claimed )  ";

                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@VID", cboVehicleNo.SelectedValue);
                cmd.Parameters.AddWithValue("@AccidentDateTime", dtpAccidentDatetime.Value);
                cmd.Parameters.AddWithValue("@DriverID", cboDriver.SelectedValue);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                cmd.Parameters.AddWithValue("@SysEnteredTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Claimed", 0);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cleartextboxes();
                //dgvTeamRefresh();

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

        public void dgvVehicleAccidentRefresh()
        {
            string qry = "select va.VAID, v.RegistrationNo, va.AccidentDateTime,e.Name,va.Location ,va.Claimed from Vehicle v, VehicleAccident va , Employee e where v.VID = va.VID and e.EmpNo = va.DriverID order by va.VAID";

            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvVehicleAccident.DataSource = tbl;
            con.Close();

            dgvVehicleAccident.AllowUserToAddRows = false;
            dgvVehicleAccident.RowHeadersVisible = false;
            dgvVehicleAccident.ClearSelection();

            dgvVehicleAccident.Columns[0].Width = 50;
            dgvVehicleAccident.Columns[1].Width = 90;
            dgvVehicleAccident.Columns[2].Width = 150;
            dgvVehicleAccident.Columns[3].Width = 170;
            dgvVehicleAccident.Columns[4].Width = 170;
            dgvVehicleAccident.Columns[5].Width = 70;

            dgvVehicleAccident.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvVehicleAccident.EnableHeadersVisualStyles = false;

        }

        private void dgvVehicleAccident_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    btnUpdate.Enabled = true;
                    DataGridViewRow dgvRow = dgvVehicleAccident.Rows[e.RowIndex];

                    id = Convert.ToInt32(dgvRow.Cells[0].Value.ToString()); // how i extract ID for sql queries, it should be a public int
                    txtVAID.Text = dgvRow.Cells[0].Value.ToString();
                    cboVehicleNo.Text = dgvRow.Cells[1].Value.ToString();
                    dtpAccidentDatetime.Text = dgvRow.Cells[2].Value.ToString();
                    cboDriver.Text = dgvRow.Cells[3].Value.ToString();
                    txtLocation.Text = dgvRow.Cells[4].Value.ToString();
                   
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
                MessageBox.Show("Please select the vehicle", "Vehicle No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }
            else if (cboDriver.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Driver", "Driver.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtLocation.Text))
            {
                MessageBox.Show("Please enter the accident occured area", "Location.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDriver.Focus();
                return;
            }


            else if (dtpAccidentDatetime.Value == DateTime.FromOADate(0))
            {
                MessageBox.Show("Please enter valid accident Date & time..", "Accident date and  time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpAccidentDatetime.Focus();
                return;
            }

            else if (Convert.ToDateTime(dtpAccidentDatetime.Text) > DateTime.Now)
            {

                MessageBox.Show("Please enter valid accident Date & time.", "Accident date and  time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpAccidentDatetime.Focus();
                return;
            }

            else
            {
                try
                {
                    string qry = "  update VehicleAccident  set  VID=@VID, AccidentDateTime=@AccidentDateTime, DriverID=@DriverID, Location=@Location, SysEnteredTime=@SysEnteredTime where VAID  = @VAID  ";

                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@VAID", id);
                    cmd.Parameters.AddWithValue("@VID", this.cboVehicleNo.SelectedValue);
                    cmd.Parameters.AddWithValue("@AccidentDateTime", this.dtpAccidentDatetime.Value);
                    cmd.Parameters.AddWithValue("@DriverID", this.cboDriver.SelectedValue);
                    cmd.Parameters.AddWithValue("@Location", this.txtLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@SysEnteredTime", this.dtpAccidentDatetime.Text);



                    cmd.ExecuteNonQuery();

                    con.Close();
                    dgvVehicleAccidentRefresh();


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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string qry = "select va.VAID, v.RegistrationNo, va.AccidentDateTime,e.Name,va.Location ,va.Claimed from Vehicle v, VehicleAccident va , Employee e  where v.VID = va.VID and va.DriverID = e.EmpNo and  v.RegistrationNo  = @RegistrationNo";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RegistrationNo", cboVehicleSearch.Text.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();
            da.Fill(tbl);

            dgvVehicleAccident.DataSource = tbl;
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            cboVehicleNo.Focus();
            btnSave.Enabled = true;
            dgvVehicleAccidentRefresh();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            fromDate = dtpAllFrom.Value;
            toDate = dtpAllTo.Value;

            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrVehicleAccidentsAll")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrVehicleAccidentsAll f = new frmCrVehicleAccidentsAll();
                f.Show();
            }
        }

        private void btnViewVehicle_Click(object sender, EventArgs e)
        {
           // VehicleNo = cboCrVehicleNo.Text;
            type = cboType.Text;
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrVehicleType")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrVehicleType f = new frmCrVehicleType();
                f.Show();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
