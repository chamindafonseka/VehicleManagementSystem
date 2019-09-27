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
    public partial class frmVehicleManagementSystem : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public frmVehicleManagementSystem()
        {
            InitializeComponent();
            this.ControlBox = false;  // remove the windows form close button

        }

        private void vehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //    prevent open the same form again when it opened  
            bool Isopen = false;

            foreach (Form f2 in Application.OpenForms)
            {
                if (f2.Text == "Vehicle")
                {
                    Isopen = true;
                    f2.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                frmVehicle frmRegisterVehicle1 = new frmVehicle();
                frmRegisterVehicle1.Show();
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    prevent open the same form again when it opened  
            bool Isopen = false;

            foreach (Form f3 in Application.OpenForms)
            {
                if (f3.Text == "Employee")
                {
                    Isopen = true;
                    f3.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {

                frmRegEmployee frmemployee1 = new frmRegEmployee();
                frmemployee1.Show();
            }
        }




        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
                MessageBox.Show("Are you sure you want to exit the program", "important Question Asked", MessageBoxButtons.YesNoCancel))
            {
                this.Close();

                // insert the logout details in to table: UserLoggings (type=1:login  / type=2:logout)

                SqlConnection con = new SqlConnection(cs);
                con.Open();

                SqlCommand cmd2 = new SqlCommand("insert into UserLoggings (Appuser, LoggedDate, Type) " + "values('" + frmLogin.userid + "','" + DateTime.Now + "' ,'" + 2 + "')", con);
                cmd2.ExecuteNonQuery();

                con.Close();


                //close all opened forms
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    Application.OpenForms[i].Close();
                }

            }


        }


        private void routeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    prevent open the same form again when it opened  
            bool Isopen = false;

            foreach (Form f4 in Application.OpenForms)
            {
                if (f4.Text == "Route")
                {
                    Isopen = true;
                    f4.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                frmRoute frmroute1 = new frmRoute();
                frmroute1.Show();
            }

        }


        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    prevent open the same form again when it opened  
            bool Isopen = false;

            foreach (Form f5 in Application.OpenForms)
            {
                if (f5.Text == "Branch")
                {
                    Isopen = true;
                    f5.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                frmBranch frmbranch1 = new frmBranch();
                frmbranch1.Show();
            }
        }


        private void frmVehicleManagementSystem_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = "Logged user : " + frmLogin.uname; //logged user
            this.WindowState = FormWindowState.Maximized;  //full screen form

            ////...........set all menustrip items enabled = false

            //attendanceUploadToolStripMenuItem.Enabled = false;

            ////for (int i = 0; i < menuStrip1.Items.Count; i++)
            ////{
            ////    menuStrip1.Items[i].Enabled = true;
            ////}

            
            userrightsToolStripMenuItem.Enabled = false;
            changePasswordToolStripMenuItem.Enabled = false;
            signOutToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = false;
            vehicleToolStripMenuItem.Enabled = false;
            employeeToolStripMenuItem.Enabled = false;
            teamToolStripMenuItem.Enabled = false;
            routeToolStripMenuItem.Enabled = false;
            branchToolStripMenuItem.Enabled = false;
            serviceCenterToolStripMenuItem.Enabled = false;
            garageToolStripMenuItem.Enabled = false;
            itemToolStripMenuItem.Enabled = false;
            licenseProviderToolStripMenuItem.Enabled = false;
            
            runningChartToolStripMenuItem.Enabled = false;
            fuelFillingToolStripMenuItem.Enabled = false;
            serviceToolStripMenuItem1.Enabled = false;
            repairToolStripMenuItem.Enabled = false;
            otherExpensesToolStripMenuItem.Enabled = false;
            fitnessCertificateToolStripMenuItem.Enabled = false;
            tyreAssignmentToolStripMenuItem.Enabled = false;
            otherMaterialIssuesToolStripMenuItem.Enabled = false;
            
            emissionTestToolStripMenuItem.Enabled = false;
            
            insuranceClaimToolStripMenuItem.Enabled = false;
            employeeTeamAssignmentToolStripMenuItem.Enabled = false;
            sendSMSToolStripMenuItem.Enabled = false;
            readSMSToolStripMenuItem.Enabled = false;
            userManualToolStripMenuItem.Enabled = false;
            versionToolStripMenuItem.Enabled = false;
            feedbackToolStripMenuItem.Enabled = false;
            attendanceUploadToolStripMenuItem.Enabled = false;
            driverToolStripMenuItem.Enabled = false;
            editAttendanceToolStripMenuItem.Enabled = false;
            inquieyToolStripMenuItem.Enabled = false;
            storeADocumentToolStripMenuItem.Enabled = false;
            readSMSToolStripMenuItem.Enabled = false;
            fillingStationToolStripMenuItem.Enabled = false;
            supplierToolStripMenuItem.Enabled = false;
            attendaenceToolStripMenuItem.Enabled = false;


            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("select  a.userid,  m.MenuItemName from UserMenuRights u, MenuItem m , AppUser a where m.Flag=1 and  m.MenuItemID = u.menuitemid and a.userid = u.userid and a.UserName =@username", con);
            cmd.Parameters.AddWithValue("@username", frmLogin.uname);

            //MessageBox.Show(frmLogin.uname);
            SqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                var a = menuStrip1.Items.Find(myReader.GetString(1), true);   // menuitem extract >> get only string
                a[0].Enabled = true;
            }
            myReader.Close();




            con.Close();

            GetNosEmployees(); //presented nos of employees for the day
            GetNosDriver(); //presented nos of employees for the day
            GetNosTechnician();//presented nos of Technicians for the day
            GetNosVehicles(); // nos of vehicles available
            dgvVehiclesAvailableRefresh();//load data to dgvVehiclesAvailable 






        }

        private void GetNosEmployees()
        {
            var qry = "select COUNT(e.EmpNo)[EmpCount] from employee e, Attendance a where e.EPFNo = a.EPFNo and e.Status = 1 and a.status = 1";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand(qry, con);
            lblEmpCount.Text = Convert.ToString(cmd.ExecuteScalar());

            con.Close();
        }

        private void GetNosDriver()
        {
            var qry = "select COUNT(e.EmpNo) from employee e, Attendance a , Driver d where e.EPFNo = a.EPFNo and e.EmpNo = d.EmpNo and e.Status = 1 and a.status = 1";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand(qry, con);
            lbnDriverCount.Text = Convert.ToString(cmd.ExecuteScalar());

            con.Close();
        }

        private void GetNosTechnician()
        {
            var qry = "select count(e.EmpNo) from employee e, Attendance a where e.EPFNo = a.EPFNo and e.Status = 1 and a.status = 1 and e.EmpNo not in (select EmpNo from Driver )";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand(qry, con);
            lbnNosOfTechnicians.Text = Convert.ToString(cmd.ExecuteScalar());

            con.Close();
        }
        private void GetNosVehicles()
        {
            var qry = "select  count( v.VID) from Vehicle v where v.Status = 'Active'";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand(qry, con);
            lblNosOfVehicles.Text = Convert.ToString(cmd.ExecuteScalar());

            con.Close();
        }

        private void dgvVehiclesAvailableRefresh()
        {
            try
            {
                string qry = "select v.VehicleType, count( v.VID) from Vehicle v where v.Status = 'Active' group by v.VehicleType";

                SqlConnection con = new SqlConnection(cs);

                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                con.Open();
                DataTable tbl = new DataTable();

                da.Fill(tbl);
                dgvVehiclesAvailable.DataSource = tbl;
                con.Close();

                dgvVehiclesAvailable.AllowUserToAddRows = false;
                dgvVehiclesAvailable.ClearSelection();

                dgvVehiclesAvailable.ColumnHeadersVisible = false;
                dgvVehiclesAvailable.RowHeadersVisible = false;
                dgvVehiclesAvailable.Columns[0].Width = 100;
                dgvVehiclesAvailable.Columns[1].Width = 60;
                dgvVehiclesAvailable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVehiclesAvailable.GridColor = Color.White;

                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void teamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    prevent open the same form again when it opened  
            bool Isopen = false;

            foreach (Form f6 in Application.OpenForms)
            {
                if (f6.Text == "frmTeam")
                {
                    Isopen = true;
                    f6.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                frmTeam frmTeam1 = new frmTeam();
                frmTeam1.Show();
            }


        }

        private void serviceCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    prevent open the same form again when it opened  
            bool Isopen = false;

            foreach (Form f7 in Application.OpenForms)
            {
                if (f7.Text == "ServiceCenter")
                {
                    Isopen = true;
                    f7.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                frmServiceCenter f = new frmServiceCenter();
                f.Show();
            }
        }

        private void garageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    prevent open the same form again when it opened  
            bool Isopen = false;

            foreach (Form f8 in Application.OpenForms)
            {
                if (f8.Text == "Garage")
                {
                    Isopen = true;
                    f8.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                frmGarage f = new frmGarage();
                f.Show();
            }
        }






        private void userrightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "User Rights")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmUserRights f = new frmUserRights();
                f.Show();
            }
        }

        private void attendanceUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f10 in Application.OpenForms)
            {
                if (f10.Text == "Attendance")
                {
                    Isopen = true;
                    f10.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmAttendance f10 = new frmAttendance();
                f10.Show();
            }
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

            //close all opened forms
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Application.OpenForms[i].Close();
            }




        }



        private void licenseProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f12 in Application.OpenForms)
            {
                if (f12.Text == "License Provider")
                {
                    Isopen = true;
                    f12.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmLicenseProvider f12 = new frmLicenseProvider();
                f12.Show();
            }
        }


        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f13 in Application.OpenForms)
            {
                if (f13.Text == "Driver")
                {
                    Isopen = true;
                    f13.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmDriver f13 = new frmDriver();
                f13.Show();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f14 in Application.OpenForms)
            {
                if (f14.Text == "Change Password")
                {
                    Isopen = true;
                    f14.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmChangePassword f14 = new frmChangePassword();
                f14.Show();
            }

        }

        private void employeeTeamAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f15 in Application.OpenForms)
            {
                if (f15.Text == "Team Employee Assignment")
                {
                    Isopen = true;
                    f15.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmTeamEmployee f15 = new frmTeamEmployee();
                f15.Show();
            }
        }

        private void runningChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Running Chart")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmRunningChart f = new frmRunningChart();
                f.Show();
            }
        }

        private void fuelFillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Fuel Filling")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmFuelFilling f = new frmFuelFilling();
                f.Show();
            }

        }

        private void repairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Vehicle Repairing")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmRepair f = new frmRepair();
                f.Show();
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Item")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmItem f = new frmItem();
                f.Show();
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {


            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Supplier Registration")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmSupplier f = new frmSupplier();
                f.Show();
            }

        }

        private void otherExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Other Expense")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmOtherExpense f = new frmOtherExpense();
                f.Show();
            }
        }

        private void storeADocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {


            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Document Store")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmDocumentStore f = new frmDocumentStore();
                f.Show();
            }
        }

        private void attendaenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void serviceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Servicecs")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmServicecs f = new frmServicecs();
                f.Show();
            }
        }

        private void frmVehicleManagementSystem_Click(object sender, EventArgs e)
        {
            //get present emplyees on the current date
            //Employee.status=1 means active employee
            //Attendance.status=1 means very latest record.


            string qry = @"select count(e.EPFNo) from Employee e where e.Status = 1 and e.epfno   in (select epfno from Attendance where status = 1)";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);

            int presentEmployee = (int)cmd.ExecuteScalar();


            // max arrendance date 


        }

        private void editAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Edit Attendance")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmEditAttendance f = new frmEditAttendance();
                f.Show();
            }
        }

        private void fillingStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Filling Station")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmFillingStation f = new frmFillingStation();
                f.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvVehiclesAvailableRefresh();
            GetNosEmployees();
            GetNosDriver();
            GetNosTechnician();
            GetNosVehicles();

            Form f = new Form();
            f.Refresh();
        }

        //private void revenueLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    bool Isopen = false;
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f.Text == "Revenu License")
        //        {
        //            Isopen = true;
        //            f.BringToFront();
        //            break;
        //        }
        //    }
        //    if (Isopen == false)
        //    {
        //        frmRevenuLicense f = new frmRevenuLicense();
        //        f.Show();
        //    }
        //}

        private void emissionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Insurance Emission Revenue")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmInsuranceEmissionRevenue f = new frmInsuranceEmissionRevenue();
                f.Show();
            }
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f9 in Application.OpenForms)
            {
                if (f9.Text == "Send Message")
                {
                    Isopen = true;
                    f9.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmSMS f = new frmSMS();
                f.Show();
            }
        }

        private void readSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f18 in Application.OpenForms)
            {
                if (f18.Text == "Read Message")
                {
                    Isopen = true;
                    f18.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmReadSMS f = new frmReadSMS();
                f.Show();
            }
        }

        private void vehicleLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f19 in Application.OpenForms)
            {
                if (f19.Text == "Vehicle Location")
                {
                    Isopen = true;
                    f19.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmVehicleLocation f = new frmVehicleLocation();
                f.Show();
            }
        }

        private void vehicleAccidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f20 in Application.OpenForms)
            {
                if (f20.Text == "Vehicle Accident")
                {
                    Isopen = true;
                    f20.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmVehicleAccident f = new frmVehicleAccident();
                f.Show();
            }
        }

        private void insuranceClaimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f21 in Application.OpenForms)
            {
                if (f21.Text == "Insurance Claim")
                {
                    Isopen = true;
                    f21.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmInsuranceClaim f = new frmInsuranceClaim();
                f.Show();
            }
        }

        private void lblEmpCount_Click(object sender, EventArgs e)
        {

        }

        private void registrationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f22 in Application.OpenForms)
            {
                if (f22.Text == "frmCurrentAttendance")
                {
                    Isopen = true;
                    f22.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCurrentAttendance f = new frmCurrentAttendance();
                f.Show();
            }

        }
    }
}

