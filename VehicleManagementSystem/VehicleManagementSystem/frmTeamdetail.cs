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
    public partial class frmTeamdetail : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        public frmTeamdetail()
        {
            InitializeComponent();
        }

        private void frmTeamdetail_Load(object sender, EventArgs e)
        {
            dgvTeamDetailsRefresh();
            dgvTeamDetails.RowHeadersVisible = false;
            dgvTeamDetails.ClearSelection();
            
            lblTeamName.Text = frmTeamEmployee.AllocaedTName;

           

            //highlight the Driver row
            //Step1 : get the relavant team and related driver name and set them in to dataset.
            string qry = "select  e.Name from Employee e, TeamEmployee te , team t, driver d where e.EmpNo = te.EMPNo and te.TeamID = t.TeamID and d.EmpNo = te.EMPNo and te.Status = 1 and e.IsAllocated = 1 and t.IsAllocated = 1 and t.Name= '" + frmTeamEmployee.AllocaedTName+ "'  "; //this parameter comes from frmTeamEmployee's dgvAllocatedReam click.
            
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();


            //get the Vehicle reg. number from frmTeamEmployee for display on form
            lblVehicleNo.Text = frmTeamEmployee.allocatedVName;



            //remove the empty row that gives wrong dgv row count. That made mess me.
            dgvTeamDetails.AllowUserToAddRows = false; 

            //nested for loop used for compair employees names
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)  // employee names from data set
            {
                for (int j = 0; j < dgvTeamDetails.Rows.Count; j++)  // team members names from dgvTeamDetails.
                {
                    try
                    {
                        string a = ds.Tables[0].Rows[i][0].ToString().Trim();
                        string b = dgvTeamDetails.Rows[j].Cells[0].Value.ToString().Trim();

                        if (string.Equals(a, b))
                        {
                            dgvTeamDetails.Rows[j].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


        }


        private void dgvTeamDetailsRefresh()
        {
            //load select Allocated team members

            string qry = "select distinct e.Name from Employee e, TeamEmployee te, team t where te.Status =1 and e.EmpNo = te.EMPNo  and te.TeamID = t.TeamID and t.Name like '" + frmTeamEmployee.AllocaedTName+"'";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvTeamDetails.DataSource = tbl;
            con.Close();
            dgvTeamDetails.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTeamDetails.AllowUserToAddRows = false;
            dgvTeamDetails.Rows[0].Cells[0].Selected = false;

        }

        private void btnDissolve_Click(object sender, EventArgs e)
        {
            try
            {
                //get the selected TeamID from frmTeamEmployee 's clicked Team name
                string qry = "select TeamID from team  where Name= '" + frmTeamEmployee.AllocaedTName + "'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int tid = Convert.ToInt16(dr[0]); //TeamID set to a integer for further use
                dr.Close();

                //Dissolve Team
                string qry2 = " update Team set   IsAllocated = 0 where TeamID='" + tid + "'    ";
                SqlCommand cmd2 = new SqlCommand(qry2, con);
                cmd2.ExecuteNonQuery();
                

                //Deallocated the selected team members in Employee table
                string qry3 = "update employee set IsAllocated = 0 where EmpNo in ( select e.EmpNo from TeamEmployee te, Employee e where te.status=1 and  te.EMPNo = e.EmpNo and te.TeamID='" + tid + "'  ) ";
                SqlCommand cmd3 = new SqlCommand(qry3, con);
                cmd3.ExecuteNonQuery();
                

                //Set TeamEmployee table status=0 when dissolving the team table with particular teamID
                string qry4 = " update TeamEmployee set   Status = 0 where TeamID='" + tid + "'    ";
                SqlCommand cmd4 = new SqlCommand(qry4, con);
                cmd4.ExecuteNonQuery();


                //set vehicle table isAllocated = 0
                string qry6 = " update Vehicle set IsAllocated = 0  where VID in (select VID from TeamVehicle where TeamID='" + tid + "') ";
                SqlCommand cmd6 = new SqlCommand(qry6, con);
                cmd6.ExecuteNonQuery();
              


                con.Close();

                                
                MessageBox.Show("Dissolve the team that you selected","Team Dissolve",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmTeamEmployee frt = new frmTeamEmployee();
                frt.RefreshDGV();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void dgvTeamDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }


}


