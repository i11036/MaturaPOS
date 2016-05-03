using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStarAlgorithm.DataStructures;

namespace AStarAlgorithm.Algorithm
{
    class ListNode
    {
        private Node node_;
        private Node prev_;
        private double distance_;
        private double estimate_;

        // Next reference (used in openlist only)
        public ListNode Next { get; set; }

        public Node Node { get { return node_; } }

        public Node Previous { get { return prev_; } }

        public double Distance { get { return distance_; } }

        // Estimated leftover distance (used in openlist only)
        public double Estimate { get { return estimate_; } }

        // Total distance (used in openlist only)
        public double TotalDistance
        {
            get
            {
                return distance_ + estimate_;
            }
        }

        public ListNode(Node node, Node previous, double distance,
            double estimate)
            : this(node, previous, distance, estimate, null)
        { }

        public ListNode(Node node, Node previous, double distance,
            double estimate, ListNode next)
        {
            node_ = node;
            prev_ = previous;
            distance_ = distance;
            estimate_ = estimate;
            Next = next;
        }

        public ListNode(ListNode copy)
        {
            if (copy != null)
            {
                node_ = copy.node_;
                prev_ = copy.prev_;
                distance_ = copy.distance_;
                estimate_ = copy.estimate_;
                Next = copy.Next;
            }
        }
    }
}
