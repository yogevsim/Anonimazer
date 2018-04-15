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

namespace Admin
{
    public partial class Admin : Form
    {
        IConnector connector;
        int numOfNodes;

        public Admin()
        {
            InitializeComponent();
        }

        public void SetConnector(IConnector conct)
        {
            this.connector = conct;
        }

        public void UpdateNodeList()
        {
            string contacts = connector.GetContacts();

            List<Node> newNodeList = new List<Node>();

            int i = 0;
            string[] contactsArr = contacts.Split('^');
            this.numOfNodes = contactsArr.Length;
            this.conctdNodeLbl.Text = "Connected Nodes: " + this.numOfNodes;

            foreach (string s in contactsArr)
            {
                if (s.Contains(','))
                {
                    string[] temp = s.Split(',');
                    Node newNode = new Node(temp[0], temp[1]);

                    newNodeList.Add(newNode);
                    this.NodeList.Items.Add(newNode.addr);
                    i++;
                }
            }

            this.connector.UpdateAllConectedNodes(newNodeList);
            
        }

        private void KickBtn_Click(object sender, EventArgs e)
        {
            this.connector.KickNode(this.NodeList.Text);
            this.NodeList.Items.Remove(NodeList.SelectedItem);
            this.numOfNodes--;
            this.conctdNodeLbl.Text = "Connected Nodes: " + this.numOfNodes;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.NodeList.Items.Clear();
            UpdateNodeList();
        }

        public void UpdateTrafficTable(report rep,Color color)
        {
            Row row = new Row(rep, color);
            row.BackColor = color;
            TrafficTable.Controls.Add(row);
        }

        public void ActivateTrafficUpdate()
        {
            this.connector.UpdateTrafficTable();
        }

        private void UpdateTrafficTimer_Tick(object sender, EventArgs e)
        {
            this.ActivateTrafficUpdate();
        }

        public void InitTrafficTable()
        {
            this.UpdateTrafficTable(new report("Last Node:", "Current Node:", "Next Node:", "Timestamp:", "Data:"),Color.White);
;        }

        private void OpenMeshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connector.GetMeshView().Show();
            }
            catch (Exception)
            {
                connector.CreateNewMeshView();
                connector.GetMeshView().Show();


            }
        }
    }
}
