using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Deserelisator
    {
        private Rigestry _rigestry;
        private string[] _lines;
        private int _currentLineIndex = 1;

        public Deserelisator(string text, Rigestry registry)
        {
            _lines = text.Split("\r\n");
            _rigestry = registry;
        }
        public List<Shape> Deserialize()
        {
            List<Shape> shapes = new();
            int count = int.TryParse(_lines[0], out count) ? count : throw new InvalidOperationException("Invalid file format");

            for (int i = 0; i < count; i++)
            {
                string[] line = _lines[_currentLineIndex].Split(' ');
                _currentLineIndex++;
                if (line[0] == "GROUP")
                {
                    int groupCount = int.TryParse(line[1], out groupCount) ? groupCount : throw new InvalidOperationException("Invalid file format");
                    var groupShapes = DeserializeGroup(groupCount);
                    Group group = new Group();
                    foreach (var shape in groupShapes)
                    {
                        group.AddShape(shape);
                    }
                    shapes.Add(group);
                }
                else
                {
                    Shape? shape = _rigestry.CreateShape(line);
                    if (shape != null)
                    {
                        shape.ShapeColor = Color.FromArgb(int.Parse(line[^1]));
                        shapes.Add(shape);
                    }
                }
            }

            return shapes;
        }
        private List<Shape> DeserializeGroup(int count)
        {
            List<Shape> shapes = new();
            for (int i = 0; i < count; i++)
            {
                string[] line = _lines[_currentLineIndex].Split(' ');
                _currentLineIndex++;
                if (line[0] == "GROUP")
                {
                    int groupCount = int.TryParse(line[1], out groupCount) ? groupCount : throw new InvalidOperationException("Invalid file format");
                    var groupShapes = DeserializeGroup(groupCount);
                    Group group = new Group();
                    foreach (var shape in groupShapes)
                    {
                        group.AddShape(shape);
                    }
                    shapes.Add(group);
                }
                else
                {
                    Shape? shape = _rigestry.CreateShape(line);
                    if (shape != null)
                    {
                        shape.ShapeColor = Color.FromArgb(int.Parse(line[^1]));
                        shapes.Add(shape);
                    }
                }
            }
            return shapes;
        }
    }
}
    /*
    3
    CIRCLE 100 100 25 -16777216
    GROUP 2
    RECTANGLE 150 150 50 30 -65536
    GROUP 1
    TRIANGLE 200 200 40 -16776961
    CIRCLE 300 300 25 -16777216
     
     */