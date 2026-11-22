using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public interface IFabric
    {
        public abstract Shape CreateShape(string[] options);
    }
}
