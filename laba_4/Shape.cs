using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public abstract class Shape
    {
        public bool IsSelect { get; protected set; }
        virtual public void ChangeSelect(bool isSelect)
        {
            IsSelect = isSelect;
        }
        virtual public void ChangeSelect()
        {
            IsSelect = !IsSelect;
        }
        abstract public bool IsInside(int x, int y);
        abstract public void Draw(Graphics graphics);
        abstract public void Move (int dx, int dy);



    }
}
