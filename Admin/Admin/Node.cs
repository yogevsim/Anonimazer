using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class Node
    {
        public string ip;
        public string port;
        public string addr;
        public Node(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
            this.addr = ip + ", " + port;
        }

        public bool CompareTo(Node other)
        {
            return this.ip == other.ip && this.port == other.port;
        }


    }
}
