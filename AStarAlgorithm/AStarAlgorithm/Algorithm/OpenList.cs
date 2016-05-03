using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStarAlgorithm.DataStructures;

namespace AStarAlgorithm.Algorithm
{
    class OpenList
    {
        private ListNode root;

        public bool Empty { get { return root == null; } }

        public OpenList()
        {
            root = null;
        }

        public void Add(Node node)
        {
            Add(node, null, 0, 0);
        }

        public void Add(Node node, double distance, double estimate)
        {
            Add(node, null, distance, estimate);
        }

        public void Add(Node node, Node previous, double distance,
            double estimate)
        {
            if (root == null || distance + estimate < root.TotalDistance)
            {
                ListNode newNode =
                    new ListNode(node, previous, distance, estimate, root);
                root = newNode;
            }
            else
            {
                ListNode h = root;

                while (h.Next != null
                    && distance + estimate > h.Next.TotalDistance)
                {
                    h = h.Next;
                }

                ListNode newNode =
                    new ListNode(node, previous, distance, estimate, h.Next);
                h.Next = newNode;
            }
        }

        public ListNode ExtractFirst()
        {
            if (root != null)
            {
                ListNode first = new ListNode(root);
                RemoveFirst();

                return first;
            }
            return null;
        }

        private void RemoveFirst()
        {
            root = root.Next;
        }
    }
}