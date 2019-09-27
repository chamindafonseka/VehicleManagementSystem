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
    public partial class frmRoute : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        int rid = 0;

        public frmRoute()
        {
            InitializeComponent();
        }

        private void frmRoute_Load(object sender, EventArgs e)
        {
            dgvRoute.RowHeadersVisible = false;
            dgvRouteRefresh();

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            btnSave.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtRouteName.Text, "^[a-zA-Z0-9-d]").Success) // acept only  letters , numbers & "-"
            {
                MessageBox.Show("Route Name must not be empty or \nEntered value is not valid.", "Route Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRouteName.Focus();

            }

            else if (!Regex.Match(txtRouteLength.Text, "^[0-9]+$").Success) // only accept numbers
            {
                MessageBox.Show("Route Length must not be empty or \nEntered value is not valid.", "Route Length", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRouteLength.Focus();

            }

            else if (String.IsNullOrEmpty(txtCoveredArea.Text))
            {
                MessageBox.Show("Covered area must not be empty or \nEntered value is not valid.", "Covered  area", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCoveredArea.Focus();
            }



            else
            {

                string qry = "insert into Route (RouteName, RouteLength, CoveredArea) values (@RouteName, @RouteLength, @CoveredArea)";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();


                cmd.Parameters.AddWithValue("@RouteName", this.txtRouteName.Text.Trim());
                cmd.Parameters.AddWithValue("@RouteLength", this.txtRouteLength.Text.Trim());
                cmd.Parameters.AddWithValue("@CoveredArea", this.txtCoveredArea.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Do you want to save data ?", "Save Data", MessageBoxButtons.YesNo);

                dgvRouteRefresh();
                MessageBox.Show("Saved Successfully .");

                cleartextboxes();
                
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtRouteID.Text))
                {
                    SqlConnection con = new SqlConnection(cs);

                    string qry = "update Route set RouteName = @RouteName, RouteLength = @RouteLength, CoveredArea = @CoveredArea where Routeid = @Routeid";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@Routeid", rid);
                    cmd.Parameters.AddWithValue("@RouteName", txtRouteName.Text.Trim());
                    cmd.Parameters.AddWithValue("@RouteLength", txtRouteLength.Text.Trim());
                    cmd.Parameters.AddWithValue("@CoveredArea", txtCoveredArea.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();

                    dgvRouteRefresh();
                    MessageBox.Show("Successfully updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();

                }
                
                else
                {
                    MessageBox.Show("Please click on the RouteID from the grid", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRouteID.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to remove this row ?", "delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string qry = " delete from Route where   RouteID  = @RouteID  ";
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@RouteID ", rid);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    dgvRouteRefresh();
                    MessageBox.Show("Record has been removed.", "Covered  area", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();
                }
            }
            else
            {
                
                MessageBox.Show("Please click on the Route ID from the grid", "RouteID ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




            btnSave.Enabled = true;
             
        }



        private void dgvRouteRefresh()
        {
            SqlConnection con = new SqlConnection(cs);
            string qry = "select * from Route";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvRoute.DataSource = tbl;
            con.Close();

            dgvRoute.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRoute.AllowUserToAddRows = false;
            dgvRoute.ClearSelection();
            btnSave.Enabled = true;

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

        private void dgvRoute_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            // load data into controls when click the dgv cell
            try
            {
                DataGridViewRow dgvRow = dgvRoute.Rows[e.RowIndex];
                rid = Convert.ToInt32(dgvRow.Cells[0].Value.ToString());
                txtRouteID.Text = dgvRow.Cells[0].Value.ToString();
                txtRouteName.Text = dgvRow.Cells[1].Value.ToString();
                txtRouteLength.Text = dgvRow.Cells[2].Value.ToString();
                txtCoveredArea.Text = dgvRow.Cells[3].Value.ToString();

                btnSave.Enabled = false;


            }
            catch (Exception ex)
            {

                MessageBox.Show("Please select RouteID.  " + ex.Message);
            }
           

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string qry = "select * from Route where Routeid = @Routeid";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Routeid", txtRouteIDSearch.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();
            da.Fill(tbl);

            dgvRoute.DataSource = tbl;
            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            dgvRouteRefresh();
            txtRouteIDSearch.Text = string.Empty;
            btnSave.Enabled = true;
        }
    }
}
