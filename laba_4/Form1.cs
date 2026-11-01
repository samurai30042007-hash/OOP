namespace laba_3._1
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool isCircleFound = _storage.SelectCircle(e.X, e.Y, Control.ModifierKeys == Keys.Control);
                if (!isCircleFound)
                {
                    _storage.AddCircle(50, e.X, e.Y);
                }
            }
            Invalidate();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) 
            {
                _storage.RemoveSelectedCircles();
                Invalidate();
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _storage.DrawAll(e.Graphics);
        }
    }
}
