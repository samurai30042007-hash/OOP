using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Circle : Shape
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
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
        public Circle (Circle circle)
        {
            PosX = circle.PosX;
            PosY = circle.PosY;
            Radius = circle.Radius;
            IsSelect = circle.IsSelect;
        }

        public override void ChangeSelect()
        {
            IsSelect = !IsSelect;
        }
        public override void ChangeSelect(bool isSelect)
        {
            IsSelect = isSelect;
        }

        public override bool IsInside(int x, int y)
        {
            double distance = Math.Sqrt(Math.Pow(x - PosX, 2) + Math.Pow(y - PosY, 2));
            return distance <= Radius;
        }
        public override void Draw(Graphics graphics)
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
    public class Rectangle : Shape
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle(int x, int y, int width, int height)
        {
            PosX = x;
            PosY = y;
            Width = width;
            Height = height;
        }
        public Rectangle(Rectangle rectangle)
        {
            PosX = rectangle.PosX;
            PosY = rectangle.PosY;
            Width = rectangle.Width;
            Height = rectangle.Height;
            IsSelect = rectangle.IsSelect;
        }
        public override void ChangeSelect()
        {
            IsSelect = !IsSelect;
        }
        public override void ChangeSelect(bool isSelect)
        {
            IsSelect = isSelect;
        }
        public override bool IsInside(int x, int y)
        {
            return x >= PosX && x <= PosX + Width && y >= PosY && y <= PosY + Height;
        }
        public override void Draw(Graphics graphics)
        {
            if (IsSelect)
            {
                graphics.DrawRectangle(
                    Pens.Blue,
                    PosX,
                    PosY,
                    Width,
                    Height
                );
            }
            else
            {
                graphics.DrawRectangle(
                    Pens.Black,
                    PosX,
                    PosY,
                    Width,
                    Height
                );
            }
        }
    }   
}
