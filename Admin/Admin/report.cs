using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class report
    {
        public string lastAddr;
        public string addr;
        public string nextAddr;
        public string timeStamp;
        public string data;

        public report(string lastAddr, string addr, string nextAddr, string timeStamp, string data)
        {
            this.lastAddr = lastAddr;
            this.addr = addr;
            this.nextAddr = nextAddr;
            this.timeStamp = timeStamp;
            this.data = data;
        }
        

    }
}
