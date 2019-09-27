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
    public partial class frmCurrentAttendance : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public frmCurrentAttendance()
        {
            InitializeComponent();
        }

        private void dgvCureentAttendanceRefresh()
        {            
            string qry = "select e.EmpNo, e.EPFNo, e.Name from Attendance a , Employee e where a.EPFNo = e.EPFNo and a.status = 1 order by e.Name";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvCureentAttendance.DataSource = tbl;
            con.Close();
            dgvCureentAttendance.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCureentAttendance.AllowUserToAddRows = false;
            dgvCureentAttendance.ClearSelection();

        }

        private void frmCurrentAttendance_Load(object sender, EventArgs e)
        {
            dgvCureentAttendanceRefresh();

            SqlConnection con = new SqlConnection(cs);
            string qry = "select CONVERT(VARCHAR(10),    max(a.intime), 103)  from Attendance a where a.status = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lblCurDate.Text = dr[0].ToString();

            DateTime fdate = new DateTime();
            fdate = Convert.ToDateTime(dr[0].ToString());
            dr.Close();




        }
    }
}
