using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Storage
    {

        public Storage()
        {
            _shapes = new List<Shape>();
        }
        public Storage(List<Shape> circles)
        {
            _shapes = new(circles);
        }
        public void AddShape(Shape shape)
        {
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
        public void MoveSelectedShapes(int dx, int dy)
        {
            foreach (var shape in _shapes)
            {
                if (shape.IsSelect)
                {
                    shape.Move(dx, dy);
                }
            }
        }
        private List<Shape> _shapes;
    }
}
