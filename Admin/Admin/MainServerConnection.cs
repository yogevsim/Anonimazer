using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class MainServerConnection
    {
        TcpClient client = new TcpClient();
        Stream stream;
        ASCIIEncoding asen = new ASCIIEncoding();

        public MainServerConnection()
        {
            this.client.Connect("127.0.0.1", 5001);
            Console.WriteLine("connected");
            this.stream = this.client.GetStream();
        }


        public string SendRequest(string request)
        {
            string ans = "";
            byte[] ba = asen.GetBytes(request);
            this.stream.Write(ba, 0, ba.Length);


            byte[] bb = new byte[100000];
            int k = stream.Read(bb, 0, 1000);


            for (int i = 0; i < k; i++)
                ans += Convert.ToChar(bb[i]);
            Console.WriteLine(ans);
            return ans;

        }

    }
}
