namespace laba_3._1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage();
        private const int MoveStep = 10;
        private const int ResizeStep = 10;
        private int _choosenShape = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool isCircleFound = _storage.SelectShape(e.X, e.Y, Control.ModifierKeys == Keys.Control);
                if (!isCircleFound)
                {
                    _storage.AddShape(_choosenShape, this.ClientRectangle, e.X, e.Y);
                }
            }
            Invalidate();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _storage.MoveSelectedShapes(-MoveStep, 0, this.ClientRectangle);
                    break;
                case Keys.Right:
                    _storage.MoveSelectedShapes(MoveStep, 0, this.ClientRectangle);
                    break;
                case Keys.Up:
                    _storage.MoveSelectedShapes(0, -MoveStep, this.ClientRectangle);
                    break;
                case Keys.Down:
                    _storage.MoveSelectedShapes(0, MoveStep, this.ClientRectangle);
                    break;
                case Keys.Delete:
                    _storage.RemoveSelectedShapes();
                    break;
                case Keys.Q:
                    try
                    {
                        _storage.ResizeSelectedShapes(-ResizeStep, this.ClientRectangle);
                    }
                    catch
                    {
                        MessageBox.Show("НЕльзя уменьшить число отрицательное");
                    }
                    break;
                case Keys.E:
                    try
                    {
                        _storage.ResizeSelectedShapes(ResizeStep, this.ClientRectangle);
                    }
                    catch
                    {
                        MessageBox.Show("НЕльзя уменьшить число отрицательное");
                    }
                    break;
                case Keys.NumPad1:
                    _choosenShape = 0;
                    break;
                case Keys.NumPad2:
                    _choosenShape = 1;
                    break;
                case Keys.NumPad3:
                    _choosenShape = 2;
                    break;
                case Keys.C:
                    {
                        ColorDialog dialog = new ColorDialog();

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            _storage.ChangeSelectedColor(dialog.Color);
                            Invalidate();
                        }
                        break;
                    }


            }
            Invalidate();

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _storage.DrawAll(e.Graphics);
        }

        private void кРУГToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _choosenShape = 0;
        }

        private void пРЯМОУГОЛЬНИКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _choosenShape = 1;
        }

        private void тРЕУГОЛЬНИКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _choosenShape = 2;
        }
    }
}
