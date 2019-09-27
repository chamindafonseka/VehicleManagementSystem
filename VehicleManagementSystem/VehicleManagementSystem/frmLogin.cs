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
   
    public partial class frmLogin : Form
    {
        public static string uname = ""; // global variable for Form1
        public static string userid = "";

        public frmLogin()
        {
            InitializeComponent();
            txtPassword.Text = String.Empty;
            txtPassword.PasswordChar = '*';
            
            
        }
               

        
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("select userid from AppUser where deleted=0 and username = @username", con);
            SqlDataReader myReader;

            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            //cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim() );

            myReader = cmd.ExecuteReader();

            uname = txtUsername.Text;   // assign value for Form1
            string password = txtPassword.Text;

           
            if (myReader.HasRows == true)
            {
                myReader.Read();
                userid = myReader[0].ToString();
                myReader.Close();

                /* Fetch the stored value */
                string qry3 = "select PWHash from AppUser where userid =" + userid + "";
                SqlCommand cmd3 = new SqlCommand(qry3, con);
                SqlDataReader rd = cmd3.ExecuteReader();
                rd.Read();
                string savedPasswordHash = rd[0].ToString();
                rd.Close();
                /* Extract the bytes */
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                /* Get the salt */
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */

                try
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (hashBytes[i + 16] != hash[i])
                        {
                            throw new UnauthorizedAccessException();
                        } 
                            
                    }

                    // insert log record
                    SqlCommand cmd2 = new SqlCommand("insert into UserLoggings (Appuser, LoggedDate, Type) " + "values('" + userid + "','" + DateTime.Now + "' ,'" + 1 + "')", con);
                    cmd2.ExecuteNonQuery();

                    frmVehicleManagementSystem frmVehicleManagementSystem1 = new frmVehicleManagementSystem();
                    this.Hide();
                    frmVehicleManagementSystem1.Show();   //load Main form

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message+"\nInvalid Password.", "Password.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                    return;
                }
                
 
       
            }
            else
            {
                MessageBox.Show("Please enter Correct Username and Password !!", "Invalid UN or PW.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            con.Close();
            




        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnLogin.Focus();
        }
    }
}
