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
        public void AddCircle(Shape shape)
        {
            switch (shape.WhoAmI())
            {
                case "Circle":
                    _shapes.Add(shape);
                    break;
                default:
                    break;
            }
        }
        public bool SelectShape(int x, int y, bool isPressCtrl)
        {
            bool isCircleFound = false;
            if (!isPressCtrl)
            {
                foreach (var circle in _shapes)
                {
                    circle.ChangeSelect(false);
                }
            }
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                var circle = _shapes[i];

                if (circle.IsInside(x, y))
                {
                    isCircleFound = true;
                    circle.ChangeSelect();
                    break;
                }
            }
            return isCircleFound;
        }
        public void RemoveSelectedShapes()
        {
            _shapes.RemoveAll(circle => circle.IsSelect);
        }
        public void DrawAll(Graphics graphics)
        {
            foreach (var circle in _shapes)
            {
                circle.Draw(graphics);
            }
        }

        private List<Shape> _shapes;
    }
}
