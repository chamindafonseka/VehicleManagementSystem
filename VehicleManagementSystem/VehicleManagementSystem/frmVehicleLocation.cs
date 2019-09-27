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

namespace VehicleManagementSystem
{
    public partial class frmVehicleLocation : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public frmVehicleLocation()
        {
            InitializeComponent();
        }


        private void loadComboBoxData()
        {
            
            string qry = "select tv.VID[VID] , v.RegistrationNo[RegistrationNo], t.TeamPhone[TeamPhone] from TeamVehicle tv, Vehicle v ,Team t where tv.VID = v.VID and t.TeamID = tv.TeamID and  tv.Status = 1";

            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboVehicleNo.DataSource = ds.Tables[0];
            cboVehicleNo.DisplayMember = "RegistrationNo";
            cboVehicleNo.ValueMember = "VID";
            cboVehicleNo.Enabled = true;
            cboVehicleNo.SelectedItem = null;
            
            con.Close();

        }

        private void frmVehicleLocation_Load(object sender, EventArgs e)
        {
            loadComboBoxData();
        }

        private void btnSelectVehicle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboVehicleNo.Text))
            {
                MessageBox.Show("Vehicle No.  must not be empty or \nEntered value is not valid.", "Vehicle No", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }
            else
            {


            }
        }
    }
}
