using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class SystemState
    {
        public report stateReport;
        public Node[] stateNodes;
        public int stateIndex;

        public SystemState(report rep, Node[] nodes,int index)
        {
            this.stateReport = rep;
            this.stateNodes = nodes;
            this.stateIndex = index;
        }
    }
}
