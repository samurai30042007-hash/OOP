using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public abstract class Shape
    {
        public bool IsSelect { get; protected set; }
        virtual public string WhoAmI()
        {
            return this.GetType().Name;
        }
        abstract public void ChangeSelect(bool isSelect);
        abstract public void ChangeSelect();
        abstract public bool IsInside(int x, int y);
        abstract public void Draw(Graphics graphics);


    }
}
