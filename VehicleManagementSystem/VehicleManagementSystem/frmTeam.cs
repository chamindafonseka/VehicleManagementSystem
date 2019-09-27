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
    public partial class frmTeam : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = vmsuser; Password = 890";
        int teamid = 0;
        public frmTeam()
        {
            InitializeComponent();
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            btnAdd.Enabled = true;
            btnSave.Enabled = true;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtTeamName.Text, "^[a-zA-Z0-9]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Team Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTeamName.Focus();
            }

            else if (!Regex.Match(cboRouteName.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Route Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTeamName.Focus();
                return;
            }

            else if (!Regex.Match(txtTeamPhone.Text,"^[0-9]{10}$").Success)
            {
                MessageBox.Show("Phone Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTeamName.Focus();
            }

          

            else
            {
                try
                {
                    string qry = "insert into Team (Name,RouteID,TeamPhone,IsAllocated,Deleted) values (@Name,@RouteID,@TeamPhone,@IsAllocated,@Deleted)";
                    SqlConnection con = new SqlConnection(cs);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@Name", this.txtTeamName.Text.Trim());
                    cmd.Parameters.AddWithValue("@RouteID", cboRouteName.SelectedValue.ToString()); // get the value member ofthe combobox
                    cmd.Parameters.AddWithValue("@TeamPhone", this.txtTeamPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("IsAllocated", 0);
                    cmd.Parameters.AddWithValue("@Deleted",0);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();
                    dgvTeamRefresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public void BindData()  // load data into combo box
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            string qry = "select RouteID, RouteName from Route";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cboRouteName.DataSource = ds.Tables[0];
            cboRouteName.DisplayMember = "RouteName";
            cboRouteName.ValueMember = "RouteID";
            cboRouteName.Enabled = true;
            cboRouteName.SelectedItem = null;

            con.Close();
        }

        private void dgvTeam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvTeam.Rows[e.RowIndex];

                teamid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtTeamID.Text = dgvRow.Cells[0].Value.ToString();
                txtTeamName.Text = dgvRow.Cells[1].Value.ToString();
                cboRouteName.Text = dgvRow.Cells[2].Value.ToString();
                txtTeamPhone.Text = dgvRow.Cells[3].Value.ToString();

                btnSave.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please enter a TeamID.  " + ex.Message);
            }
        }

        private void dgvTeamRefresh()
        {
            try
            {
                string qry = "select t.TeamID,t.Name, r.RouteName,t.TeamPhone,t.RouteID from Team t , Route r where t.RouteID = r.RouteID and t.Deleted=0";

                SqlConnection con = new SqlConnection(cs);

                SqlDataAdapter da = new SqlDataAdapter(qry, Properties.Settings.Default.VMSConnectionString);
                con.Open();
                DataTable tbl = new DataTable();

                da.Fill(tbl);
                dgvTeam.DataSource = tbl;
                con.Close();
                

                dgvTeam.AllowUserToAddRows = false;
                dgvTeam.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmTeam_Load(object sender, EventArgs e)
        {
            BindData();
            dgvTeamRefresh();
            dgvTeam.RowHeadersVisible = false;
            dgvTeam.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            if (!Regex.Match(txtTeamName.Text, "^[a-zA-Z0-9]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Team Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTeamName.Focus();
            }

            else if (!Regex.Match(cboRouteName.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Route Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTeamName.Focus();
                return;
            }

            else if (!Regex.Match(txtTeamPhone.Text, "^[0-9]{10}$").Success)
            {
                MessageBox.Show("Phone Number must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTeamName.Focus();
            }

            else
            {
                try
                {

                    string qry = " update Team set   Name = @Name , RouteID = @RouteID , TeamPhone = @TeamPhone  where TeamID = @TeamID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@TeamID", teamid);
                    cmd.Parameters.AddWithValue("@Name", this.txtTeamName.Text.Trim());
                    cmd.Parameters.AddWithValue("@RouteID", cboRouteName.SelectedValue.ToString()); // get the value member ofthe combobox
                    cmd.Parameters.AddWithValue("@TeamPhone", this.txtTeamPhone.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvTeamRefresh();
                    cleartextboxes();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the record ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string qry = " update   Team set Deleted=@Deleted where TeamID = @TeamID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@TeamID ", teamid);
                    cmd.Parameters.AddWithValue("@Deleted", 1);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been removed successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvTeamRefresh();
                    cleartextboxes();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                



            }

        }
    }
}
