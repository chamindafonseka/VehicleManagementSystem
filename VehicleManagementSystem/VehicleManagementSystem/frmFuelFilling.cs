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
    
    public partial class frmFuelFilling : Form
    {

        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public static DateTime fromDate ;
        public static DateTime toDate;
        public static string vehicleno = string.Empty;
        public static string crvehicleno = string.Empty;
        public frmFuelFilling()
        {
            InitializeComponent();
            BindData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(cboVehicleNo.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Vehicle Number must not be empty or \nEntered value is not valid.", "Vehicle No", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }
            else if (!Regex.Match(txtMeterReading.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Meter reading must not be empty or \nEntered value is not valid.", "Meter Reading", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMeterReading.Focus();
                return;
            }
            else if (!Regex.Match(txtReceiptNo.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Receipt Number must not be empty or \nEntered value is not valid.", "Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReceiptNo.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(dtpReceiptDate.Text))
            {
                MessageBox.Show("Receipt date must not be empty or \nEntered value is not valid.", "Receipt Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpReceiptDate.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cboFuelType.Text))
            {
                MessageBox.Show("Fuel Type must not be empty or \nEntered value is not valid.", "Fuel Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboFuelType.Focus();
                return;
            }

            else if (!Regex.Match(txtCapacity.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Capacity must not be empty or \nEntered value is not valid.", "Capaciry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCapacity.Focus();
                return;
            }
            else if (!Regex.Match(txtAmount.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Amount must not be empty or \nEntered value is not valid.", "Receipt Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }
            else if (!Regex.Match(cboPaymentMethod.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Payment method must not be empty or \nEntered value is not valid.", "Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPaymentMethod.Focus();
                return;
            }
            else if (!Regex.Match(cboFillingStation.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Filling Station  must not be empty or \nEntered value is not valid.", "Filling Station", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboFillingStation.Focus();
                return;
            }


            else
            {
                string qry = "insert into Fuel (VID, MeterReading, ReceiptNo, ReceiptDate, FuelTypeID, Capacity, Amount, PaymentMethodID,FillingStationID,UserID,EnteredDate ) values (@VID, @MeterReading, @ReceiptNo, @ReceiptDate, @FuelTypeID, @Capacity, @Amount, @PaymentMethodID, @FillingStationID,@UserID,@EnteredDate)";
                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@VID", cboVehicleNo.SelectedValue);
                cmd.Parameters.AddWithValue("@MeterReading", txtMeterReading.Text.Trim());
                cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text.Trim());
                cmd.Parameters.AddWithValue("ReceiptDate", dtpReceiptDate.Text);
                cmd.Parameters.AddWithValue("FuelTypeID", cboFuelType.SelectedValue);
                cmd.Parameters.AddWithValue("@Capacity", txtCapacity.Text);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@PaymentMethodID", cboPaymentMethod.SelectedValue);
                cmd.Parameters.AddWithValue("@FillingStationID", cboFillingStation.SelectedValue);
                cmd.Parameters.AddWithValue("@UserID", frmLogin.userid);
                cmd.Parameters.AddWithValue("@EnteredDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartextboxes();
                //dgvTeamRefresh();
            }

        }
        public void BindData()  // load data into combo box
        {
            SqlConnection con = new SqlConnection(cs);
            // vehicle no for dropsown list
            con.Open();
            string qry = "select VID, RegistrationNo from Vehicle where  status not like 'Retired%'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboVehicleNo.DataSource = ds.Tables[0];
            cboVehicleNo.DisplayMember = "RegistrationNo";
            cboVehicleNo.ValueMember = "VID";
            cboVehicleNo.Enabled = true;
            cboVehicleNo.SelectedItem = null;

            //load data to combo box for crystal report
            SqlCommand cmd5 = new SqlCommand(qry, con);
            SqlDataAdapter da5 = new SqlDataAdapter(qry, con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);

            cboVehicle.DataSource = ds5.Tables[0];
            cboVehicle.DisplayMember = "RegistrationNo";
            cboVehicle.ValueMember = "VID";
            cboVehicle.Enabled = true;
            cboVehicle.SelectedItem = null;

            //payment method drop down list
            string qry2 = "select PaymentMethodID, MethodName from paymentmethod";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            cboPaymentMethod.DataSource = ds2.Tables[0];
            cboPaymentMethod.DisplayMember = "MethodName";
            cboPaymentMethod.ValueMember = "PaymentMethodID";
            cboPaymentMethod.Enabled = true;
            cboPaymentMethod.SelectedItem = null;

            //Filling Station
            string qry3 = "select FillSID, Name from FillingStation where deleted=0";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(qry3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            cboFillingStation.DataSource = ds3.Tables[0];
            cboFillingStation.DisplayMember = "Name";
            cboFillingStation.ValueMember = "FillSID";
            cboFillingStation.Enabled = true;
            cboFillingStation.SelectedItem = null;

            //Fuel type
            string qry4 = "SELECT FTID, Name FROM  FuelType";
            SqlCommand cmd4 = new SqlCommand(qry4, con);
            SqlDataAdapter da4 = new SqlDataAdapter(qry4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            cboFuelType.DataSource = ds4.Tables[0];
            cboFuelType.DisplayMember = "Name";
            cboFuelType.ValueMember = "FTID";
            cboFuelType.Enabled = true;
            cboFuelType.SelectedItem = null;

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

        private void btnView_Click(object sender, EventArgs e)
        {
            
            fromDate =    dtpAllFrom.Value;
            toDate = dtpAllTo.Value;

            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrFuelUseageAll")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrFuelUseageAll f = new frmCrFuelUseageAll();
                f.Show();
            }
        }

        private void frmFuelFilling_Load(object sender, EventArgs e)
        {
            
        }

        public static DateTime fromDateSelective;
        public static DateTime toDateSelective;
        private void btnVehicleNoSelective_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboVehicle.Text))
            {
                MessageBox.Show("Vehicle Number must not be empty or \nEntered value is not valid.", "Receipt Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpReceiptDate.Focus();
                return;
            }

            else
            {
                fromDateSelective = dtpFromSelected.Value;
                toDateSelective = dtpToSelected.Value;
                vehicleno = cboVehicle.Text;

                bool Isopen = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "frmCrFuelUseageSelective")
                    {
                        Isopen = true;
                        f.BringToFront();
                        break;
                    }
                }
                if (Isopen == false)
                {
                    frmCrFuelUseageSelective f = new frmCrFuelUseageSelective();
                    f.Show();
                }

            }

        }
    }
}
