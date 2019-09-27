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
    public partial class frmRunningChart : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public int vid = 0;
        public string lmr = string.Empty;  //last meter reading
        public static string vehicleno = string.Empty;
        public static DateTime fromDate;
        public static DateTime toDate;
        public static string drivername = string.Empty;
        public frmRunningChart()
        {
            InitializeComponent();
        }

        private void frmRunningChart_Load(object sender, EventArgs e)
        {
            BindData(); // load data into combo box
            cboVehicleNo.SelectedIndex = -1;
            
            ComboboxData();
        }

        private void BindData()

        {
            SqlConnection con = new SqlConnection(cs);
            //Load data into cboVehicle
            string qry = "select VID,VNo from View_ActiveVehicleNos";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboVehicleNo.DataSource = ds.Tables[0];
            cboVehicleNo.DisplayMember = "VNo";
            cboVehicleNo.ValueMember = "VID";
            cboVehicleNo.Enabled = true;
            cboVehicleNo.Font = new Font("Tahoma", 8);
            cboVehicleNo.SelectedItem = null;
            cboVehicleNo.SelectedText = "    ";


            con.Close();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

           


            if (string.IsNullOrEmpty(cboVehicleNo.Text))
            {
                MessageBox.Show("Vehicle Number must not be empty!!", "VehicleNo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if (!Regex.Match(txtMeterReader.Text, "^[1-9]").Success)
            {
                MessageBox.Show("Meter reading must not be empty or \nEntered value is not valid.", "Meter Reading ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReader.Focus();
                return;
            }

            else if (!Regex.Match(txtDescription.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Description must not be empty or \nEntered value is not valid.", "Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return;
            }

            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();

                    ////get last month Meter reading for compair with entered meter reading value

                    string qry2 = "select max(reading) from MeterReading where VID =@VID  ";
                    SqlCommand cmd2 = new SqlCommand(qry2, con);
                    cmd2.Parameters.AddWithValue("@VID", cboVehicleNo.SelectedValue);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    dr2.Read();

                    lmr = (dr2[0]).ToString();   // last merer reading 
                    dr2.Close();

                    int daysLaps = (DateTime.Now - dtpDate.Value).Days;


                    if(daysLaps >= 7)
                    {
                        MessageBox.Show("More than 7 days records are not allowed. Pls contact the transport manager", "not in valid entering period", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpDate.Focus();
                        
                        return;
                    }




                    else if ((Convert.ToInt32(lmr) < Convert.ToInt32(txtMeterReader.Text.Trim())))
                    {
                        string qry = "insert into MeterReading (VID,Reading,Description,Date,EnteredDate,TripLength,EmpNo) values (@VID,@Reading,@Description,@Date,@EnteredDate,@TripLength,@EmpNo)";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.Parameters.AddWithValue("@VID", cboVehicleNo.SelectedValue);
                        cmd.Parameters.AddWithValue("@Reading", txtMeterReader.Text); // get the value member ofthe combobox
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Text.Trim());
                        cmd.Parameters.AddWithValue("@EnteredDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TripLength", tripLengthToDb); // this value set in method "dtpDate_DropDown()"
                        cmd.Parameters.AddWithValue("@EmpNo", cboDriver.SelectedValue);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Save Data successfully", "Running Chart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboVehicleNo.Focus();
                        cleartextboxes();
                        cboVehicleNo.SelectedIndex = -1; // set combobox text as empty
                        lblLastMeterReading.Text = lblTripLength.Text = "....";
                        return;
                    }

                    else
                    {
                        MessageBox.Show("Entered value does not match with last entered value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMeterReader.Focus();
                    }

                    con.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

       
        private void cboVehicleNo_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                vid = Convert.ToInt16(((cboVehicleNo.SelectedValue)));  //combo box dropdown list selected value-member

                SqlConnection con = new SqlConnection(cs);
                string qry = "select max(reading) from MeterReading where VID =@VID  ";
                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@VID", vid);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                lmr = (dr[0]).ToString();   // last merer reading 
                dr.Close();
                con.Close();
                lblLastMeterReading.Text = "Previous meter reading : " + lmr;

                //lmr = string.Empty; 




             }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        
        private void dtpDate_DropDown(object sender, EventArgs e)
        {
            
        }
        public void ComboboxData()  // load data into combo box
        {
            SqlConnection con = new SqlConnection(cs);
            // vehicle no for dropsown list
            con.Open();
            string qry = "select d.EmpNo , e.Name from Driver d , Employee e where d.EmpNo = e.EmpNo";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboDriver.DataSource = ds.Tables[0];
            cboDriver.DisplayMember = "Name";
            cboDriver.ValueMember = "EmpNo";
            cboDriver.Enabled = true;
            cboDriver.SelectedItem = null;

         
            string qry2 = "select VID,RegistrationNo from Vehicle";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            cboRptVehicleNo.DataSource = ds2.Tables[0];
            cboRptVehicleNo.ValueMember = "VID";
            cboRptVehicleNo.DisplayMember = "RegistrationNo";
           
            cboRptVehicleNo.Enabled = true;
            cboRptVehicleNo.Font = new Font("Tahoma", 8);
            cboRptVehicleNo.SelectedItem = null;
            cboRptVehicleNo.SelectedText = "";

            string qry3 = "select d.EmpNo , e.Name from Driver d, Employee e where d.EmpNo = e.EmpNo";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            cboCrDriver.DataSource = ds3.Tables[0];
            cboCrDriver.ValueMember = "EmpNo";
            cboCrDriver.DisplayMember = "Name";

            cboCrDriver.Enabled = true;
            cboCrDriver.Font = new Font("Tahoma", 8);
            cboCrDriver.SelectedItem = null;
            cboCrDriver.SelectedText = "";

            

            con.Close();
        }
        private int tripLengthToDb = 0;
        private void txtDescription_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMeterReader.Text))
            {
                MessageBox.Show("Meter readering must not be empty!!", "VehicleNo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else if (Convert.ToInt32(lmr) >= Convert.ToInt32(txtMeterReader.Text.Trim()))
            {
                MessageBox.Show("Entered value does not match with last entered value", "Previous value > Entered value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReader.Focus();
                return;
            }
            else
            {
                //get just entered meter reading "newmr"   
                int newmr = Convert.ToInt32(txtMeterReader.Text);
                //get previous meter reading ( its from  cboVehicleNo_DropDownClosed() method) convert to int "lmrInt"
                int lmrInt = Convert.ToInt32(lmr);
                //get the difference of both
                string tripLength = Convert.ToString(newmr - lmrInt);

                lblTripLength.Text = "Current trip lenght : " + tripLength + " km.";

                tripLengthToDb = newmr - lmrInt;




            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cboRptVehicleNo.Text) || cboRptVehicleNo.Text == " ")
            {
                MessageBox.Show("Vehicle Number must not be empty!!", "VehicleNo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

            else
            {
                vehicleno = cboRptVehicleNo.Text.Trim(); // these values forwadr to crystal report when it is loading.

                fromDate = dtpStartDate.Value;
                toDate = dtpEndDate.Value;  // dateTimePicker1.Value.ToShortDateString();
               

                bool Isopen = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "frmCrMileageSelective")
                    {
                        Isopen = true;
                        f.BringToFront();
                        break;
                    }
                }
                if (Isopen == false)
                {
                    frmCrMileageSelective f = new frmCrMileageSelective();
                    f.Show();
                }
            }



           
        }

        
        private void btnViewDriver_Click(object sender, EventArgs e)
        {
            drivername = cboCrDriver.Text;
            fromDate = dtpStartDate.Value;
            toDate = dtpEndDate.Value;

            bool Isopen = false;
            foreach (Form f2 in Application.OpenForms)
            {
                if (f2.Text == "frmMileageDriver")
                {
                    Isopen = true;
                    f2.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmMileageDriver f2 = new frmMileageDriver();
                f2.Show();
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            fromDate = dtpStartDate.Value;
            toDate = dtpEndDate.Value;


            bool Isopen = false;
            foreach (Form f3 in Application.OpenForms)
            {
                if (f3.Text == "frmCrMileageAll")
                {
                    Isopen = true;
                    f3.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrMileageAll f3 = new frmCrMileageAll();
                f3.Show();
            }
        }
    }
    }
