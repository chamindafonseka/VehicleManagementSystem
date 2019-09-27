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
using System.Security.Cryptography;

namespace VehicleManagementSystem
{
    public partial class frmUserRights : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        private int uid = 0;
        private string curuser = "";



        public frmUserRights()
        {
            InitializeComponent();
            txtPassword.Text = string.Empty;
            txtPassword.PasswordChar = '*';
        }

        private void frmUserRights_Load(object sender, EventArgs e)
        {
            dgvUserRightsRefresh();
            lstUserNameRefresh();
        }

        private void dgvUserRightsRefresh()
        {
            string qry = "select MenuItemID,description  from MenuItem where Flag=1";
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            dgvUserRights.DataSource = tbl;
            con.Close();

            dgvUserRights.Columns[2].Width = 280;


        }

        private void lstUserNameRefresh()
        {
            string qry = "select Userid ,Name from AppUser where deleted =0";
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            con.Open();
            DataTable tbl = new DataTable();

            da.Fill(tbl);
            lstUserName.DataSource = tbl;

            this.lstUserName.MultiColumn = true;

            lstUserName.DisplayMember = tbl.Columns[1].ToString();
            lstUserName.ValueMember = tbl.Columns[0].ToString();

            con.Close();

            lstUserName.SelectedIndex = -1;  // set default listbox values as not selected.

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            frmNewUser newuser = new frmNewUser();
            newuser.Show();
        }


        private void lstUserName_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

            //Display the selected user name on frmUserRights
            lblUserNameDisplay.Text = "Selected user name : " + lstUserName.GetItemText(lstUserName.SelectedItem);

            
            //set all checkbox untick state
            for (int q = 0; q < Convert.ToInt32(dgvUserRights.Rows.Count); q++)
            {
                dgvUserRights.Rows[q].Cells[0].Value = false;
            }

            //---------------------------------------------------

            string qry = "select UserName, Name from AppUser  where userid = @userid ";

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader myReader;

            cmd.Parameters.AddWithValue("@userid", lstUserName.SelectedValue);  // this value set in lstUserNameRefresh()

            myReader = cmd.ExecuteReader();

            myReader.Read();

            //when click the list item, load the relavent data into textboxes
            txtFullName.Text = myReader.GetString(1);
            txtUserName.Text = myReader.GetString(0);
            con.Close();


            uid = Convert.ToInt32(lstUserName.SelectedValue);  // UserID 

            con.Open();
            string qry2 = "select  menuitemid from UserMenuRights  where userid = " + uid + "";
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            //user menu itemid compair with
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = i; j < dgvUserRights.Rows.Count; j++)
                {

                    if (dgvUserRights.Rows[j].Cells[1].Value.ToString() == ds.Tables[0].Rows[i]["menuitemid"].ToString())
                    {
                        dgvUserRights["UserRight", j].Value = true; //where "UserRight" is the combobox column
                    }

                }
            }





        }

        //here need to introduce for loop
        private void dgvUserRights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //******* select a user is mandarory
            if (lstUserName.SelectedIndex != -1)
            {

                
                //*******  update user rights
                //*******  first get the checked menuitem ids from dgvUserRights


                int rows = dgvUserRights.Rows.Count;

               // MessageBox.Show(dgvUserRights.Rows.Count.ToString());



                // get the selected username from the lstUserRights

                curuser = lstUserName.GetItemText(lstUserName.SelectedItem);  // selected user name


                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string qry3 = "select userid from AppUser where name = '" + curuser + "'";  // pass user name to querry


                SqlCommand cmd3 = new SqlCommand(qry3, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();
                da.Fill(ds);


                int uid = Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[0]);   // get the userid

                //MessageBox.Show(uid.ToString(),"ddd");

                // remove all records from the table UserMenuRights of relavant user.  

                string qry4 = "delete from UserMenuRights where userid in ( select userid from AppUser where userid =" + uid + " )";
                SqlCommand cmd4 = new SqlCommand(qry4, con);
                cmd4.ExecuteNonQuery();

                con.Close();



                //get the checked user rights ( MenuItemIDs) from "lstUserName"
                //add MenuItemIDs in to List (miid)

                List<int> miid = new List<int>();  // set a list to store checked check-boxes 
                int g = 0;

                for (int j = 0; j < dgvUserRights.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dgvUserRights.Rows[j].Cells[0].Value) == true) // extract only checked ones
                    {
                        miid.Add(Convert.ToInt32(dgvUserRights.Rows[j].Cells[1].Value));  // store them into list "miid"

                    }
                }
               



                con.Open();

                for (int i = 0; i < miid.Count(); i++) // read the list and insert the values into table 
                {
                    SqlCommand myCommand = new SqlCommand(
                        "INSERT INTO UserMenuRights (userid,menuitemid) " +
                        "Values ('" + uid + "','" + miid[i] + "')", con);
                    myCommand.ExecuteNonQuery();
                }

                con.Close();

                MessageBox.Show("Nos of items selected : " + miid.Count(), "Checked User Rights");

            }

            else {
                MessageBox.Show("Please select the user", ".", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
        }
            
    


        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                
                MessageBox.Show("Please select the user", "User Name Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }

            else if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Please enter the new password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            else
            {
                //https://stackoverflow.com/questions/4181198/how-to-hash-a-password
                //https://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
                // STEP 1 Create the salt value with a cryptographic PRNG:
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                //STEP 2 Create the Rfc2898DeriveBytes and get the hash value:
                string password = txtPassword.Text;
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                //STEP 3 Combine the salt and password bytes for later use:
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                // STEP 4 Turn the combined salt+hash into a string for storage
                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                



                //update user password
                try
                {
                    curuser = lstUserName.GetItemText(lstUserName.SelectedItem);

                    DialogResult d = MessageBox.Show(curuser.ToString() + "'s password going to be changed","Change Password", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                    if(d == DialogResult.Yes)
                    {
                        string sql = "update AppUser set PWHash = @PWHash  where userid ='" + uid + "'";
                        SqlConnection con = new SqlConnection(cs);

                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@PWHash", savedPasswordHash);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        txtPassword.Text = string.Empty;
                    }
                    else
                    {
                        txtPassword.Focus();
                        txtPassword.Clear();
                        return;
                    }

                    

                    

                    MessageBox.Show(curuser.ToString()+ "'s password has been changed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,".", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
               
                

            }
        }
    }
}
