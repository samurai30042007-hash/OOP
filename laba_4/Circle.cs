using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Circle
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public bool IsSelect { get; private set; } = false;
        public int Radius
        {
            get { return _radius; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius cannot be negative.");
                }
                _radius = value;
            }
        }
        public Circle(int x, int y, int radius)
        {
            PosX = x;
            PosY = y;
            Radius = radius;
        }

        public void ChangeSelect()
        {
            IsSelect = !IsSelect;
        }
        public void ChangeSelect(bool isSelect)
        {
            IsSelect = isSelect;
        }

        public bool IsInside(int x, int y)
        {
            double distance = Math.Sqrt(Math.Pow(x - PosX, 2) + Math.Pow(y - PosY, 2));
            return distance <= Radius;
        }
        public void Draw(Graphics graphics)
        {
            if (IsSelect)
            {
                graphics.DrawEllipse(
                Pens.Blue,
                PosX - Radius,
                PosY - Radius,
                Radius * 2,
                Radius * 2
            );
            }
            else
            {
                graphics.DrawEllipse(
                    Pens.Black,
                    PosX - Radius,
                    PosY - Radius,
                    Radius * 2,
                    Radius * 2
                );
            }
        }

        private int _radius;

    }
}
