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
    public partial class frmChangePassword : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
        string curuser = frmLogin.uname;

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            lblUname.Text = frmLogin.uname.Trim();


            string qry = "select Name from AppUser where Username = '" + frmLogin.uname.Trim() + "'";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            lblFullName.Text = rd[0].ToString();
            rd.Close();

            con.Close();




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == string.Empty)
            {
                MessageBox.Show("Please enter the new password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPassword.Focus();
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
                string password = txtNewPassword.Text;
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
                    DialogResult d = MessageBox.Show(curuser.ToString() + "'s password going to be changed", "Change Password", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (d == DialogResult.Yes)
                    {
                        string sql = "update AppUser set PWHash = @PWHash  where UserName ='" + curuser + "'";
                        SqlConnection con = new SqlConnection(cs);

                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@PWHash", savedPasswordHash);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        txtNewPassword.Text = string.Empty;
                        this.Close();
                    }
                    else
                    {
                        txtNewPassword.Focus();
                        txtNewPassword.Clear();
                        return;
                    }
                    

                    MessageBox.Show(curuser.ToString() + "'s password has been changed","Password change",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ".", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }
    }
}
