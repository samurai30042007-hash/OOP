namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly Num _numbers = new();
        

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
            UpdateView();
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
            catch(InvalidDataException)
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
