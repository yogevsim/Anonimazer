using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Admin
{
    class DB_Server
    {
        TcpListener listener;
        public Queue<report> newReports = new Queue<report>();
        public List<report> allReports = new List<report>();

        public DB_Server()
        {
            this.InitListener();

            Thread t = new Thread(Listen);
            t.Start();
        }

        public void InitListener()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            Console.WriteLine("Starting TCP listener...");

            this.listener = new TcpListener(ipAddress, 7000);

            listener.Start();
        }



        public void Listen()
        {
            while (true)
            {
                Console.WriteLine("Server is listening on " + listener.LocalEndpoint);

                Console.WriteLine("Waiting for a connection...");

                Socket client = listener.AcceptSocket();

                Console.WriteLine("Connection accepted.");

                Console.WriteLine("Reading data...");

                Thread myNewThread = new Thread(() => HandleReports(client));
                myNewThread.Start();
            }
           
        }

        private void HandleReports(Socket client)
        {
            while (true)
            {
                byte[] data = new byte[1000];
                string ans = "";
                int size = client.Receive(data);
                Console.WriteLine("Recieved data: ");
                for (int i = 0; i < size; i++)
                    ans += Convert.ToChar(data[i]);

                Console.WriteLine(ans);
                string[] detailes = ans.Split('~');
                report rep = new report(detailes[0], detailes[1], detailes[2], detailes[3], detailes[4]);
                this.newReports.Enqueue(rep);
                this.allReports.Add(rep);
            }
        }

    
    }
}
