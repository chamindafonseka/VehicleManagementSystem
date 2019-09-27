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
using System.Collections;

namespace VehicleManagementSystem
{
    public partial class frmTeamEmployee : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public static string allocaedTName; //refer by frmTeamDetails
        public static string allocatedVName;
        public static string AllocaedTName
        {
            get { return allocaedTName; }
            set { allocaedTName = value; }
        }

        private static string allocaedEmpName; // refer by frmEmployeeDetails
        public static string AllocaedEmpName
        {
            get { return allocaedEmpName; }
            set { allocaedEmpName = value; }
        }

        


        public frmTeamEmployee()
        {
            InitializeComponent();            
        }

        private void frmTeamEmployee_Load(object sender, EventArgs e)
        {
            //available teams
            dgvTeamAvialble.RowHeadersVisible = false;
            string qry = "select Name from team where IsAllocated = 0";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            dgvTeamAvialble.DataSource = tbl;
            DataGridViewColumn tcolum = dgvTeamAvialble.Columns[0];
            //tcolum.Width = 40;
            dgvTeamAvialble.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTeamAvialble.ClearSelection(); // default selection removing 
            dgvTeamAvialble.AllowUserToAddRows = false;




            //available Employees
            dgvEmployeeAvailable.RowHeadersVisible = false;
            string qry2 = "select e.EPFNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.epfno in (select a.epfno from Attendance a where a.status = 1 )";
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataTable tbl2 = new DataTable();
            da2.Fill(tbl2);
            dgvEmployeeAvailable.DataSource = tbl2;
            DataGridViewColumn ecolum = dgvEmployeeAvailable.Columns[0];
            ecolum.Width = 40;
            dgvEmployeeAvailable.DefaultCellStyle.Font = new Font("Tahoma", 7);
            dgvEmployeeAvailable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployeeAvailable.ClearSelection(); // default selection removing 
            dgvEmployeeAvailable.AllowUserToAddRows = false;


            //Teams assigned
            dgvTeamsAllocated.RowHeadersVisible = false;
            string qry3 = "select Name from team where IsAllocated = 1";
            SqlDataAdapter da3 = new SqlDataAdapter(qry3, con);
            DataTable tbl3 = new DataTable();
            da3.Fill(tbl3);
            dgvTeamsAllocated.DataSource = tbl3;
            DataGridViewColumn tcolum3 = dgvTeamsAllocated.Columns[0];
            //tcolum3.Width = 40;
            dgvTeamsAllocated.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTeamsAllocated.ColumnHeadersVisible = false;
            dgvTeamsAllocated.ClearSelection(); // default selection removing
            dgvTeamsAllocated.AllowUserToAddRows = false;

            //Allocated Employees
            dgvEmployeesAllocated.RowHeadersVisible = false;
            string qry4 = "select e.EPFNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 1 and e.epfno in (select a.epfno from Attendance a where a.status = 1 )";
            SqlDataAdapter da4 = new SqlDataAdapter(qry4, con);
            DataTable tbl4 = new DataTable();
            da4.Fill(tbl4);
            dgvEmployeesAllocated.DataSource = tbl4;
            DataGridViewColumn ecolum4 = dgvEmployeesAllocated.Columns[0];
            ecolum4.Width = 40;
            dgvEmployeesAllocated.DefaultCellStyle.Font = new Font("Tahoma", 7);
            dgvEmployeesAllocated.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployeesAllocated.ColumnHeadersVisible = false;
            dgvEmployeesAllocated.ClearSelection(); // default selection removing 
            dgvEmployeesAllocated.AllowUserToAddRows = false;

            //

            con.Close();
            
            //Load data to combo boxes
            BindData();

        }

        private void dgvTeamsAllocated_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvTeamsAllocated.Rows[e.RowIndex]; //create row object
                allocaedTName = (dgvRow.Cells[0].Value.ToString()); // extract the first cell value - allocated name

                SqlConnection con = new SqlConnection(cs);
                string qry = "select v.RegistrationNo from Team t, TeamVehicle tv, Vehicle v where t.TeamID = tv.TeamID and tv.VID = v.VID and v.IsAllocated = 1 and t.Name like 'HO Team Dehiwala'";
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                con.Open();
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                allocatedVName = tbl.Rows[0].ItemArray[0].ToString(); // extract the vehicle name to view in frmteamDetails






