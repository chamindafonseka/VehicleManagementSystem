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
    public partial class frmRepair : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = vmsuser; Password = 890";
        public int repairid = 0;
        public int itemid = 0;
        public static int vid = 0;
        public static DateTime date;
        public frmRepair()
        {
            InitializeComponent();
        }

        private void frmVehicleRepairing_Load(object sender, EventArgs e)
        {
            ComboboxBindData();
            dgvRepairing.AllowUserToAddRows = false;
            dgvRepairing.ClearSelection();

            dgvRepairing.AllowUserToAddRows = false;

            dgvRepairing.RowHeadersVisible = false;
       



        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!Regex.Match(cboVehicleNo.Text, "^[a-zA-Z0-9]").Success) 
            {
                MessageBox.Show("Vehicle Number must not be empty or \nEntered value is not valid.", "Vehicle Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
               cboVehicleNo.Focus();
                return;
            }

            else if (!Regex.Match(dtpRepairDate.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Repaired Date must not be empty or \nEntered value is not valid.", "Repaired Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
               dtpRepairDate.Focus();
                return;
            }

            else if (!Regex.Match(cboGarage.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Garage Name must not be empty or \nEntered value is not valid.", "Garage Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboGarage.Focus();
                return;
            }

            else if (!Regex.Match(txtAmount.Text, "^[0-9]").Success)
            {
                MessageBox.Show("Cost must not be empty or \nEntered value is not valid.", "Cost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return;
            }

            else if (!Regex.Match(txtInvoiceNo.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Receipt Number must not be empty or \nEntered value is not valid.", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInvoiceNo.Focus();
                return;
            }

            else if (!Regex.Match(txtRemarks.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Rematks must not be empty or \nEntered value is not valid.", "Rematks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemarks.Focus();
                return;
            }

          
            //else if (Convert.ToInt16(dgvRepairing.Rows.Count) <1)
            //{
            //    MessageBox.Show("No items used in the repair", "Rematks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //btnAdd.Focus();
            //    //return;
            //}

            else
            {
                try
                {
                    string qry = "insert into Repair (Date,InvoiceNo,Amount,VID,GID,DriverID,Remarks) values (@Date,@InvoiceNo,@Amount,@VID,@GID,@DriverID,@Remarks)";
                    SqlConnection con = new SqlConnection(cs);

                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);

                    cmd.Parameters.AddWithValue("@Date", dtpRepairDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text.Trim());
                    cmd.Parameters.AddWithValue("@VID", cboVehicleNo.SelectedValue);
                    cmd.Parameters.AddWithValue("@GID", cboGarage.SelectedValue);
                    cmd.Parameters.AddWithValue("@DriverID", cboDriver.SelectedValue);
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                    cmd.ExecuteNonQuery();

                    cleartextboxes();

                   
                    // get the max value of the table Repair
                    string qry3 = "select max(RepairID) from Repair";
                    SqlCommand cmd3 = new SqlCommand(qry3, con);

                    repairid = (int)cmd3.ExecuteScalar(); //ExecuteScalar() in C# SqlCommand Object is using for retrieve a single value from Database after the execution of the SQL Statement.
                    
                    
                    string qry2 = @"insert into ItemUsed  (RepairID,ItemID,NosItem,SerialNo,Cost ) values(@RepairID,@ItemID,@NosItem,@SerialNo,@Cost)";
                                
                    SqlCommand cmd2 = new SqlCommand(qry2, con);

                    //command.Parameters.AddWithValue adds the parameter to the list of parameters.you can't add a parameter twice. since you call the command several times, define the parameter outside and set value within the loop:

                    var param = cmd2.Parameters.Add("@RepairID", SqlDbType.Int);
                    var itemid = cmd2.Parameters.Add("@ItemID", SqlDbType.Int);
                    var nositem = cmd2.Parameters.Add("@NosItem", SqlDbType.Int);
                    var serialno = cmd2.Parameters.Add("@SerialNo", SqlDbType.Text);
                    var cost = cmd2.Parameters.AddWithValue("@Cost", SqlDbType.Money);

                    for (int i=0; i < dgvRepairing.Rows.Count;i++)
                    {
                        // set values while looping
                        param.Value = repairid;
                        itemid.Value = dgvRepairing.Rows[i].Cells[0].Value;
                        nositem.Value = dgvRepairing.Rows[i].Cells[2].Value;
                        serialno.Value = dgvRepairing.Rows[i].Cells[3].Value;
                        cost.Value = dgvRepairing.Rows[i].Cells[4].Value;

                        cmd2.ExecuteNonQuery();

                    }

                    dgvRepairing.Rows.Clear();

                    MessageBox.Show("Record has been added successfully.. ", "Added records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        public void ComboboxBindData()  // load data into combo box
        {
            SqlConnection con = new SqlConnection(cs);

            con.Open();
            string qry = "select VID,RegistrationNo  from Vehicle";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboVehicleNo.DataSource = ds.Tables[0];
            cboVehicleNo.DisplayMember = "RegistrationNo";
            cboVehicleNo.ValueMember = "VID";
            cboVehicleNo.Enabled = true;
            cboVehicleNo.SelectedItem = null;

            string qry2 = "select GID,Name  from Garage";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            cboGarage.DataSource = ds2.Tables[0];
            cboGarage.DisplayMember = "Name";
            cboGarage.ValueMember = "GID";
            cboGarage.Enabled = true;
            cboGarage.SelectedItem = null;

            string qry3 = "select ItemID,Name  from Item";
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataAdapter da3 = new SqlDataAdapter(qry3, con);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            cboItemName.DataSource = ds3.Tables[0];
            cboItemName.DisplayMember = "Name";
            cboItemName.ValueMember = "ItemID";
            cboItemName.Enabled = true;
            cboItemName.SelectedItem = null;

            string qry4 = "select d.DriverID, e.Name from Driver d, Employee e where d.EmpNo = e.EmpNo";
            SqlCommand cmd4 = new SqlCommand(qry4, con);
            SqlDataAdapter da4 = new SqlDataAdapter(qry4, con);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            cboDriver.DataSource = ds4.Tables[0];
            cboDriver.DisplayMember = "Name";
            cboDriver.ValueMember = "DriverID";
            cboDriver.Enabled = true;
            cboDriver.SelectedItem = null;

            string qry5 = "select SupID,Name  from Supplier";
            SqlCommand cmd5 = new SqlCommand(qry5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(qry5, con);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            cboSupplier.DataSource = ds5.Tables[0];
            cboSupplier.DisplayMember = "Name";
            cboSupplier.ValueMember = "SupID";
            cboSupplier.Enabled = true;
            cboSupplier.SelectedItem = null;

            con.Close();
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


            addRecords();
            

        }

        private void addRecords()
        {
            // add records into gridview temporary
            dgvRepairing.ColumnCount = 6;
            dgvRepairing.ColumnHeadersVisible = true;

            dgvRepairing.Columns[0].Name = "ItemID";
            dgvRepairing.Columns[1].Name ="Item";
            dgvRepairing.Columns[2].Name = "NosItem";
            dgvRepairing.Columns[3].Name = "SerialNo";
            dgvRepairing.Columns[4].Name = "Cost";
            dgvRepairing.Columns[5].Name = "Supplier";

            dgvRepairing.Columns[0].Width = 50;
            dgvRepairing.Columns[2].Width = 50;




            if (string.IsNullOrEmpty(cboItemName.Text))
            {
                MessageBox.Show("Item Name must not be empty or \nEntered value is not valid.", "Item Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboItemName.Focus();
                return;
            }
            else if (!Regex.Match(txtNosOfItems.Text, "^[0-9]$").Success)
            {
                MessageBox.Show("Nos of Items must not be empty or \nEntered value is not valid. ", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNosOfItems.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cboSupplier.Text))
            {
                MessageBox.Show("Supplier must not be empty or \nEntered value is not valid.", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboItemName.Focus();
                return;
            }


            //get the selected ItemID from the combo box......
            itemid = Convert.ToInt16(cboItemName.SelectedValue);

            string qry = @"select i.Price * "+ Convert.ToInt16(txtNosOfItems.Text)+ " as cost from Item i where i.ItemID=@ItemID";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@ItemID", itemid);
            decimal cost = (decimal)cmd.ExecuteScalar();

            //txtCost.Text = cost.ToString();


            string[] row1 = new string[] {cboItemName.SelectedValue.ToString(), cboItemName.Text, txtNosOfItems.Text, txtSerialNo.Text, cost.ToString(), cboSupplier.Text };

            object[] rows = new object[] { row1 };
            foreach(string[] rowArray in rows)
            {
                dgvRepairing.Rows.Add(rowArray);
            }            
            con.Close();

            cboItemName.Text = txtNosOfItems.Text  = txtSerialNo.Text = string.Empty;




        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvRepairing.Rows.Clear();
            cleartextboxes();

        }

        private void btnVehiRepairHistory_Click(object sender, EventArgs e)
        {
         

            if (!Regex.Match(cboVehicleNo.Text, "^[a-zA-Z0-9]").Success)
            {
                MessageBox.Show("Vehicle No.  must not be empty or \nEntered value is not valid.", "Vehicle No", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboVehicleNo.Focus();
                return;
            }

           vid = Convert.ToInt16(cboVehicleNo.SelectedValue);


            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrVehicleRepairHistory") 
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrVehicleRepairHistory f = new frmCrVehicleRepairHistory();
                f.Show();
            }
        }

        private void brnDateRepairHistory_Click(object sender, EventArgs e)
        {
            date = dtpRepairDate.Value;

            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmCrVehicleRepairDate")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                frmCrVehicleRepairDate f = new frmCrVehicleRepairDate();
                f.Show();
            }
        }
    }
}
