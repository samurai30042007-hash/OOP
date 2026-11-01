namespace WinFormsApp1
{
    internal class Num
    {
        private int _numA = 0 ;
        private int _numB = 0;
        private int _numC = 0;
        public const int MinValue  = 0;
        public const int MaxValue  = 100;
        public event EventHandler? NumChanged;
        public int NumA
        {
            get { return _numA; }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Value big or small");
                }
                if (value == _numA)
                {
                    return;
                }
                if (value > _numC)
                {
                    _numC = value;
                    _numB = value;
                    _numA = value;
                }
                else if (value > _numB)
                {
                    _numB = value;
                    _numA = value;
                }
                else
                {
                    _numA = value;
                }
                NumChanged?.Invoke(this, EventArgs.Empty);


            }
        }
        public int NumB
        {
            get { return _numB; }
            set
            {
                if (value == _numB)
                {
                    return;
                }
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Value big or small");
                }
                if (!(value >= _numA && value <= _numC))
                {
                    throw new ArgumentException("NumB must be between NumA and NumC.");
                }
                _numB = value;
                NumChanged?.Invoke(this, EventArgs.Empty); 
            }
        }
        public int NumC
        {
            get { return _numC; }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Value big or small");
                }
                if (value == _numC)
                {
                    return;
                }
                if (value < _numA)
                {
                    _numA = value;
                    _numB = value;
                    _numC = value;
                }
                else if (value < _numB)
                {
                    _numB = value;
                    _numC = value;
                }
                else
                {  
                    _numC = value;
                }
                NumChanged?.Invoke(this, EventArgs.Empty);

            }
        }
        public async Task LoadData()
        {
            using var stream =  File.OpenRead("data.txt");
            using var reader = new StreamReader(stream);
            var line = await reader.ReadLineAsync();
            if (line is null)
            {
               throw new InvalidOperationException("Data file is empty.");
            }
            var parts = line.Split(',');
            if (parts.Length == 3 && int.TryParse(parts[0], out int a) && int.TryParse(parts[1], out int b) && int.TryParse(parts[2], out int c) &&
                (MinValue <= a && a <= b && b <= c && c <= MaxValue))
            {
                _numA = a;
                _numB = b;
                _numC = c;
            }
            else
               throw new InvalidDataException("Data file is corrupted or contains invalid values.");
        }
        public async Task SaveData()
        {
            using var stream = File.Create("data.txt");
            using var writer = new StreamWriter(stream);
            await writer.WriteLineAsync($"{_numA},{_numB},{_numC}");
        }
    }
}
