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
    public partial class frmVehicle : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int vid = 0;
        SqlConnection con = new SqlConnection(@"Data Source=CHAMINDA\MSSQLSERVER2;Initial Catalog=VMS;User ID=sa;Password=123");
        public frmVehicle()
        {
            InitializeComponent();
        }



        private void frmRegisterVehicle_Load(object sender, EventArgs e)
        {
            txtRegNo.Focus();
            dgvVehicleRefresh();
            dgvVehicle.RowHeadersVisible = false;
            dgvVehicle.AllowUserToAddRows = false;
            dgvVehicle.Rows[0].Cells[0].Selected = false;


            txtRegNo.Enabled = dtpDateReg.Enabled = cboVehicleType.Enabled = txtYearManufact.Enabled = cboBrand.Enabled = txtModel.Enabled = txtChassisNo.Enabled = txtEngineNo.Enabled = txtEnginCapacity.Enabled =
             cboFuelType.Enabled = cboColor.Enabled = cboSeats.Enabled = cboStatus.Enabled =
             txtGPSNo.Enabled = cboTransmission.Enabled = txtMeterReading.Enabled =    false;

            //load data to combo box
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            string qry = "select VID, RegistrationNo from Vehicle";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboSearch.DataSource = ds.Tables[0];
            cboSearch.DisplayMember = "RegistrationNo";
            cboSearch.ValueMember = "VID";
            cboSearch.Enabled = true;

            con.Close();





        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            btnUpdate.Enabled = btnDelete.Enabled = true;

            // ---- form data validation ------------------------------------------------------------

            if (!Regex.Match(txtRegNo.Text, "^[A-Z0-9-d]{7,10}$").Success) // acept only capital letters , numbers & "-"
            {
                MessageBox.Show("Please enter valid Registration Number." + "\n" + "eg : KW-1234 / CAP-2592 / 65-7876");
                txtRegNo.Focus();
                return;
            }

            else if ( String.IsNullOrEmpty(cboVehicleType.Text))  
            {
                MessageBox.Show("Please enter vehicle Type.");
                cboVehicleType.Focus();
                return;
            }

            else if (!Regex.IsMatch(txtYearManufact.Text, "^[0-9]{4}$"))
            {
                MessageBox.Show("Please enter vehicle manufactured year.");
                txtYearManufact.Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(cboBrand.Text, @"[a-zA-Z]"))
            {
                MessageBox.Show("Please enter vehicle Brand.");
                 Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtModel.Text, @"[0-9a-zA-Z]$"))
            {
                MessageBox.Show("Please enter vehicle Model.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtChassisNo.Text, @"[0-9a-zA-Z]$"))
            {
                MessageBox.Show("Please enter valid vehicle ChassisNo.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtEngineNo.Text, @"[0-9a-zA-Z]$"))
            {
                MessageBox.Show("Please enter valid  vehicle EngineNo.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtEnginCapacity.Text, @"[0-9]$"))
            {
                MessageBox.Show("Please enter valid  vehicle Engin-Capacity.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(cboFuelType.Text, @"[a-zA-Z]$"))
            {
                MessageBox.Show("Please select Fuel Type.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(cboColor.Text, @"[a-zA-Z]$"))
            {
                MessageBox.Show("Please select vehicle color.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(cboSeats.Text, @"[0-9]$"))
            {
                MessageBox.Show("Please enter number of seats.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(cboStatus.Text, @"[a-zA-Z]$"))
            {
                MessageBox.Show("Please select vehicle status.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(cboTransmission.Text, @"[a-zA-Z]$"))
            {
                MessageBox.Show("Please select transmission type.");
                Focus();
                return;
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtMeterReading.Text, @"[0-9]$"))
            {
                MessageBox.Show("Please enter initial meter reading.");
                Focus();
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtInsuPolicyNo.Text, @"[0-9a-zA-Z]$"))
            {
                MessageBox.Show("Please enter valid  for Insurance Plolicy No.");
                Focus();
                return;
            }

            // ----end of the form dara validation ------------------------------------------------------------
            else
            {
                try
                {
                    string qry = "insert into Vehicle (RegistrationNo, RegDate,VehicleType, ManufacturedYear,Brand, Model, ChassisNo, EngineNo, EngineCapacity, FuelType, Color, Seats,Status, GPSNo, Transmission,IsAllocated,InsuPolicyNo) values(@RegistrationNo, @RegDate, @VehicleType, @ManufacturedYear, @Brand, @Model, @ChassisNo, @EngineNo,@EngineCapacity, @FuelType, @Color, @Seats, @Status, @GPSNo, @Transmission,@IsAllocated,@InsuPolicyNo)";

                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@RegistrationNo", txtRegNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@RegDate", dtpDateReg.Value.ToString("MM/dd/yyyy").Trim()); //CAST as datetime)
                    cmd.Parameters.AddWithValue("@VehicleType", cboVehicleType.Text.Trim());
                    cmd.Parameters.AddWithValue("@ManufacturedYear", txtYearManufact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Brand", cboBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChassisNo", txtChassisNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@EngineNo", txtEngineNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@EngineCapacity", txtEnginCapacity.Text.Trim());
                    cmd.Parameters.AddWithValue("@FuelType", cboFuelType.Text.Trim());
                    cmd.Parameters.AddWithValue("@Color", cboColor.Text.Trim());
                    cmd.Parameters.AddWithValue("@Seats", cboSeats.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", cboStatus.Text.Trim());
                    cmd.Parameters.AddWithValue("@GPSNo", txtGPSNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Transmission", cboTransmission.Text.Trim());
                    cmd.Parameters.AddWithValue("@IsAllocated",0);
                    cmd.Parameters.AddWithValue("@InsuPolicyNo",txtInsuPolicyNo.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    dgvVehicleRefresh();

                    MessageBox.Show("Saved successfully");

                    // get the VID from newly entered vehicle details
                    string qry3 = "select VID from Vehicle where RegistrationNo = @RegistrationNo";
                    SqlCommand cmd3 = new SqlCommand(qry3, con);
                    con.Open();
                    cmd3.Parameters.AddWithValue("@RegistrationNo", txtRegNo.Text.Trim());
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    dr3.Read();
                    string vehid = (dr3[0]).ToString();   // new vehicle VID
                    dr3.Close();

                    //entered new record to table MeterReading
                    string qry2 = "insert into MeterReading (VID,Reading,Description,Date,Entereddate) values(@VID,@Reading,@Description,@Date,@Entereddate)";
                    SqlCommand cmd2 = new SqlCommand(qry2, con);
                    cmd2.Parameters.AddWithValue("@VID",vehid);
                    cmd2.Parameters.AddWithValue("@Reading",txtMeterReading.Text.Trim());
                    cmd2.Parameters.AddWithValue("@Description", "Initial Meter Reading(Starting point)");
                    cmd2.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@Entereddate", DateTime.Now);
                    cmd2.ExecuteNonQuery();

                    con.Close();                    

                    cleartextboxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message");
                }
            }            
        }

        private void dgvVehicleRefresh()
        {
            string qry = "select * from Vehicle where status <> 'Retired'";
            
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvVehicle.DataSource = tbl;
            con.Close();

            dgvVehicle.AllowUserToAddRows = false;
            dgvVehicle.ClearSelection();
        }

        private void dgvVehicle_CellClick(object sender, DataGridViewCellEventArgs e)  // when click dgv , load data into controlers.
        {
            //enable controls where disabled in form load
            txtRegNo.Enabled = dtpDateReg.Enabled = cboVehicleType.Enabled = txtYearManufact.Enabled = cboBrand.Enabled = txtModel.Enabled = txtChassisNo.Enabled = txtEngineNo.Enabled = txtEnginCapacity.Enabled =
           cboFuelType.Enabled = cboColor.Enabled = cboSeats.Enabled = cboStatus.Enabled =
           txtGPSNo.Enabled = cboTransmission.Enabled = txtMeterReading.Enabled = true;
            
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            try
            {
                DataGridViewRow dgvRow = dgvVehicle.Rows[e.RowIndex];
                vid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());

                txtRegNo.Text = dgvRow.Cells[1].Value.ToString();
                dtpDateReg.Text = dgvRow.Cells[2].Value.ToString();
                cboVehicleType.Text = dgvRow.Cells[3].Value.ToString();
                txtYearManufact.Text = dgvRow.Cells[4].Value.ToString();
                cboBrand.Text = dgvRow.Cells[5].Value.ToString();
                txtModel.Text = dgvRow.Cells[6].Value.ToString();
                txtChassisNo.Text = dgvRow.Cells[7].Value.ToString();
                txtEngineNo.Text = dgvRow.Cells[8].Value.ToString();
                txtEnginCapacity.Text = dgvRow.Cells[9].Value.ToString();
                cboFuelType.Text = dgvRow.Cells[10].Value.ToString();
                cboColor.Text = dgvRow.Cells[11].Value.ToString();
                cboSeats.Text = dgvRow.Cells[12].Value.ToString();
                cboStatus.Text = dgvRow.Cells[13].Value.ToString();
                txtGPSNo.Text = dgvRow.Cells[14].Value.ToString();
                cboTransmission.Text = dgvRow.Cells[16].Value.ToString();
                txtInsuPolicyNo.Text = dgvRow.Cells[18].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select VID.  " + ex.Message);
            }  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRegNo.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete ?", "delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string qry = " delete from Vehicle where   VID  = @VID  ";
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@VID", vid);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    dgvVehicleRefresh();
                    cleartextboxes();
                }
            }
            else
            {
                MessageBox.Show("Please click on the VID from the grid");
            }

            btnSave.Enabled = true;
            btnAdd.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRegNo.Text))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string qry = "update Vehicle set RegistrationNo	= @RegistrationNo,RegDate	= @RegDate,VehicleType	= @VehicleType,ManufacturedYear	= @ManufacturedYear, Brand	= @Brand, Model	= @Model,ChassisNo = @ChassisNo, EngineNo = @EngineNo, EngineCapacity = @EngineCapacity, FuelType = @FuelType, Color = @Color, Seats = @Seats, Status = @Status, GPSNo = @GPSNo,Transmission = @Transmission, InsuPolicyNo=@InsuPolicyNo  where VID = @VID ";

                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@VID", vid);
                    cmd.Parameters.AddWithValue("@RegistrationNo", txtRegNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@RegDate", Convert.ToDateTime(dtpDateReg.Text.Trim()));
                    cmd.Parameters.AddWithValue("@VehicleType", cboVehicleType.Text.Trim());
                    cmd.Parameters.AddWithValue("@ManufacturedYear", txtYearManufact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Brand", cboBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                    cmd.Parameters.AddWithValue("@ChassisNo", txtChassisNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@EngineNo", txtEngineNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@EngineCapacity", txtEnginCapacity.Text.Trim());
                    cmd.Parameters.AddWithValue("@FuelType", cboFuelType.Text.Trim());
                    cmd.Parameters.AddWithValue("@Color", cboColor.Text.Trim());
                    cmd.Parameters.AddWithValue("@Seats", cboSeats.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", cboStatus.Text.Trim());
                    cmd.Parameters.AddWithValue("@GPSNo", txtGPSNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Transmission", cboTransmission.Text.Trim());
                    cmd.Parameters.AddWithValue("@InsuPolicyNo", txtInsuPolicyNo.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();

                    cleartextboxes();
                    dgvVehicleRefresh();
                    btnSave.Enabled = true;
                    btnAdd.Enabled = true;

                    MessageBox.Show("Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRegNo.Focus();


                }

                else
                {
                    MessageBox.Show("Please click on the VID from the grid", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid data. "+ ex.Message);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtRegNo.Enabled = dtpDateReg.Enabled = cboVehicleType.Enabled = txtYearManufact.Enabled = cboBrand.Enabled = txtModel.Enabled = txtChassisNo.Enabled = txtEngineNo.Enabled = txtEnginCapacity.Enabled =
             cboFuelType.Enabled = cboColor.Enabled = cboSeats.Enabled = cboStatus.Enabled =
             txtGPSNo.Enabled = cboTransmission.Enabled = txtMeterReading.Enabled = true;

            cleartextboxes();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string qry = "select * from Vehicle where RegistrationNo = @RegistrationNo ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RegistrationNo", cboSearch.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();
            da.Fill(tbl);

            dgvVehicle.DataSource = tbl;
            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            dgvVehicleRefresh();
            cboSearch.Text = string.Empty;

            btnAdd.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}
