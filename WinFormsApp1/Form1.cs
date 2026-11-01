namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly Num _numbers = new();
        private bool _isUpdatingView = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Model_NumChanged(object? sender, EventArgs e)
        {
            //UpdateView();
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
