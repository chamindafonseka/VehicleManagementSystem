using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Data.SqlClient;
using System.Management;


namespace VehicleManagementSystem
{
    public partial class frmSMS : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = sa; Password = 123";

        //create an Serial Port object
        SerialPort sp = new SerialPort();

        private SerialPort _serialPort;
        public frmSMS()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string mnumber = cboPhoneNo.Text;
            string message = txtMessage.Text;

            ////https://www.codeproject.com/Questions/840577/How-to-send-SMS-from-windows-application-using-csh/////
            try
            {
                //Replace "COM" with corresponding port name
                //How to find corresponding COM port : Device Manager >> Modems >> Modem ... cansee the port number.
                //in my case : HUAWEI E353  3G Modem

                
                _serialPort = new SerialPort(cboCOMName.Text.ToString().Trim(), 115200);  //select the relavant usb modem comport

                Thread.Sleep(1000);
                _serialPort.Open();
                Thread.Sleep(1000);
                _serialPort.Write("AT+CMGF=1\r+");
                Thread.Sleep(1000);
                _serialPort.Write("AT+CMGS=\"" + mnumber + "\"\r\n");
                Thread.Sleep(1000);
                _serialPort.Write(message + "\x1A");
                Thread.Sleep(1000);
                //label1.Text = "Message Sent";
                _serialPort.Close();

                lblSent.Text = "Message sent";

                cboPhoneNo.Text = string.Empty;
                txtMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void  comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSent.Text = " ";
        }



        private void loadData()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select TeamID, TeamPhone from Team ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandText = query;
                con.Open();
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    cboPhoneNo.Items.Add(drd["TeamPhone"].ToString());
                    cboPhoneNo.ValueMember = drd["TeamID"].ToString();
                    cboPhoneNo.DisplayMember = drd["TeamPhone"].ToString();
                }
            }
            catch (Exception ex)   

            {
                MessageBox.Show(ex.Message);
            }

           
            
        }

        private void cboPhoneNo_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            //cboPort.Items.Clear();
            //string[] lports = SerialPort.GetPortNames();  // Get a list of serial port names.


            //foreach (string str in lports)
            //{
            //    cboPort.Items.Add(str);    // Display each port name to the combobox.
            //}
            //if (cboPort.Items.Count > 0)
            //    cboPort.SelectedIndex = 0;

            //GetMobileSerialNumber("COM11");
        }
        private string GetMobileSerialNumber(string PortName)
        {
            string key = "";
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = PortName;
            serialPort.BaudRate = 56700;
            try
            {
                if (!(serialPort.IsOpen))
                    serialPort.Open();
                serialPort.Write("AT\r\n");
                Thread.Sleep(3000);
                key = serialPort.ReadExisting();
                serialPort.Write("AT+CGSN\r\n");
                Thread.Sleep(3000);
                key = serialPort.ReadExisting();
                serialPort.Close();
                string Serial = "";
                for (int i = 0; i < key.Length; i++)
                    if (char.IsDigit(key[i]))
                        Serial += key[i];

                MessageBox.Show(Serial);
                return Serial;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in opening/writing to serial port :: " + ex.Message, "Error!");
                return "";
            }
        }

        private void getAllComPort()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (var a in ports)
            {
                cboCOMName.Items.Add(a);
            }
        }


        private void frmSMS_Load(object sender, EventArgs e)
        {
            getAllComPort();
            loadData();

        }
    }
}
