using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm.DataStructures
{
    class Path
    {
        public Node Neighbour { get; }
        public double Distance { get; }
        public bool Highlighted { get; set; }

        public Path(Node neighbour, double distance)
        {
            Neighbour = neighbour;
            Distance = distance;
            Highlighted = false;
        }
    }
}
