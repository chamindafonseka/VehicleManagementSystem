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
    
    public partial class frmEditAttendance : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = reportuser; Password = 890";
        public frmEditAttendance()
        {
            InitializeComponent();
        }

        private void frmEditAttendance_Load(object sender, EventArgs e)
        {            
            dtpAttendance.Format = DateTimePickerFormat.Custom;
            dtpAttendance.CustomFormat = "yyyy/MM/dd hh:mm:ss";

            //dtpAttendance.Location = new Point(100, 100);
            dtpAttendance.ShowUpDown = true;
            dtpAttendance.Width = 140;
            Controls.Add(dtpAttendance);

            bindComboData();

        }

        private void bindComboData()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            // load data to Team combo box
            string qry = "select name, EPFNo from Employee where Status = 1";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboEmployee.DataSource = ds.Tables[0];
            cboEmployee.DisplayMember = "Name";
            cboEmployee.ValueMember = "EPFNo";
            cboEmployee.Enabled = true;
            cboEmployee.SelectedItem = null;

            con.Close();
        }

        private void clearTextboxes()
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearTextboxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(cboEmployee.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Employee name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboEmployee.Focus();
                return;
            }

            else
            {
                try
                {
                    // update if any relavant record as status=0
                   int epfno = (int)cboEmployee.SelectedValue;

                    SqlConnection con = new SqlConnection(cs);
                    con.Open();

                    string qry2 = "update Attendance set status =0 where EPFNo = @EPDNo";
                    SqlCommand cmd2 = new SqlCommand(qry2,con);
                    cmd2.Parameters.AddWithValue("@EPDNo", epfno);
                    cmd2.ExecuteNonQuery();



                    // insert new record to table Attendance
                    string qry = "insert into Attendance  ( EPFNo, Intime, status) values ( @EPFNo, @Intime, @status)";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@EPFNo", cboEmployee.SelectedValue.ToString().Trim());
                    cmd.Parameters.AddWithValue("@Intime", dtpAttendance.Value);
                    cmd.Parameters.AddWithValue("@status", 1);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cboEmployee.Text = null;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
           
        }
    }
}
