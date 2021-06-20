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
using System.IO;
using System.Net.NetworkInformation;

namespace VehicleManagementSystem
{
    public partial class frmAttendance : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public static string fpath { get; set; }
        
        public frmAttendance()
        {
            InitializeComponent();
        }



        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"H:\MIT\Regain\Project VMS\VehicleManagementSystem\Attendance";
            openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text Files|*.txt";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;

            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }

            //----------------------------------------------------------------------------------------
            //Read the text file and insert its data into the database Attendance table
            string cs = @"Data Source=CHAMINDA\MSSQLSERVER2;Initial Catalog=VMS;User ID=sa;Password=123";
            SqlConnection con = new SqlConnection(cs);

            con.Open();

            string line;

            if (MessageBox.Show("Are you sure you want to upload the selected text file?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                using (StreamReader file = new StreamReader(txtFilePath.Text))
                {
                    SqlCommand cmd2 = new SqlCommand("update Attendance set status = 0", con);  // previously entered data keep with flag
                    cmd2.ExecuteNonQuery();

                    while ((line = file.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        SqlCommand cmd = new SqlCommand("insert into Attendance(EPFNo, Intime, status) values(@EPFNo, @Intime, @status)", con);
                        cmd.Parameters.AddWithValue("@EPFNo", fields[0].ToString());
                        cmd.Parameters.AddWithValue("@Intime",  Convert.ToDateTime(fields[1].ToString()))  ;
                        cmd.Parameters.AddWithValue("@status", true);
                        cmd.ExecuteNonQuery();
                    }

                    SqlCommand cmd3 = new SqlCommand("select count(EPFNo) from Attendance where status = 1", con);
                    // count the number of entered rows

                    MessageBox.Show( Convert.ToString(cmd3.ExecuteScalar()) + " rows have been added to the Attendance table");
                    dgvAttendanceRefresh();

                }
                con.Close();

            }
            else
            {
                MessageBox.Show("You pressed Cancel!");
                
            }
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            
            dgvAttendance.ClearSelection();
            dgvAttendance.AllowUserToAddRows = false;
            

            //last file upload date
            SqlConnection con = new SqlConnection(cs);
            string qry = "select max(Intime) from Attendance";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lblLastUploadedDate.Text = dr[0].ToString();

            DateTime fdate = new DateTime();
            fdate = Convert.ToDateTime(dr[0].ToString());
            dr.Close();

            //Warning message about the attendance file date
            var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
            var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
            

            MessageBox.Show(fdate.ToString(), "Last uploaded attendance file date", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //absent employees (+ Drivers )

            string qry2 = "select e.EPFNo, e.Name from Employee e where e.Status = 1 and e.epfno not in (select epfno from Attendance where status = 1)";
            SqlDataAdapter da = new SqlDataAdapter(qry2, con);          
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            dgvAttendance.DataSource = tbl;
            con.Close();
            dgvAttendance.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvAttendanceRefresh();

        }

        private void btnGetNewAttenFile_Click(object sender, EventArgs e)
        {
            //check HR System database server connectivity
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("192.168.128.220", 1000);
                if (reply.Status  == IPStatus.Success)
                {
                    MessageBox.Show("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address, "Connectivity -HR System Db");

                    //get attendance text file from HRM & dbPMS database

                    try
                    {
                        string cs2 = @"Data Source = 192.168.128.220; Initial Catalog = HRM; User Id = sa; Password = 123";
                        SqlConnection con2 = new SqlConnection(cs2);


                        DateTime sysdate = new DateTime(2019,6,4,10,0,123 );
                        //sysdate = DateTime.Now;
                        

                        DateTime dateonly = sysdate.Date;
                        //MessageBox.Show(dateonly.ToString(), "System DateTime "); // eg: 10/26/2018 12:00 AM

                        //check the current date employees present.
                        string qry4 = "select count( u.Badgenumber)[Empcount] from HRM.dbo.CHECKINOUT c, HRM.dbo.USERINFO u, dbPMS.dbo.Employee e  where c.USERID = u.USERID and e.EPFNo = u.Badgenumber and  c.CHECKTYPE = 'I' and  e.DeptCode = 23  and  e.Inactive = 0 and     c.CHECKTIME >  '" + dateonly + "'";

                        string qry3 = "select u.Badgenumber, c.CHECKTIME from HRM.dbo.CHECKINOUT c, HRM.dbo.USERINFO u, dbPMS.dbo.Employee e  where c.USERID = u.USERID and e.EPFNo = u.Badgenumber and  c.CHECKTYPE = 'I' and  e.DeptCode = 23  and  e.Inactive = 0 and     c.CHECKTIME >  '" + dateonly + "'";

                        con2.Open();

                        //check the current date employees present.
                        SqlCommand cmd4 = new SqlCommand(qry4,con2);
                        SqlDataReader dr4 = cmd4.ExecuteReader();
                        dr4.Read();

                        if (Convert.ToInt16(   dr4[0]) == 0)
                        {
                            MessageBox.Show("Today's attendance data still not uploaded");
                             
                            foreach (Form f in Application.OpenForms)
                            {
                                if (f.Text == "Attendance")
                                {
                                    f.Close();
                                }
                            }

                            return; //tet githb



                        }
                        dr4.Close();



                        string filePath = @"H:\MIT\Regain\Project VMS\VehicleManagementSystem\Attendance\attendance.txt";
                        SqlCommand cmd3 = new SqlCommand(qry3, con2);
                        SqlDataReader dr3 = cmd3.ExecuteReader();

                        using (StreamWriter file = new StreamWriter(filePath, false))
                        {
                            while (dr3.Read())
                            {
                                //file.WriteLine(dr3[0] + "\t" + dr3[1]);
                                file.WriteLine(dr3[0] + "," + dr3[1]);
                            }

                        }

                        dr3.Close();
                        con2.Close();

                        //last file upload date Refresh
                        SqlConnection con = new SqlConnection(cs);
                        string qry = "select max(Intime) from Attendance";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(qry, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        lblLastUploadedDate.Text = dr[0].ToString();

                        DateTime fdate = new DateTime();
                        fdate = Convert.ToDateTime(dr[0].ToString());
                        dr.Close();
                        con.Close();

                        MessageBox.Show("File has been copied to " + filePath, "File Path", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("HR System database server not avaialble \n" + ex.Message, "Unable to connect the database");
                    }

                }
                else
                {
                    // Senario : when the sql server stop but able to ping 192.,168.128.220 
                    MessageBox.Show("HR System Database has not responded");
                }
            }
            catch
            {
                MessageBox.Show("ERROR: You have Some TIMEOUT issue with HR System database server. \n (192.168.128.220)");
            }


           
        }

        private void dgvAttendanceRefresh()
        {
            string qry = "select e.EPFNo, e.Name from Employee e where e.Status = 1 and e.epfno not in ( select epfno from Attendance where status = 1)";          

            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvAttendance.DataSource = tbl;
            con.Close();

        }
        

        

    }
}

