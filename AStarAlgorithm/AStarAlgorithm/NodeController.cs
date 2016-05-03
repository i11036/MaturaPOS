using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStarAlgorithm.DataStructures;
using AStarAlgorithm.Algorithm;
using System.Windows.Forms;

namespace AStarAlgorithm
{
    class NodeController
    {
        private Dictionary<string, Node> nodes;
        private Node moveNode;
        private Node pathNode;
        private bool autoReversePaths_;

        public bool Moving
        {
            get
            {
                return moveNode != null;
            }
        }

        public NodeController(bool autoReversePaths)
        {
            Reset();
            autoReversePaths_ = autoReversePaths;
        }

        public void Reset()
        {
            nodes = new Dictionary<string, Node>();
            moveNode = null;
            pathNode = null;
        }

        public void Paint(Graphics g)
        {
            foreach (Node node in nodes.Values)
            {
                node.Paint(g);
            }
        }

        public bool AddNode(string name, int x, int y)
        {
            if (!nodes.ContainsKey(name))
            {
                nodes[name] = new Node(name, x, y);
                return true;
            }
            return false;
        }

        public bool AddPath(string name1, string name2, double distance)
        {
            if (nodes.ContainsKey(name1) && nodes.ContainsKey(name2))
            {
                nodes[name1].AddPath(nodes[name2], distance);

                if (autoReversePaths_)
                {
                    nodes[name2].AddPath(nodes[name1], distance);
                }

                return true;
            }
            return false;
        }

        public void BeginMove(int x, int y)
        {
            moveNode = Find(x, y);
        }

        public void Move(int x, int y)
        {
            if (Moving)
            {
                moveNode.MoveTo(x, y);
            }
        }

        public void EndMove(int x, int y)
        {
            moveNode = null;
        }

        public void BeginPath(int x, int y)
        {
            pathNode = Find(x, y);
        }

        public bool EndPath(int x, int y, double distance)
        {
            if (pathNode != null)
            {
                Node pathTo = Find(x, y);

                if (pathTo != null)
                {
                    bool result = AddPath(pathNode.Name, pathTo.Name,
                        distance);
                    pathNode = null;

                    return result;
                }
            }
            return false;
        }

        private Node Find(int x, int y)
        {
            foreach (Node node in nodes.Values)
            {
                if (node.Contains(x, y))
                {
                    return node;
                }
            }

            return null;
        }

        public void Trivialize()
        {
            foreach (Node node in nodes.Values)
            {
                node.Trivialize();
            }
        }

        public bool HighlightPath(string fromNode, string toNode)
        {
            if (!nodes.ContainsKey(fromNode) || !nodes.ContainsKey(toNode))
            {
                return false;
            }

            OpenList openList = new OpenList();
            ClosedList closedList = new ClosedList();

            openList.Add(nodes[fromNode]);

            while (!openList.Empty && !closedList.Contains(toNode))
            {
                // Get node to resolve
                ListNode resolve = openList.ExtractFirst();

                string prevStr = resolve.Previous != null ? resolve.Previous.Name : "-";

                // Add node to closedlist
                closedList.Add(resolve);

                // Add all neighbours of the resolved node to openlist
                foreach (Path path in resolve.Node.Paths)
                {
                    Node neighbour = path.Neighbour;

                    openList.Add(neighbour, resolve.Node,
                        resolve.Distance + path.Distance,
                        resolve.Node.GetDiagonal(neighbour));
                }
            }

            if (!closedList.Contains(toNode))
            {
                return false;
            }

            List<Node> finalPath = closedList.GetPath(fromNode, toNode);

            if (finalPath == null)
            {
                return false;
            }

            // Highlight path

            for (int i = 0; i < finalPath.Count - 1; i++)
            {
                finalPath[i].HighlightPath(finalPath[i + 1].Name);
            }

            return true;
        }
    }
}
