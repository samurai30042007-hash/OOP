using System.Drawing.Text;

namespace laba_3._1
{
    public class Circle : Shape
    {
        private int _radius;
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
        public Circle(Circle circle)
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



    }
    public class Rectangle : Shape
    {
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

    }

public class Triangle : Shape
    {
        private int lenght;

        public Triangle(int x, int y, int length)
        {
            PosX = x;
            PosY = y;
            lenght = length;
        }

        public Triangle(Triangle triangle)
        {
            PosX = triangle.PosX;
            PosY = triangle.PosY;
            lenght = triangle.lenght;
            IsSelect = triangle.IsSelect;
        }

        private PointF[] GetVertices()
        {
            float height = (float)(lenght * Math.Sqrt(3) / 2);

            PointF[] points = new PointF[3];
            points[0] = new PointF(PosX, PosY);
            points[1] = new PointF(PosX - lenght / 2f, PosY + height);
            points[2] = new PointF(PosX + lenght / 2f, PosY + height);

            return points;
        }

        public override bool IsInside(int x, int y)
        {
            PointF[] vertices = GetVertices();
            PointF A = vertices[0];
            PointF B = vertices[1];
            PointF C = vertices[2];

            double d1 = Sign(x, y, A.X, A.Y, B.X, B.Y);
            double d2 = Sign(x, y, B.X, B.Y, C.X, C.Y);
            double d3 = Sign(x, y, C.X, C.Y, A.X, A.Y);

            bool has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }

        private double Sign(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return (x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3);
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = IsSelect ? Pens.Blue : Pens.Black;
            PointF[] vertices = GetVertices();
            graphics.DrawPolygon(pen, vertices);
        }
    }

}
