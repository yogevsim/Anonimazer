using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class Row : UserControl
    {


        public Row(report rep, Color color)
        {
            InitializeComponent();
            this.PopulateRow(rep,color);


        }

        public void PopulateRow(report rep,Color color)
        {
            LastNodeLbl.Text = rep.lastAddr;
            LastNodeLbl.BackColor = color;

            NameLbl.Text = rep.addr;
            NameLbl.BackColor = color;

            NextNodeLbl.Text = rep.nextAddr;
            NextNodeLbl.BackColor = color;

            TimeStampLbl.Text = rep.timeStamp;
            TimeStampLbl.BackColor = color;

            DataLbl.Text = rep.data;
            DataLbl.BackColor = color;


        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DataLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
