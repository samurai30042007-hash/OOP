namespace laba_3._1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage();
        private const int MoveStep= 10;
        private const int ResizeStep = 5;
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
                    _storage.AddShape(new Rectangle(e.X, e.Y, 25,25));
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
                    _storage.ResizeSelectedShapes(-ResizeStep, this.ClientRectangle);
                    break;
                case Keys.E:
                    _storage.ResizeSelectedShapes(ResizeStep, this.ClientRectangle);
                    break;


            }
            Invalidate();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _storage.DrawAll(e.Graphics);
        }
    }
}
