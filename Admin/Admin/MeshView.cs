using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Admin
{
    public partial class MeshView : Form
    {
        public List<SystemState> allStates = new List<SystemState>();
        List<GraphicsState> savedSatetes = new List<GraphicsState>();
        PointF senderLocation;
        Point recieverLocation;
        Graphics graph;
        Brush b;
        Pen redPen;
        int stateIndex = 0;

        public MeshView()
        {
            InitializeComponent();
        }

        public void AddState(SystemState state)
        {
            this.allStates.Add(state);
        }

        public Node AddrToNode(string Addr)
        {
            if(Addr == "Reciever")
                return new Node("recv", "recv");


            string ip = Addr.Split(',')[0].Split('\'')[1];
            string port = Addr.Split(',')[1].Split(')')[0].Split(' ')[1];
            Console.WriteLine(ip + " " + port);
            return new Node(ip, port);
            

            
            
           
        }

        public Point FindLocationOfNode(Node node, Node[] stateNodes, Point[] nodesLocations)
        {
            if (node.ip == "recv")
                return this.recieverLocation;

            for (int i = 0; i < stateNodes.Length; i++)
            {
                Console.WriteLine(node.ip +" - "+node.port);
                Console.WriteLine(stateNodes[i].ip+" - "+ stateNodes[i].port);
                if (stateNodes[i].CompareTo(node))
                    return nodesLocations[i];
            }
            return new Point(0,0);
        }

        public void DrawState(SystemState state)
        {
            Node[] stateNodes = state.stateNodes.ToArray();
            Point[] nodesLocations = new Point[stateNodes.Length];
            int numOfNodes = stateNodes.Length;
            
            
            int j = 0;
            int h = 100;
            int w = 200;

            int numOfNodesInRow = numOfNodes / 4;
            int spaseBetweenNodes = 700 / numOfNodesInRow;

            this.DrawSenderRecver();
            for (int i = 0; i < stateNodes.Length; i++)
            {
                Node nod = stateNodes[i];
                this.DrawCircleWithAddr(nod.ip, nod.port, w, h);
                nodesLocations[i] = new Point(w, h);
                if (j == numOfNodesInRow)
                {
                    h += 150;
                    w = 200-spaseBetweenNodes;
                    j = -1;
                }
                j++;
                w += spaseBetweenNodes;

            }

            for (int i = 0; i < state.stateIndex+1; i++)
            {
                this.DrawTheLines(allStates.ElementAt(i), stateNodes, nodesLocations);
            }
            

        }

        public void DrawTheLines(SystemState state,Node[] stateNodes,Point[] nodesLocations)

        {
            Node currentNode = this.AddrToNode(state.stateReport.addr);
            Node NextNode = this.AddrToNode(state.stateReport.nextAddr);
            Pen pen = new Pen(new SolidBrush(Color.Gray), 10);

            Point currentLocation = this.FindLocationOfNode(currentNode, stateNodes, nodesLocations);
            Point nextLocation = this.FindLocationOfNode(NextNode, stateNodes, nodesLocations);

            //Console.WriteLine(state.stateReport.lastAddr + "gffffffffffffffffffffffffffffffffffffffffffffff");
            if (state.stateReport.lastAddr == "Sender")
            {
                //Console.WriteLine("ssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
                this.graph.DrawLine(pen, this.senderLocation, currentLocation);
            }

            Console.WriteLine(currentLocation.ToString());
            this.graph.DrawLine(pen, currentLocation, nextLocation);

        }



        public void DrawCircleWithAddr(string ip, string port, float centerX, float centerY)
        {
            Brush br = new SolidBrush(Color.DarkGray);
            Brush blackBrash = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(br, 10);
            this.DrawCircle(this.graph, blackPen, centerX, centerY, 20);

            this.graph.DrawString(ip, Font, blackBrash, centerX - 25, centerY - 10);
            this.graph.DrawString(port, Font, blackBrash, centerX - 17, centerY + 5);


        }

        public void DrawCircle(Graphics g, Pen pen,
                                 float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        private void grid_Paint(object sender, PaintEventArgs e)
        {
            this.graph = grid.CreateGraphics();
            this.b = new SolidBrush(Color.Red);
            this.redPen = new Pen(b, 10);
            this.DrawSenderRecver();

            
        }
        public void DrawSenderRecver()
        {
            this.senderLocation = new Point(50, 350);
            this.recieverLocation = new Point(1000, 350);

            this.DrawCircle(this.graph, this.redPen, senderLocation.X, senderLocation.Y, 30);
            this.DrawCircle(this.graph, this.redPen, recieverLocation.X, recieverLocation.Y, 30);

            this.graph.DrawString("Sender", Font, this.b, senderLocation.X - 20, senderLocation.Y - 5);
            this.graph.DrawString("Reciever", Font, this.b, recieverLocation.X - 25, recieverLocation.Y - 5);

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.graph.Clear(Color.White);
            this.stateIndex--;
            if (this.stateIndex == 0)
                this.BackBtn.Enabled = false;
            if (this.NextBtn.Enabled == false)
                this.NextBtn.Enabled = true;
            this.DrawState(allStates.ElementAt(stateIndex));
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {


            if (this.stateIndex >= 0)
                this.BackBtn.Enabled = true;
            this.stateIndex++;

            this.graph.Clear(Color.White);
            this.DrawState(allStates.ElementAt(stateIndex));

            if (this.stateIndex == this.allStates.Count - 1)
                this.NextBtn.Enabled = false;

        }
    }
}
