using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStarAlgorithm.DataStructures;
using System.Windows.Forms;

namespace AStarAlgorithm.Algorithm
{
    class ClosedList
    {
        private Dictionary<string, ListNode> nodes;

        public ClosedList()
        {
            nodes = new Dictionary<string, ListNode>();
        }

        public void Add(ListNode listNode)
        {
            if (listNode != null)
            {
                Node node = listNode.Node;
                if (!nodes.ContainsKey(node.Name)
                    || listNode.Distance < nodes[node.Name].Distance)
                {
                    nodes[node.Name] = new ListNode(listNode);
                }
            }
        }

        public List<Node> GetPath(string fromNode, string toNode)
        {
            if (!nodes.ContainsKey(toNode))
            {
                return null;
            }

            List<Node> path = new List<Node>();
            ListNode listNode = nodes[toNode];

            while (listNode != null && listNode.Node.Name != fromNode)
            {
                path.Add(listNode.Node);

                string prevNode = listNode.Previous.Name;

                if (!nodes.ContainsKey(prevNode))
                {
                    return null;
                }

                listNode = nodes[prevNode];
            }

            if (listNode == null || listNode.Node.Name != fromNode)
            {
                return null;
            }
            
            path.Add(listNode.Node);
            path.Reverse();

            return path;
        }

        public bool Contains(string nodeName)
        {
            return nodes.ContainsKey(nodeName);
        }
    }
}
