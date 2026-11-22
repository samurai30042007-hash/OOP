using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class FabricCircle : IFabric
    {
        public Shape CreateShape(string[] options)
        {
            int posX = int.Parse(options[1]);
            int posY = int.Parse(options[2]);
            int radius = int.Parse(options[3]);
            return new Circle(posX, posY, radius);
        }
    }
    public class FabricRectangle : IFabric
    {

        public Shape CreateShape(string[] options)
        {
            int posX = int.Parse(options[1]);
            int posY = int.Parse(options[2]);
            int width = int.Parse(options[3]);
            int height = int.Parse(options[4]);
            return new Rectangle(posX, posY, width, height);
        }
    }
    public class FabricTriangle : IFabric
    {
        public Shape CreateShape(string[] options)
        {
            int posX = int.Parse(options[1]);
            int posY = int.Parse(options[2]);
            int size = int.Parse(options[3]);
            return new Triangle(posX, posY, size);
        }
    }
}
