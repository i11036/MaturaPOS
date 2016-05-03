using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm.DataStructures
{
    class Node
    {
        private const int defaultSize = 20;
        static readonly Pen defaultPen = Pens.Black;
        static readonly Brush defaultBrush = Brushes.Black;
        static readonly Font defaultFont = new Font("Arial", defaultSize / 2);

        private string name_;
        private int x_;
        private int y_;
        private int size_;

        private Pen pen_;
        private Brush brush_;
        private Font font_;

        private List<Path> paths;

        public int X { get { return x_; } }
        public int Y { get { return y_; } }
        public string Name { get { return name_; } }
        public List<Path> Paths { get { return paths; } }

        public Node(string name, int x, int y)
            : this(name, x, y, defaultSize)
        { }

        public Node(string name, int x, int y, int size)
            : this(name, x, y, size, defaultPen,
                  defaultBrush, defaultFont)
        { }

        public Node(string name, int x, int y, int size,
            Pen pen, Brush brush, Font font)
        {
            name_ = name;
            x_ = x;
            y_ = y;
            size_ = size;
            pen_ = pen;
            brush_ = brush;
            font_ = font;

            paths = new List<Path>();
        }

        public void Paint(Graphics g)
        {
            // Draw circle
            int xPos = x_ - size_ / 2;
            int yPos = y_ - size_ / 2;
            g.DrawEllipse(pen_, xPos, yPos, size_, size_);

            // Draw name
            SizeF textSize = g.MeasureString(name_, font_);
            int xPosText = x_ - (int)(textSize.Width / 2);
            int yPosText = y_ - (int)(textSize.Height / 2);
            g.DrawString(Name, font_, brush_, xPosText, yPosText);

            // Draw paths
            foreach (Path path in paths)
            {
                Node neighbour = path.Neighbour;
                int otherX = neighbour.x_;
                int otherY = neighbour.y_;

                // Vector from this state to toState
                Vector arrow = new Vector(otherX - x_, otherY - y_);

                // Arrow shaft vector
                Vector shaftVec = new Vector(arrow);
                shaftVec.Length = size_ / 2;

                // Arrow shaft position
                Vector shaftPos = new Vector(x_, y_);
                shaftPos.AddVector(shaftVec);

                // Arrow tip vector
                Vector tipVec = new Vector(arrow);
                tipVec.Length = arrow.Length - neighbour.size_ / 2;

                // Arrow tip position
                Vector tipPos = new Vector(x_, y_);
                tipPos.AddVector(tipVec);

                // Generate small arrow parts
                const int angleDegrees = 45;

                // Arrow part 1 vector
                Vector arrowPart1Vec = new Vector(arrow);
                arrowPart1Vec.Length = size_ / 2;
                arrowPart1Vec.Rotate(180 - angleDegrees);

                // Arrow part 1 position
                Vector arrowPart1 = new Vector(tipPos);
                arrowPart1.AddVector(arrowPart1Vec);

                // Arrow part 2 vector
                Vector arrowPart2Vec = new Vector(arrow);
                arrowPart2Vec.Length = size_ / 2;
                arrowPart2Vec.Rotate(-(180 - angleDegrees));

                // Arrow part 2 position
                Vector arrowPart2 = new Vector(tipPos);
                arrowPart2.AddVector(arrowPart2Vec);

                // Determine pen
                Pen pen = pen_;

                if (path.Highlighted)
                {
                    pen = Pens.Red;
                }

                // Draw arrow
                g.DrawLine(pen, shaftPos.X, shaftPos.Y, tipPos.X, tipPos.Y);
                g.DrawLine(pen, tipPos.X, tipPos.Y, arrowPart1.X, arrowPart1.Y);
                g.DrawLine(pen, tipPos.X, tipPos.Y, arrowPart2.X, arrowPart2.Y);
            }
        }

        public void AddPath(Node n, double distance)
        {
            paths.Add(new Path(n, distance));
        }

        public bool Contains(int x, int y)
        {
            double diag = Math.Sqrt(
                Math.Pow(x - x_, 2) + Math.Pow(y - y_, 2)
            );

            if (diag <= size_ / 2)
            {
                return true;
            }
            return false;
        }

        public void MoveTo(int x, int y)
        {
            x_ = x;
            y_ = y;
        }

        public void HighlightPath(string pathTo)
        {
            foreach (Path path in paths)
            {
                if (path.Neighbour.name_ == pathTo)
                {
                    path.Highlighted = true;
                }
            }
        }

        public void Trivialize()
        {
            foreach (Path path in paths)
            {
                path.Highlighted = false;
            }
        }

        public double GetDiagonal(Node other)
        {
            if (other != null)
            {
                Vector v = new Vector(other.x_ - x_, other.y_ - y_);
                return v.Length;
            }

            return 0;
        }
    }
}