                bool Isopen = false;
                foreach (Form f1 in Application.OpenForms)
                {
                    if (f1.Text == "frmTeamdetail")
                    {
                        Isopen = true;
                        f1.BringToFront();
                        break;
                    }
                }
                if (Isopen == false)
                {
                    frmTeamdetail frmTeam1 = new frmTeamdetail();
                    frmTeam1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BindData()  // load data into combo box
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            // load data to Team combo box
            string qry = "select TeamID, Name from team  where IsAllocated =0";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            cboTeam.DataSource = ds.Tables[0];
            cboTeam.DisplayMember = "Name";  
            cboTeam.ValueMember = "TeamID";
            cboTeam.Enabled = true;
            cboTeam.SelectedItem = null;

            //load data to Driver combo box
            string qry7 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.EPFNo in (select a.EPFNo from Attendance a where a.status = 1 ) and e.EmpNo in (select d.EmpNo from Driver d where d.IsDeleted=0 ) ";
            SqlCommand cmd7 = new SqlCommand(qry7, con);
            SqlDataAdapter da7 = new SqlDataAdapter(qry7, con);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);

            cboDriver.DataSource = ds7.Tables[0];
            cboDriver.DisplayMember = "Name";
            cboDriver.ValueMember = "EmpNo";
            cboDriver.Enabled = true;
            cboDriver.Font = new Font("Tahoma", 8);
            cboDriver.SelectedItem = null;

            //Load data to Member1 combo box
            string qry2 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.epfno in (select a.epfno from Attendance a where a.status = 1 ) ";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            cboMember1.DataSource =ds2.Tables[0];
            cboMember1.DisplayMember = "Name";
            cboMember1.ValueMember = "EmpNo";
            cboMember1.Enabled = true;
            cboMember1.Font = new Font("Tahoma", 8);
            cboMember1.SelectedItem = null;

            //Load data to Member2 combo box
            string qry3 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.epfno in (select a.epfno from Attendance a where a.status = 1 )";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(qry3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            cboMember2.DataSource = ds3.Tables[0];
            cboMember2.DisplayMember = "Name";
            cboMember2.ValueMember = "EmpNo";
            cboMember2.Enabled = true;
            cboMember2.Font = new Font("Tahoma", 8);
            cboMember2.SelectedItem = null;

