using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Circle
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Radius { get; private set; }

        public bool IsSelect { get; private set; } = false;

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


    }
}
