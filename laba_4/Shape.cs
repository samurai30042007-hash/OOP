using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public abstract class Shape
    {
        public bool IsSelect { get; protected set; }
        public abstract RectangleF Bounds { get; }
        protected int PosX;
        protected int PosY;
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
        virtual public void Move (int dx, int dy)
        {
            PosX += dx;
            PosY += dy;
        }
        public bool CanMove(int dx, int dy, RectangleF workArea)
        {
            RectangleF futureBounds = this.Bounds;
            futureBounds.Offset(dx, dy);
            return workArea.Contains(futureBounds);
        }

    }
}
