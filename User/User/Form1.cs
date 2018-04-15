using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace User
{
    public partial class Form1 : Form
    {
        TcpClient client = new TcpClient();
        Stream stream;
        ASCIIEncoding asen = new ASCIIEncoding();


        public Form1()
        {
            InitializeComponent();
            this.ConnectToSystem();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ConnectToSystem()
        {
            this.client.Connect("127.0.0.1", 5005);
            this.stream = this.client.GetStream();
            this.stream.ReadTimeout = 5000;
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            //Thread send = new Thread(this.SendMsg);
            //send.Start();
            if (this.ValidateIP() && this.ValidatePort())
            {
                try
                {
                    this.SendMsg();
                }
                catch (Exception)
                {
                    this.ConnectToSystem();
                    this.SendMsg();
                }
            }

            else
                MessageBox.Show(" Please make sure both the IP and Port are valid. \n Example: \n 10.10.10.10 (numbers between 0-255) \n 5000 (numbers between 0-65535)");
        }

        public bool ValidateIP()
        {
            try
            {
                string[] ip = this.ip_box.Text.Split('.');
                if (ip.Length == 4)
                {
                    foreach (string num in ip)
                    {
                        int check = int.Parse(num);
                        if (check < 0 || check > 255)
                            return false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
                
        }

        public bool ValidatePort()
        {
            try
            {
                int num = int.Parse(this.port_box.Text);
                if (num < 0 || num > 65535)
                    return false;
                return true;

            }
            catch (Exception)
            {
                return false;
            }
                
        }

        public void UpdateTick()
        {
            this.tickmark.Visible = false;
        }

        public void SendInSock(string ip, string port, string msg)
        {
            string request = String.Format("send~{0}~{1}~{2}", ip, port, msg);
            byte[] ba = asen.GetBytes(request);
            this.stream.Write(ba, 0, ba.Length);
        }

        public void SendMsg()
        {
            this.send_btn.Enabled = false;

            string ans = "";
            string ip = this.ip_box.Text;
            string port = this.port_box.Text;
            string msg = this.msg_box.Text;
            this.msg_box.Clear();



            this.SendInSock(ip, port, msg);
            int k = 0;
            byte[] bb = new byte[100];
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    k = stream.Read(bb, 0, 100);
                    break;
                }
                catch (IOException ioEx)
                {
                    this.SendInSock(ip, port, msg);
                    Console.WriteLine("Sending Again...");
                }                
            }

            if (k == 0)
                MessageBox.Show("Can't send now... \n please try again later.");

            for (int i = 0; i < k; i++)
                ans += Convert.ToChar(bb[i]);
            Console.WriteLine(ans);
            if (ans == "ack")
            {
                Console.WriteLine("in ack");
                this.tickmark.Visible = true;
                this.tickTimer.Enabled = true;
            }
            this.send_btn.Enabled = true;

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tickmark.Visible = false;
            this.tickTimer.Enabled = false;
        }

        private void msg_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.send_btn.PerformClick();
            }
        }

        private void tickmark_VisibleChanged(object sender, EventArgs e)
        {
            if(tickmark.Visible == true)
                this.tickTimer.Enabled = false;

        }

        private void browseFile_btn_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string ans = "";
                            byte[] bb = new byte[100000];
                            int k = myStream.Read(bb, 0, 1000);


                            for (int i = 0; i < k; i++)
                                ans += Convert.ToChar(bb[i]);
                            Console.WriteLine(ans);
                            this.msg_box.Text = ans;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
              }
            }

        private void send_btn_EnabledChanged(object sender, EventArgs e)
        {

        }
    }
}
