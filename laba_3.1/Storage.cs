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
            bool IsSelect = false;
            if (!isPressCtrl)
            {
                foreach (var circle in _circles)
                {
                    circle.ChangeSelect(false);
                }
            }
            foreach (var circle in _circles)
            {
                IsSelect = circle.IsInside(x, y);
                if (IsSelect)
                {
                    circle.ChangeSelect();
                    break;
                }
            }
            return IsSelect;
        }
        public void RemoveSelectedCircles()
        {
            _circles.RemoveAll(circle => circle.IsSelect);
        }


        private List<Circle> _circles;
    }
}