            //Load data to Member3 combo box
            string qry4 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.epfno in (select a.epfno from Attendance a where a.status = 1 ) ";
            SqlCommand cmd4 = new SqlCommand(qry4, con);
            SqlDataAdapter da4 = new SqlDataAdapter(qry4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            cboMember3.DataSource = ds4.Tables[0];
            cboMember3.DisplayMember = "Name";
            cboMember3.ValueMember = "EmpNo";
            cboMember3.Enabled = true;
            cboMember3.Font = new Font("Tahoma", 8);
            cboMember3.SelectedItem = null;

            //Load data to Member4 combo box
            string qry5 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.epfno in (select a.epfno from Attendance a where a.status = 1 ) ";
            SqlCommand cmd5 = new SqlCommand(qry5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(qry5, con);
            DataSet ds5 = new DataSet();
            da4.Fill(ds5);

            cboMember4.DataSource = ds5.Tables[0];
            cboMember4.DisplayMember = "Name";
            cboMember4.ValueMember = "EmpNo";
            cboMember4.Enabled = true;
            cboMember4.Font = new Font("Tahoma", 8);
            cboMember4.SelectedItem = null;

            //Load data to Member5 combo box
            string qry6 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.epfno in (select a.epfno from Attendance a where a.status = 1 )";
            SqlCommand cmd6 = new SqlCommand(qry6, con);
            SqlDataAdapter da6 = new SqlDataAdapter(qry6, con);
            DataSet ds6 = new DataSet();
            da4.Fill(ds6);

            cboMember5.DataSource = ds6.Tables[0];
            cboMember5.DisplayMember = "Name";
            cboMember5.ValueMember = "EmpNo";
            cboMember5.Enabled = true;
            cboMember5.Font = new Font("Tahoma", 8);
            cboMember5.SelectedItem = null;

            //Load data into cboVehicle
            string qry8 = "select VID,VNo from View_VehicleRegistrationNo";
            SqlCommand cmd8 = new SqlCommand(qry8, con);
            SqlDataAdapter da8 = new SqlDataAdapter(qry8, con);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);

            cboVehicle.DataSource = ds8.Tables[0];
            cboVehicle.DisplayMember = "VNo";
            cboVehicle.ValueMember = "VID";
            cboVehicle.Enabled = true;
            cboVehicle.Font = new Font("Tahoma", 8);
            cboVehicle.SelectedItem = null;


            con.Close();

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            string mem0, mem1, mem2, mem3, mem4, mem5 ,team,driver,vid, vehicle;
            mem0 = mem1 = mem2 = mem3 = mem4 = mem5 = team = driver = vid = vehicle= string.Empty;

            int tid = 0;

            if (string.IsNullOrEmpty(cboTeam.Text)||string.IsNullOrWhiteSpace(cboTeam.Text)) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Team Member must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTeam.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(cboDriver.Text) || string.IsNullOrWhiteSpace(cboDriver.Text))
            {
                MessageBox.Show("Driver name mustnot be empty!!", "VehicleNo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicle.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cboVehicle.Text) || string.IsNullOrWhiteSpace(cboVehicle.Text) )
            {
                MessageBox.Show("Vehicle Number mustnot be empty!!", "VehicleNo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicle.Focus();
                return;
            }

            else
            {  
                //get the combo box selected values  and update the 'employee' table 'isAloocated' set as true
                ArrayList aL = new ArrayList();

                //get the combobox selected value to update 'team' table 'Isallocated' set as true
                if (!(string.IsNullOrEmpty(cboTeam.Text) || string.IsNullOrWhiteSpace(cboTeam.Text)))
                {
                    team = cboTeam.Text.Trim();
                    tid = Convert.ToInt16(cboTeam.SelectedValue);
                }

               
                if (!(string.IsNullOrEmpty(cboMember1.Text) || string.IsNullOrWhiteSpace(cboMember1.Text)))
                {
                    mem1 = cboMember1.Text.Trim();
                    aL.Add(Convert.ToInt16(cboMember1.SelectedValue)); // add value member to ArrayList

                }

                if (!(string.IsNullOrEmpty(cboMember2.Text) || string.IsNullOrWhiteSpace(cboMember2.Text)))
                {
                    mem2 = cboMember2.Text.Trim();
                    aL.Add(Convert.ToInt16(cboMember2.SelectedValue)); // add value member to ArrayList

                }

                if (!(string.IsNullOrEmpty(cboMember3.Text) || string.IsNullOrWhiteSpace(cboMember3.Text)))
                {
                    mem3 = cboMember3.Text;
                    aL.Add(Convert.ToInt16(cboMember3.SelectedValue)); // add value member to ArrayList

                }

                if (!(string.IsNullOrEmpty(cboMember4.Text) || string.IsNullOrWhiteSpace(cboMember4.Text)))
                {
                    mem4 = cboMember4.Text;
                    aL.Add(Convert.ToInt16(cboMember4.SelectedValue)); // add value member to ArrayList

                }

                if (!(string.IsNullOrEmpty(cboMember5.Text) || string.IsNullOrWhiteSpace(cboMember5.Text)))
                {
                    mem5 = cboMember5.Text;
                    aL.Add(Convert.ToInt16(cboMember5.SelectedValue)); // add value member to ArrayList

                }

                if (!string.IsNullOrEmpty(cboDriver.Text))
                {
                    driver = cboDriver.Text;
                    aL.Add(Convert.ToInt16(cboDriver.SelectedValue)); // add value member to ArrayList

                }

                //get the combobox selected value to update 'Vehicle' table 'Isallocated' set as true
                if ((!string.IsNullOrEmpty(cboTeam.Text) || string.IsNullOrWhiteSpace(cboTeam.Text)))
                {
                    vehicle = cboVehicle.Text.Trim();
                    vid = Convert.ToString(cboVehicle.SelectedValue);
                }


                try
                {
                    //get selected member names from combo boxes
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    for (int i = 0; i < aL.Count; i++)
                    {
                        string qry4 = "insert into TeamEmployee (EMPNo,TeamID,AssignDate,Status) values (@EMPNo,@TeamID,@AssignDate,@Status)";

                        SqlCommand cmd4 = new SqlCommand(qry4, con);

                        cmd4.Parameters.AddWithValue("EMPNo", aL[i]);
                        cmd4.Parameters.AddWithValue("@TeamID", tid); // get the value member ofthe combobox
                        cmd4.Parameters.AddWithValue("@AssignDate", DateTime.Now);
                        cmd4.Parameters.AddWithValue("@Status", 1);

                        cmd4.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //for employee table
                    string qry = " update Employee set   IsAllocated = 1  where Name ='" + mem1 + "'  or Name ='" + mem2 + "' or    Name ='" + mem3 + "' or  Name ='" + mem4 + "' or   Name ='" + mem5 + "'  or   Name ='" + driver + "'  ";

                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();

                    //for Team table
                    string qry2 = " update Team set   IsAllocated = 1  where TeamID= '" + tid + "' ";
                    SqlCommand cmd2 = new SqlCommand(qry2, con);
                    cmd2.ExecuteNonQuery();

                    //for Vehicle table update
                    string qry3 = " update Vehicle set   IsAllocated = 1  where VID = @VID";
                    SqlCommand cmd3 = new SqlCommand(qry3, con);
                    int y = Convert.ToInt16(vid);
                    cmd3.Parameters.AddWithValue("@VID", y);
                    cmd3.ExecuteNonQuery();



                    // when assign a team ,team_Vehicle details insert into TeamVehicle table

                    string qry5 = "insert into TeamVehicle (TeamID,VID,AssignedDate,Status) values (@TeamID,@VID,@AssignDate,@Status)";

                    //SqlConnection con3 = new SqlConnection(cs);

                    SqlCommand cmd5 = new SqlCommand(qry5, con);
                    cmd5.Parameters.AddWithValue("@TeamID", tid);
                    cmd5.Parameters.AddWithValue("@VID", vid);
                    cmd5.Parameters.AddWithValue("@AssignDate", DateTime.Now);
                    cmd5.Parameters.AddWithValue("@Status", 1);
                    cmd5.ExecuteNonQuery();

                    con.Close();

                    RefreshDGV(); // refresh 4 datagridviews 
                    BindData();// refresh combo box
                    cboTeam.SelectedItem = cboMember1.SelectedItem = cboMember2.SelectedItem = cboMember3.SelectedItem = cboMember4.SelectedItem = cboMember5.SelectedItem = null;

                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                
            }

        }

        public  void RefreshDGV()
        {
            //available teams
            dgvTeamAvialble.RowHeadersVisible = false;
            string qry = "select Name from Team where IsAllocated = 0";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            dgvTeamAvialble.DataSource = tbl;
            DataGridViewColumn tcolum = dgvTeamAvialble.Columns[0];
            dgvTeamAvialble.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTeamAvialble.AllowUserToAddRows = false; //remove the empty row that gives wrong dgv row count.
            dgvTeamAvialble.ClearSelection();


            //available Employees
            dgvEmployeeAvailable.RowHeadersVisible = false;
            string qry2 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 0 and e.epfno in (select a.epfno from Attendance a where a.status = 1 )";
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataTable tbl2 = new DataTable();
            da2.Fill(tbl2);
            dgvEmployeeAvailable.DataSource = tbl2;
            DataGridViewColumn ecolum = dgvEmployeeAvailable.Columns[0];
            ecolum.Width = 40;
            dgvEmployeeAvailable.DefaultCellStyle.Font = new Font("Tahoma", 7);
            dgvEmployeeAvailable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployeeAvailable.AllowUserToAddRows = false; //remove the empty row that gives wrong dgv row count.

            //Teams assigned
            dgvTeamsAllocated.RowHeadersVisible = false;
            string qry3 = "Select Name from team where IsAllocated = 1";
            SqlDataAdapter da3 = new SqlDataAdapter(qry3, con);
            DataTable tbl3 = new DataTable();
            da3.Fill(tbl3);
            dgvTeamsAllocated.DataSource = tbl3;
            DataGridViewColumn tcolum3 = dgvTeamsAllocated.Columns[0];
            //tcolum3.Width = 40;
            dgvTeamsAllocated.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTeamsAllocated.AllowUserToAddRows = false; //remove the empty row that gives wrong dgv row count.

            //Allocated Employees
            dgvEmployeesAllocated.RowHeadersVisible = false;
            string qry4 = "select e.EmpNo,e.Name from Employee e  where e.Status = 1 and e.IsAllocated = 1 and e.epfno in (select a.epfno from Attendance a where a.status = 1 )";
            SqlDataAdapter da4 = new SqlDataAdapter(qry4, con);
            DataTable tbl4 = new DataTable();
            da4.Fill(tbl4);
            dgvEmployeesAllocated.DataSource = tbl4;
            DataGridViewColumn ecolum4 = dgvEmployeesAllocated.Columns[0];
            ecolum4.Width = 40;
            dgvEmployeesAllocated.DefaultCellStyle.Font = new Font("Tahoma", 7);
            dgvEmployeesAllocated.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmployeesAllocated.AllowUserToAddRows = false; //remove the empty row that gives wrong dgv row count.

            con.Close();

            //refresh combo boxes data
            BindData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGV();
            cboTeam.SelectedItem = cboMember1.SelectedItem = cboMember2.SelectedItem = cboMember3.SelectedItem = cboMember4.SelectedItem = cboMember5.SelectedItem = null;
        }

        private void btnDissolve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you need to dissove the teams ?", "Dissolve", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            string qry = " update Employee set   IsAllocated = 0 ";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.ExecuteNonQuery();

            string qry2 = " update Team set   IsAllocated = 0 ";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            cmd2.ExecuteNonQuery();

            //Set TeamEmployee table status=0 
            string qry4 = " update TeamEmployee set   Status = 0  ";
            SqlCommand cmd4 = new SqlCommand(qry4, con);
            cmd4.ExecuteNonQuery();

            //set TeamVehicle table isAssigned =0
            string qry5 = " update TeamVehicle set   Status = 0  ";
            SqlCommand cmd5 = new SqlCommand(qry5, con);
            cmd5.ExecuteNonQuery();

            con.Close();


            //set vehicle table isAllocated = 0
            con.Open();
            string qry6 = " update Vehicle set IsAllocated = 0  ";
            SqlCommand cmd6 = new SqlCommand(qry6, con);
            cmd6.ExecuteNonQuery();
            con.Close();


            BindData();
            RefreshDGV();
           

        }

        private void dgvEmployeesAllocated_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            DataGridViewRow dgvRow = dgvEmployeesAllocated.Rows[e.RowIndex]; //create row object
            allocaedEmpName = (dgvRow.Cells[1].Value.ToString()); // extract the first cell value - allocated name

            bool Isopen = false;
            foreach (Form f1 in Application.OpenForms)
            {
                if (f1.Text == "frmEmployeeDetails")
                {
                    Isopen = true;
                    f1.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmEmployeeDetails f1 = new frmEmployeeDetails();
                f1.Show();
            }



           

        }

        private void dgvEmployeeAvailable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvRow = dgvEmployeeAvailable.Rows[e.RowIndex]; //create row object
            allocaedEmpName = (dgvRow.Cells[1].Value.ToString()); // extract the first cell value - allocated name

            bool Isopen = false;
            foreach (Form f2 in Application.OpenForms)
            {
                if (f2.Text == "frmEmployeeDetails")
                {
                    Isopen = true;
                    f2.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmEmployeeDetails f2 = new frmEmployeeDetails();
                f2.Show();
            }


        }

        private void dgvEmployeeAvailable_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            

            bool Isopen = false;
            foreach (Form f3 in Application.OpenForms)
            {
                if (f3.Text == "frmCrAllocatedTeams")
                {
                    Isopen = true;
                    f3.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrAllocatedTeams f3 = new frmCrAllocatedTeams();
                f3.Show();
            }
        }
    }
    }


