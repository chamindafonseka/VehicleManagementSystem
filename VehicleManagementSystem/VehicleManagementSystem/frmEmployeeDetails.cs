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
    public partial class frmEmployeeDetails : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public frmEmployeeDetails()
        {
            InitializeComponent();
        }

        private void drmEmployeeDetails_Load(object sender, EventArgs e)
        {
            

            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string en = Convert.ToString(frmTeamEmployee.AllocaedEmpName.Trim());
            string qry = "SELECT Name, ContactNo, ResidentialAddress, DoB, NIC ,EPFNo, Sex ,CivilStatus   FROM  Employee where Name = '"+en+"'  ";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lblName.Text = dr[0].ToString();
            lblContactNo.Text = dr[1].ToString();
            lblAddress.Text= dr[2].ToString();
            //convert DateTime format into short date format
            lblDOB.Text = Convert.ToDateTime(dr[3].ToString()).ToString("MM/dd/yyyy");
            lblNIC.Text = dr[4].ToString();
            lblEPF.Text = dr[5].ToString();
            lblSex.Text = dr[6].ToString();
            lblCivilStatus.Text = dr[7].ToString();



            dr.Close();

            con.Close();
        }
    }
}
