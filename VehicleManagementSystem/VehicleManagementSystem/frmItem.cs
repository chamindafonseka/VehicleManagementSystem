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
    public partial class frmItem : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = vmsuser; Password = 890";
        public static int itemid = 0;
        public frmItem()
        {
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            BindData();
            dgvItemRegistrationRefresh();
            dgvItemRegistration.AllowUserToAddRows = false;
            dgvItemRegistration.ClearSelection();
            dgvItemRegistration.RowHeadersVisible = false;

            dgvItemRegistration.Columns[0].Width = 60;
            dgvItemRegistration.Columns[1].Width = 220;
            dgvItemRegistration.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtItemName.Text, "^[a-zA-Z0-9]").Success)  
            {
                MessageBox.Show("Item Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemName.Focus();
                return;
            }

            else if (!Regex.Match(txtMade.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Made must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMade.Focus();
                return;
            }

            else if (!Regex.Match(txtPrice.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Price must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return;
            }

            else if (!Regex.Match(txtBrand.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Brand Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBrand.Focus();
                return;
            }



            else
            {
                try
                {

                    string qry = "insert into Item (Name,Brand,Made,Price,Deleted) values (@Name,@Brand,@Made,@Price,@Deleted)";
                    SqlConnection con = new SqlConnection(cs);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@Name", txtItemName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Brand",txtBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("@Made",txtMade.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deleted",0);
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartextboxes();
                    dgvItemRegistrationRefresh();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }            
        }
        private void dgvItemRegistrationRefresh()
        {
            string qry = " Select ItemID, Name, Brand, Made, Price from Item where deleted=0 order by name";

            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            dgvItemRegistration.DataSource = tbl;
            con.Close();

            dgvItemRegistration.AllowUserToAddRows = false;
            dgvItemRegistration.ClearSelection();
            cleartextboxes();
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

        public void BindData()  // load data into combo box
        {
            //SqlConnection con = new SqlConnection(cs);

            //con.Open();
            //string qry = "select SupID, Name from Supplier";
            //SqlCommand cmd = new SqlCommand(qry, con);
            //SqlDataAdapter da = new SqlDataAdapter(qry, con);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //cboSupplier.DataSource = ds.Tables[0];
            //cboSupplier.DisplayMember = "Name";
            //cboSupplier.ValueMember = "SupID";
            //cboSupplier.Enabled = true;


            //con.Close();
        }

        private void dgvItemRegistration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dgvItemRegistration.Rows[e.RowIndex];

                itemid = Convert.ToInt32(dgvRow.Cells[0].Value);

                txtItemID.Text = dgvRow.Cells[0].Value.ToString().Trim();
                txtItemName.Text = dgvRow.Cells[1].Value.ToString().Trim();
                txtBrand.Text = dgvRow.Cells[2].Value.ToString().Trim();
                txtMade.Text = dgvRow.Cells[3].Value.ToString().Trim();
                txtPrice.Text = dgvRow.Cells[4].Value.ToString().Trim();


                btnSave.Enabled = false;
            }
            

            catch (Exception ex)
            {
                MessageBox.Show("Please select a Item.  " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cleartextboxes();
            dgvItemRegistrationRefresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Regex.Match(txtItemName.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Item Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemName.Focus();
                return;
            }

            else if (!Regex.Match(txtMade.Text, "^[a-zA-Z]").Success)
            {
                MessageBox.Show("Made must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMade.Focus();
                return;
            }

            else if (!Regex.Match(txtPrice.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Price must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return;
            }

            else if (!Regex.Match(txtBrand.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Brand Name must not be empty or \nEntered value is not valid.", "Team Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBrand.Focus();
                return;
            }



            else
            {
                try
                {
                    string qry = " update Item set   Name = @Name , Brand = @Brand , Made= @Made, Price=@Price where ItemID = @ItemID ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@ItemID ", itemid);
                    cmd.Parameters.AddWithValue("@Name", txtItemName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim());
                    cmd.Parameters.AddWithValue("@Made", txtMade.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());


                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been updated successfully.. ", "Update records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvItemRegistrationRefresh();
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this result ?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                string qry = " update Item set Deleted=@Deleted where   ItemID  = @ItemID ";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();

                cmd.Parameters.AddWithValue("@ItemID", itemid);
                cmd.Parameters.AddWithValue("@Deleted",1);
                cmd.ExecuteNonQuery();

                con.Close();
                dgvItemRegistrationRefresh();
                MessageBox.Show("Selected Record has been deleted. ", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartextboxes();

            }
        }
    }
}
