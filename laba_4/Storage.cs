using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Storage
    {
        Rigestry _rigestry;
        public Storage(Rigestry rigestry)
        {
            _rigestry = rigestry;
            _shapes = new();
        }
        public Storage(List<Shape> circles, Rigestry rigestry)
        {
            _shapes = new(circles);
            _rigestry = rigestry;
        }
        
        public void AddShape(string[] choosenShapeOptions, RectangleF workArea)
        {
            Shape? shape = _rigestry.CreateShape(choosenShapeOptions);
            
            if(shape is not null && workArea.Contains(shape!.Bounds))
                _shapes.Add(shape);
        }
        public bool SelectShape(int x, int y, bool isPressCtrl)
        {
            bool isShapeFound = false;
            if (!isPressCtrl)
            {
                foreach (var shape in _shapes)
                {
                    shape.ChangeSelect(false);
                }
            }
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                var shape = _shapes[i];

                if (shape.IsInside(x, y))
                {
                    isShapeFound = true;
                    shape.ChangeSelect();
                    break;
                }
            }
            return isShapeFound;
        }
        public void RemoveSelectedShapes()
        {
            _shapes.RemoveAll(shape => shape.IsSelect);
        }
        public void DrawAll(Graphics graphics)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
        }
        public void MoveSelectedShapes(int dx, int dy, RectangleF workArea)
        {
            bool canMove = true;
            foreach (var shape in _shapes)
            {
                if (shape.IsSelect && (shape.CanMove(dx, dy, workArea) == false))
                {
                    canMove = false;
                    break;
                }
                
            }
            if (canMove)
            {


                foreach (var shape in _shapes)
                {
                    if (shape.IsSelect)
                    {
                        shape.Move(dx, dy);
                    }
                }
            }
        }
        public void ResizeSelectedShapes(int delta, RectangleF workArea)
        {
            bool canResize = true;
            foreach (var shape in _shapes)
            {
                if (shape.IsSelect && (shape.CanResize(delta, workArea) == false))
                {
                    canResize = false;
                    break;
                }
            }
            if (canResize)
            {
                foreach (var shape in _shapes)
                {
                    if (shape.IsSelect)
                    {
                        shape.Resize(delta);
                    }
                }
            }
        }
        public void ChangeSelectedColor(Color color)
        {
            foreach (var shape in _shapes)
            {
                if (shape.IsSelect)
                {
                    shape.ShapeColor = color;
                }
            }
        }

        public void MakeGroup()
        {
            List<Shape> selectedShapes = _shapes.FindAll(shape => shape.IsSelect);
            if (selectedShapes.Count > 1)
            {
                Group group = new();
                foreach (var shape in selectedShapes)
                {
                    group.AddShape(shape);
                }
                group.ChangeSelect(true);
                _shapes.RemoveAll(shape => shape.IsSelect);
                _shapes.Add(group);
            }
        }

        public void UnGroupe()
        {
            List<Group> groups = _shapes.OfType<Group>().Where(g => g.IsSelect).ToList();
            foreach (var group in groups)
            {
                group.ChangeSelect(false);
                foreach (var shape in group.Shapes)
                {
                    _shapes.Add(shape);
                }
            }

            _shapes.RemoveAll(shape => groups.Contains(shape));
        }
        public string Serialize()
        {
            string serializedData = _shapes.Count.ToString() + "\r\n";

            foreach (var shape in _shapes)
            {
                serializedData += shape.Serialize();
            }

            return serializedData;
        }
        private List<Shape> _shapes;    
    }
}
