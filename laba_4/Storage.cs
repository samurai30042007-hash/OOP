using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Storage : Shape
    {

        public Storage()
        {
            _shapes = new();
        }
        public Storage(List<Shape> circles)
        {
            _shapes = new(circles);
        }
        public void AddShape(int choosenShape, RectangleF workArea, int X, int Y)
        {
            Shape? shape = null;
            switch (choosenShape)
            {
                case 0:
                    shape = new Circle(X, Y, 25);
                    break;
                case 1:
                    shape = new Rectangle(X, Y, 25, 30);
                    break;
                case 2:
                    shape = new Triangle(X, Y, 25);
                    break;
            }
            if (workArea.Contains(shape!.Bounds))
                _shapes.Add(shape);
        }
        public bool SelectShape(int x, int y, bool isPressCtrl)
        {
            bool isShapeFound = false;
            if (!isPressCtrl)
            {
                foreach (var shape in _shapes)
                {
                    shape.ChangeSelect(false);
                }
            }
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                var shape = _shapes[i];

                if (shape.IsInside(x, y))
                {
                    isShapeFound = true;
                    shape.ChangeSelect();
                    break;
                }
            }
            return isShapeFound;
        }
        public void RemoveSelectedShapes()
        {
            _shapes.RemoveAll(shape => shape.IsSelect);
        }
        public void DrawAll(Graphics graphics)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
        }
        public void MoveSelectedShapes(int dx, int dy, RectangleF workArea)
        {
            bool canMove = true;
            foreach (var shape in _shapes)
            {
                if (shape.IsSelect && (shape.CanMove(dx, dy, workArea) == false))
                {
                    canMove = false;
                    break;
                }

            }
            if (canMove)
            {


                foreach (var shape in _shapes)
                {
                    if (shape.IsSelect)
                    {
                        shape.Move(dx, dy);
                    }
                }
            }
        }
        public void ResizeSelectedShapes(int delta, RectangleF workArea)
        {
            bool canResize = true;
            foreach (var shape in _shapes)
            {
                if ( shape.CanResize(delta, workArea) == false)
                {
                    canResize = false;
                    break;
                }
            }
            if (canResize)
            {
                foreach (var shape in _shapes)
                {
                    if (shape.IsSelect)
                    {
                        shape.Resize(delta);
                    }
                }
            }
        }
        public void ChangeSelectedColor(Color color)
        {
            foreach (var shape in _shapes)
            {
                if (shape.IsSelect)
                {
                    shape.ShapeColor = color;
                }
            }
        }

        public override void Resize(int delta)
        {
            foreach (var shape in _shapes)
            {
                shape.Resize(delta);
            }
        }
        public override void Move(int dx, int dy)
        {
            foreach (var shape in _shapes)
            {
                shape.Move(dx, dy);
            }
        }
        public override void Draw(Graphics graphics)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
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
        public override RectangleF Bounds
        {
            get
            {
                if (_shapes.Count == 0)
                {
                    return RectangleF.Empty;
                }
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


        private List<Shape> _shapes;



    }
}
