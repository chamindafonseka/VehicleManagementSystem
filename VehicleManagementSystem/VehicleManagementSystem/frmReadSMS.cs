using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace VehicleManagementSystem
{
    public partial class frmReadSMS : Form
    {
        string cs = @"Data Source = CHAMINDA\MSSQLSERVER2; Initial Catalog = VMS; User Id = vmsuser; Password = 890";
        public frmReadSMS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            readSMS();
            // listView1.Refresh();


        }

        private void readSMS()
        {
            try
            {
                //"READ SMS USING C#, RECEIVE SMS" on YouTube : https://youtu.be/G-oHL_sHQS4
                string comport = string.Empty;
                SerialPort _serialPort = new SerialPort("COM10", 115200);
                _serialPort.Parity = Parity.None;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Handshake = Handshake.XOnXOff;

                _serialPort.DtrEnable = true;
                _serialPort.RtsEnable = true;
                _serialPort.NewLine = Environment.NewLine;

                _serialPort.Open();

                _serialPort.Write("AT" + System.Environment.NewLine); // starting "AT" is the prefix that informs the modem about the start of a command line. 
                Thread.Sleep(1000);

                _serialPort.WriteLine("AT+CMGF=1" + System.Environment.NewLine);
                Thread.Sleep(1000);
                _serialPort.WriteLine("AT+CMGL=\"ALL\"\r" + System.Environment.NewLine);
                Thread.Sleep(3000);



                // MessageBox.Show(_serialPort.ReadExisting());

                Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
                Match m = r.Match(_serialPort.ReadExisting());

                if (!m.Success)
                {
                    MessageBox.Show("No SMS to view");
                }
                else
                {
                    while (m.Success)
                    {
                        string a = m.Groups[1].Value;
                        string b = m.Groups[2].Value;
                        string c = m.Groups[3].Value;
                        string d = m.Groups[4].Value;
                        string ee = m.Groups[5].Value;
                        string f = m.Groups[6].Value;

                        ListViewItem item = new ListViewItem(new string[] { a, b, c, d, "20" + ee, f }); // added '20' to compatible with table-message datetime format


                        listView1.Items.Add(item);
                        m = m.NextMatch();

                        listView1.Columns[5].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        listView1.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        listView1.Columns[4].Width = 140;
                        listView1.Columns[2].Width = 110;
                        listView1.Columns[1].Width = 100;

                    }
                }


                _serialPort.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void listviewDataToTable()
        {
            try
            {
                string qry = "insert into   Message ( PhoneNo,date,message,flag) values(@PhoneNo, @Date, @message, @flag)";

                SqlConnection con = new SqlConnection(cs);

                int i;
                for (i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@PhoneNo", Convert.ToString((listView1.Items[i].SubItems[2].Text).Replace("+94", "0")));

                    cmd.Parameters.AddWithValue("@Date", Convert.ToString((listView1.Items[i].SubItems[4].Text).Substring(0, 19).Trim()).Replace(",", " "));
                    cmd.Parameters.AddWithValue("@message", (listView1.Items[i].SubItems[5].Text).Trim());
                    cmd.Parameters.AddWithValue("@flag", 0);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    
                }
                MessageBox.Show(i+" SMS records have been uploaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteSMS() //delete sms from the SIM card
        {
            //Delete SMS from the SIM card.
            SerialPort _serialPort = new SerialPort("COM10", 115200);
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.XOnXOff;

            _serialPort.DtrEnable = true;
            _serialPort.RtsEnable = true;
            _serialPort.NewLine = Environment.NewLine;

            _serialPort.Open();
            _serialPort.Write("AT" + System.Environment.NewLine);
            Thread.Sleep(1000);
            _serialPort.WriteLine("AT+CMGD=1,4" + System.Environment.NewLine);
            Thread.Sleep(3000);


            _serialPort.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            listviewDataToTable(); // copy all SMS in the listview to table
            deleteSMS();  // deleted the copied-SMS from SIM card
            listView1.Items.Clear();



            //string aa = (listView1.Items[2].SubItems[4].Text);
            // MessageBox.Show(string.Concat((listView1.Items[2].SubItems[4].Text).Take(8)));



            //string r = Convert.ToString((listView1.Items[2].SubItems[4].Text).Substring(0, 17)).Trim().Replace(",", " ");



            //MessageBox.Show(c);





        }
    }
}

