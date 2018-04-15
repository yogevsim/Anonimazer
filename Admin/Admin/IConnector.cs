using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public interface IConnector
    {
        string GetContacts();
        void KickNode(string addr);
        void UpdateTrafficTable();
        void UpdateAllConectedNodes(List<Node> newList);
        MeshView GetMeshView();
        void CreateNewMeshView();
    }
}
