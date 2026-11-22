using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class FabricCircle : IFabric
    {
        public Shape CreateShape(string[] options)
        {
            int posX = int.Parse(options[2]);
            int posY = int.Parse(options[3]);
            int radius = int.Parse(options[1]);
            return new Circle(posX, posY, radius);
        }
    }
    /*TRIANGLE 510 190 30 -16777216
CIRCLE 433 283 45 -16777216
RECTANGLE 378 337 45 70 -16777216*/
    public class FabricRectangle : IFabric
    {

        public Shape CreateShape(string[] options)
        {
            int posX = int.Parse(options[3]);
            int posY = int.Parse(options[4]);
            int width = int.Parse(options[1]);
            int height = int.Parse(options[2]);
            return new Rectangle(posX, posY, width, height);
        }
    }
    public class FabricTriangle : IFabric
    {
        public Shape CreateShape(string[] options)
        {
            int posX = int.Parse(options[2]);
            int posY = int.Parse(options[3]);
            int size = int.Parse(options[1]);
            return new Triangle(posX, posY, size);
        }
    }
}
