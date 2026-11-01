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
        public override void Move(int dx, int dy)
        {
            PosX += dx;
            PosY += dy;
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
        public override void Move(int dx, int dy)
        {
            PosX += dx;
            PosY += dy;
        }
    }   
    public class Triangle : Shape
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }
        public Point Point3 { get; private set; }
        public Triangle(Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }
        public Triangle(Triangle triangle)
        {
            Point1 = triangle.Point1;
            Point2 = triangle.Point2;
            Point3 = triangle.Point3;
            IsSelect = triangle.IsSelect;
        }
        public override bool IsInside(int x, int y)
        {
            // Use barycentric coordinates to check if the point is inside the triangle
            float denominator = ((Point2.Y - Point3.Y) * (Point1.X - Point3.X) + (Point3.X - Point2.X) * (Point1.Y - Point3.Y));
            float a = ((Point2.Y - Point3.Y) * (x - Point3.X) + (Point3.X - Point2.X) * (y - Point3.Y)) / denominator;
            float b = ((Point3.Y - Point1.Y) * (x - Point3.X) + (Point1.X - Point3.X) * (y - Point3.Y)) / denominator;
            float c = 1 - a - b;
            return a >= 0 && b >= 0 && c >= 0;
        }
        public override void Draw(Graphics graphics)
        {
            Pen pen = IsSelect ? Pens.Blue : Pens.Black;
            graphics.DrawPolygon(pen, new[] { Point1, Point2, Point3 });
        }
        public override void Move(int dx, int dy)
        {
            Point1 = new Point(Point1.X + dx, Point1.Y + dy);
            Point2 = new Point(Point2.X + dx, Point2.Y + dy);
            Point3 = new Point(Point3.X + dx, Point3.Y + dy);
        }
    }
}
