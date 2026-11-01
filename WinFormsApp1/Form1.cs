namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly Num _numbers = new();
        private bool isUpdating = false;


        public Form1()
        {
            InitializeComponent();
            _numbers.NumChanged += Model_NumChanged;
            trackBar1.Minimum = Num.MinValue;
            trackBar1.Maximum = Num.MaxValue;
            trackBar2.Minimum = Num.MinValue;
            trackBar2.Maximum = Num.MaxValue;
            trackBar3.Minimum = Num.MinValue;
            trackBar3.Maximum = Num.MaxValue;
        }

        private void Model_NumChanged(object? sender, EventArgs e)
        {
            isUpdating = true;
            try
            {
                UpdateView();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateView();
                isUpdating = false;
            }
        }
        private void UpdateView()
        {
            numericUpDown3.Value = _numbers.NumC;
            textBox3.Text = _numbers.NumC.ToString();
            trackBar3.Value = _numbers.NumC;
            textBox2.Text = _numbers.NumB.ToString();
            trackBar2.Value = _numbers.NumB;
            numericUpDown2.Value = _numbers.NumB;
            textBox1.Text = _numbers.NumA.ToString();
            trackBar1.Value = _numbers.NumA;
            numericUpDown1.Value = _numbers.NumA;
        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (isUpdating)
            {
                return;
            }

            if (sender is not TrackBar trackBar)
            {
                return;
            }
            try
            {
                switch (trackBar.Name)
                {
                    case "trackBar1":
                        _numbers.NumA = trackBar.Value;
                        break;
                    case "trackBar2":
                        _numbers.NumB = trackBar.Value;
                        break;
                    case "trackBar3":
                        _numbers.NumC = trackBar.Value;
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateView();
            }
        }
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating)
            {
                return;
            }
            if (sender is not NumericUpDown numericUpDown)
            {
                return;
            }
            try
            {
                switch (numericUpDown.Name)
                {
                    case "numericUpDown1":
                        _numbers.NumA = (int)numericUpDown.Value;
                        break;
                    case "numericUpDown2":
                        _numbers.NumB = (int)numericUpDown.Value;
                        break;
                    case "numericUpDown3":
                        _numbers.NumC = (int)numericUpDown.Value;
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateView();
            }
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            if (isUpdating)
            {
                return;
            }
            if (sender is not TextBox textBox)
            {
                return;
            }
            if (!int.TryParse(textBox.Text, out int value))
            {
                MessageBox.Show("Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateView();
                return;
            }
            try
            {switch (textBox.Name)
                {
                    case "textBox1":
                        _numbers.NumA = value;
                        break;
                    case "textBox2":
                            _numbers.NumB = value;
                        break;
                    case "textBox3":
                        _numbers.NumC = value;
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateView();
            }
        }
        private async void Save_Click(object sender, EventArgs e)
        {
            await _numbers.SaveData();
        }

        private async void Load_Click(object sender, EventArgs e)
        {
            try
            {
                await _numbers.LoadData();

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Data file is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Data file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Data file is corrupted or contains invalid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
