using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Group : Shape
    {
        public Group()
        {
            _shapes = new();
        }
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }
        public override RectangleF Bounds
        {
            get
            {
                if (_shapes.Count == 0)
                    return RectangleF.Empty;
                float minX = float.MaxValue;
                float minY = float.MaxValue;
                float maxX = float.MinValue;
                float maxY = float.MinValue;
                foreach (var shape in _shapes)
                {
                    var bounds = shape.Bounds;
                    minX = Math.Min(minX, bounds.Left);
                    minY = Math.Min(minY, bounds.Top);
                    maxX = Math.Max(maxX, bounds.Right);
                    maxY = Math.Max(maxY, bounds.Bottom);
                }
                return new RectangleF(minX, minY, maxX - minX, maxY - minY);
            }
        }
        public override void Move(int dx, int dy)
        {
            foreach (var shape in _shapes)
            {
                shape.Move(dx, dy);
            }
        }
        public override void Resize(int delta)
        {
            foreach (var shape in _shapes)
            {
                shape.Resize(delta);
            }
        }
        public override bool IsInside(int x, int y)
        {
            foreach (var shape in _shapes)
            {
                if (shape.IsInside(x, y))
                {
                    return true;
                }
            }
            return false;
        }
        public override void Draw(Graphics graphics)
        {
            foreach (var shape in _shapes)
            {
                shape.ShapeColor = this.ShapeColor;
                shape.Draw(graphics);
            }
        }
        private List<Shape> _shapes;
    }
}
