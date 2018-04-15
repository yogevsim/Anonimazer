using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Admin
{
    class Controller : IConnector
    {
        public Admin form;
        public MeshView mesh;
        public List<Node> allConnectedNodes;
        MainServerConnection serverConnection;
        bool flag = false;
        List<SystemState> allStates = new List<SystemState>();

        int states = 0;
        DB_Server dbServer;
        int colorInex = 0;

        public Controller(Admin form)
        {
            this.form = form;
            form.SetConnector(this);

            this.serverConnection = new MainServerConnection();
            this.allConnectedNodes = new List<Node>();
            this.dbServer = new DB_Server();
            this.mesh = new MeshView();


            this.Init();

        }

        public void UpdateAllConectedNodes(List<Node> newList)
        {
            this.allConnectedNodes = newList;
        }


        public string GetContacts()
        {
            return serverConnection.SendRequest("get all clients");
        }

        public void Init()
        {
            form.UpdateNodeList();
            form.InitTrafficTable();
        }

        public void KickNode(string addr)
        {
            string[] temp = addr.Split(',');
            this.serverConnection.SendRequest(String.Format("kick~{0}~{1}", temp[0], temp[1].Split(' ')[1]));
        }

        public void UpdateTrafficTable()
        {
            // 6 colors
            Color[] colorArray = { Color.Red,Color.Cyan,Color.LightGreen,Color.LightYellow,Color.Indigo,Color.Gray };
            report rep = null;
            if(this.dbServer.newReports.Count > 0)
                rep = this.dbServer.newReports.Dequeue();

            if (rep != null)
            {
                Node[] currentNodeArray = new Node[allConnectedNodes.Count];
                allConnectedNodes.CopyTo(currentNodeArray);
                mesh.AddState(new SystemState(rep, currentNodeArray,this.states));
                this.allStates.Add(new SystemState(rep, currentNodeArray, this.states));
                this.states++;

               

                if (this.flag)
                {
                    if (this.colorInex == 5)
                        this.colorInex = 0;
                    else
                        colorInex++;
                    this.flag = false;
                }

                if (rep.nextAddr == "Reciever")
                {
                    this.flag = true;
                }




                form.UpdateTrafficTable(rep,colorArray[colorInex]);
                Thread.Sleep(100);
            }
        }

        public MeshView GetMeshView()
        {            
               return this.mesh;

        }

        public void CreateNewMeshView()
        {
            MeshView newMesh = new MeshView();
            newMesh.allStates = this.allStates;
            this.mesh = newMesh;
        }


    }
}
