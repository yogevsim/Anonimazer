using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;



namespace GraphicsTest
{
    public partial class Form1 : Form
    {
        Graphics graph;
        Brush b;
        Pen redPen;
        GraphicsState state;
        int numOfCirc = 30;
        public Form1()
        {
            InitializeComponent();
        }

        public void Init()
        {
           
        }

        public void PaintTest()
        {
            this.graph = canvas.CreateGraphics();
            this.b = new SolidBrush(Color.Red);
            this.redPen = new Pen(b, 10);
            //  this.graph.DrawLine(redPen, 10, 10, 400, 400);

            int j = 0;
            int h = 100;
            int w = 200;
            for (int i = 0; i < this.numOfCirc; i++)
            {
                this.DrawCircle(graph, redPen, w, h, 20);
                if (j == 5)
                {
                    h += 100;
                    w = 150;
                    j = -1;
                }
                j++;
                w += 50;

            }
        }

        public void DrawCircle(Graphics g, Pen pen,
                                 float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            this.PaintTest();
           

        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.graph.Clear(Color.White);
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.graph.Clear(Color.White);
            this.numOfCirc++;
            this.PaintTest();
            this.state = this.graph.Save();

        }

        private void Sub_Click(object sender, EventArgs e)
        {
            this.graph.Clear(Color.White);
            this.numOfCirc--;
            this.PaintTest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.graph.Restore(this.state);
        }
    }
}
