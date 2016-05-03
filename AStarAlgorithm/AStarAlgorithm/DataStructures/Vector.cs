using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm.DataStructures
{
    class Vector
    {
        private int x_;
        private int y_;

        public int X { get { return x_; } }
        public int Y { get { return y_; } }
        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(x_, 2) + Math.Pow(y_, 2));
            }

            set
            {
                double oldLength = Length;

                if (oldLength > 0)
                {
                    x_ = (int)(x_ / oldLength * value);
                    y_ = (int)(y_ / oldLength * value);
                }
            }
        }

        public Vector(int x, int y)
        {
            x_ = x;
            y_ = y;
        }

        public Vector(Vector v)
        {
            x_ = v.X;
            y_ = v.Y;
        }

        public void AddVector(Vector v)
        {
            x_ += v.X;
            y_ += v.Y;
        }

        public void Rotate(double degrees)
        {
            double radian = degrees * Math.PI / 180;
            int oldX = x_;
            int oldY = y_;

            x_ = Convert.ToInt32(
                oldX * Math.Cos(radian) - oldY * Math.Sin(radian)
            );

            y_ = Convert.ToInt32(
                oldX * Math.Sin(radian) + oldY * Math.Cos(radian)
            );
        }
    }
}
