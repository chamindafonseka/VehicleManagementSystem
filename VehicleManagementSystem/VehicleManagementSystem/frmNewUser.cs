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
    public partial class frmNewUser : Form
    {
        string cs = @"Data Source=CHAMINDA\MSSQLSERVER2;Initial Catalog=VMS;User ID=sa;Password=123";
        //string cs2 = @"Data Source=CHAMINDA\MSSQLSERVER2;Initial Catalog=MyDb;User ID=sa;Password=123";

        public frmNewUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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
                MessageBox.Show(savedPasswordHash);

                
                SqlConnection con = new SqlConnection(cs);
                con.Open();

                string sql = "insert into AppUser(UserName, Name, BranchID,PWHash) values(@UserName, @Name,@BranchID,@PWHash)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                //cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Name", TxtFullName.Text);
                cmd.Parameters.AddWithValue("@BranchID", cmbBranch.SelectedValue);
                cmd.Parameters.AddWithValue("@PWHash", savedPasswordHash);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("New user saved");

                this.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmNewUser_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string sql = "select branchid, branchname from branch";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cmbBranch.DataSource = ds.Tables[0];
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.ValueMember = "BranchID";
            cmbBranch.Enabled = true;
            //this.cmbBranch.SelectedIndex = -1;

            cmd.ExecuteNonQuery();
            con.Close();
     


        }

        private void btnHash_Click(object sender, EventArgs e)
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
            MessageBox.Show(savedPasswordHash);





            SqlConnection con = new SqlConnection(cs);
            con.Open();
             
            string sql = "insert into APUser (UserName,Password,PWHash) values(@UserName,@Password,@PWHash)";


            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@PWHash", savedPasswordHash.Trim());
            
            cmd.ExecuteNonQuery();

            con.Close();
            

             MessageBox.Show("New user saved");

            this.Close();
        }
    }
}
