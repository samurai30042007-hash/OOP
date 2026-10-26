using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Storage
    {

        public Storage()
        {
            _circles = new List<Circle>();
        }
        public Storage(List<Circle> circles)
        {
            _circles = new(circles);
        }
        public void AddCircle(int radius, int x, int y)
        {
            _circles.Add(new Circle(x, y, radius));
        }
        public bool SelectCircle(int x, int y, bool isPressCtrl)
        {
            bool isCircleFound = false;
            if (!isPressCtrl)
            {
                foreach (var circle in _circles)
                {
                    circle.ChangeSelect(false);
                }
            }
            for (int i = _circles.Count - 1; i >= 0; i--)
            {
                var circle = _circles[i]

                if (circle.IsInside(x, y))
                {
                    isCircleFound = true;
                    circle.ChangeSelect();
                    break;
                }
            }
            return isCircleFound;
        }
        public void RemoveSelectedCircles()
        {
            _circles.RemoveAll(circle => circle.IsSelect);
        }
        public void DrawAll(Graphics graphics)
        {
            foreach (var circle in _circles)
            {
                circle.Draw(graphics);
            }
        }

        private List<Circle> _circles;
    }
}
