using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatGUI
{
    class GuiState : State
    {
        static readonly Pen defaultPen = Pens.Black;
        static readonly Brush defaultBrush = Brushes.Black;
        static readonly Font defaultFont = new Font("Arial", defaultSize / 2);

        private const int defaultX = 10;
        private const int defaultY = 10;
        private const int defaultSize = 25;
        private const double innerSizeRatio = 0.8;
        private const int defaultArrowSize = 5;

        private int x_;
        private int y_;
        private int size_;
        private Pen pen_;
        private Brush brush_;
        private Font font_;

        public GuiState(string name, int x, int y)
            : this(name, x, y, false)
        { }

        public GuiState(string name, int x, int y, bool isEndState)
            : this(name, x, y, isEndState, defaultSize, defaultPen,
                  defaultBrush, defaultFont)
        { }

        public GuiState(string name, int x, int y, bool isEndState, int size)
            : this(name, x, y, isEndState, size, defaultPen,
                  defaultBrush, defaultFont)
        { }

        public GuiState(string name, int x, int y, bool isEndState,
            int size, Pen pen, Brush brush, Font font)
            : base(name, isEndState)
        {
            x_ = x;
            y_ = y;
            size_ = size;
            pen_ = pen;
            brush_ = brush;
            font_ = font;
        }

        public GuiState(State state) : base(state)
        {
            x_ = defaultX;
            y_ = defaultY;
            size_ = defaultSize;
            pen_ = defaultPen;
            brush_ = defaultBrush;
            font_ = defaultFont;
        }

        public bool Contains(int x, int y)
        {
            double diagonal = Math.Sqrt(
                Math.Pow(x - x_, 2) + Math.Pow(y - y_, 2)
            );

            if (diagonal <= size_) return true;
            return false;
        }

        public void MoveTo(int x, int y)
        {
            x_ = x;
            y_ = y;
        }

        public void Paint(Graphics g)
        {
            int xPos = x_ - size_ / 2;
            int yPos = y_ - size_ / 2;
            int xPosInner = x_ - (int)(size_ * innerSizeRatio / 2);
            int yPosInner = y_ - (int)(size_ * innerSizeRatio / 2);

            g.DrawEllipse(pen_, xPos, yPos, size_, size_);
            if (IsFinalState)
            {
                g.DrawEllipse(pen_, xPosInner, yPosInner,
                    (int)(size_ * innerSizeRatio),
                    (int)(size_ * innerSizeRatio));
            }

            PaintName(g);

            foreach (KeyValuePair<char, State> path in paths)
            {
                if (path.Value is GuiState)
                {
                    GuiState toState = (GuiState)path.Value;
                    PaintArrow(g, toState);
                }
            }
        }

        private void PaintName(Graphics g)
        {
            SizeF textSize = g.MeasureString(Name, font_);
            int xTextPos = x_ - (int)(textSize.Width / 2);
            int yTextPos = y_ - (int)(textSize.Height / 2);

            g.DrawString(Name, font_, brush_, xTextPos, yTextPos);
        }

        private void PaintArrow(Graphics g, GuiState toState)
        {
            if (!Equals(toState))
            {
                // Vector from this state to toState
                Vector arrow = new Vector(toState.x_ - x_, toState.y_ - y_);

                // Arrow shaft vector
                Vector shaftVec = new Vector(arrow);
                shaftVec.Length = size_ / 2;

                // Arrow shaft position
                Vector shaftPos = new Vector(x_, y_);
                shaftPos.AddVector(shaftVec);

                // Arrow tip vector
                Vector tipVec = new Vector(arrow);
                tipVec.Length = arrow.Length - toState.size_ / 2;

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

                // Draw arrow
                g.DrawLine(pen_, shaftPos.X, shaftPos.Y, tipPos.X, tipPos.Y);
                g.DrawLine(pen_, tipPos.X, tipPos.Y,
                    arrowPart1.X, arrowPart1.Y);
                g.DrawLine(pen_, tipPos.X, tipPos.Y,
                    arrowPart2.X, arrowPart2.Y);
            }
            else
            {
                // Arrow tip position
                Vector shaftPos = new Vector(x_ + size_ / 2, y_);

                // Arrow tip position
                Vector tipPos = new Vector(x_, y_ + size_ / 2);

                // Arrow part 1 vector
                Vector arrowPart1Vec = new Vector(size_, size_);
                arrowPart1Vec.Length = size_ / 2;

                // Arrow part 1 position
                Vector arrowPart1 = new Vector(tipPos);
                arrowPart1.AddVector(arrowPart1Vec);

                // Arrow part 2 vector
                Vector arrowPart2Vec = new Vector(-size_, size_);
                arrowPart2Vec.Length = size_ / 2;

                // Arrow part 2 position
                Vector arrowPart2 = new Vector(tipPos);
                arrowPart2.AddVector(arrowPart2Vec);

                // Draw Arrow
                g.DrawArc(pen_, x_, y_, size_, size_, -90, 270);
                g.DrawLine(pen_, tipPos.X, tipPos.Y,
                    arrowPart1.X, arrowPart1.Y);
                g.DrawLine(pen_, tipPos.X, tipPos.Y,
                    arrowPart2.X, arrowPart2.Y);
            }
        }

        public void PaintInitState(Graphics g)
        {
            // Vector pointing down
            Vector arrow = new Vector(0, -1);

            // Arrow shaft vector
            Vector shaftVec = new Vector(arrow);
            shaftVec.Length = size_ * 1.5;

            // Arrow shaft position
            Vector shaftPos = new Vector(x_, y_);
            shaftPos.AddVector(shaftVec);

            // Arrow tip vector
            Vector tipVec = new Vector(arrow);
            tipVec.Length = size_ * 0.5;

            // Arrow tip position
            Vector tipPos = new Vector(x_, y_);
            tipPos.AddVector(tipVec);

            // Generate small arrow parts
            const int angleDegrees = 135;

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

            // Draw arrow
            g.DrawLine(pen_, shaftPos.X, shaftPos.Y, tipPos.X, tipPos.Y);
            g.DrawLine(pen_, tipPos.X, tipPos.Y,
                arrowPart1.X, arrowPart1.Y);
            g.DrawLine(pen_, tipPos.X, tipPos.Y,
                arrowPart2.X, arrowPart2.Y);
        }
    }
}