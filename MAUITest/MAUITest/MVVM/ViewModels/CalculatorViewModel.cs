using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MAUITest.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        //public string Number1 { get; set; }
        //public string Number2 { get; set; }
        //public string Result { get; set; }

        //public string Total { get; set; }


        //public ICommand AddCommand => new Command(() => Result = Number1 + Number2);

        //public ICommand CommandNumber1 => new Command(() => Result += "1");
        //public ICommand CommandNumber2 => new Command(() => Result += "2");

        //public ICommand CommandNumber3 => new Command(() => Result += "2");

        private string _display;
        private double _operand1;
        private double _operand2;
        private string _currentOperator;
        private string _result;
        private bool _hasPerformedOperation;

        public ICommand AppendDigitCommand { get; }
        public ICommand ClearCommand { get; }

        public ICommand SetOperatorCommand { get; }
        public ICommand EqualsCommand { get; }
        public ICommand DeleteCommand { get; }

        public string Display
        {
            get => _display;
            set
            {
                if (_display != value)
                {
                    _display = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Operand1
        {
            get => _operand1;
            set
            {
                if (_operand1 != value)
                {
                    _operand1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Operand2
        {
            get => _operand2;
            set
            {
                if (_operand2 != value)
                {
                    _operand2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrentOperator
        {
            get => _currentOperator;
            set
            {
                if (_currentOperator != value)
                {
                    _currentOperator = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool HasPerformedOperation
        {
            get => _hasPerformedOperation;
            set
            {
                if (_hasPerformedOperation != value)
                {
                    _hasPerformedOperation = value;
                    OnPropertyChanged();
                }
            }
        }

        public CalculatorViewModel()
        {
            Display = "0";

            AppendDigitCommand = new Command<string>(AppendDigit);
            ClearCommand = new Command(Clear);
            SetOperatorCommand = new Command<string>(SetOperator);
            EqualsCommand = new Command(PerformOperation);
            DeleteCommand = new Command(DeleteLastDigit);
        }

        public void AppendDigit(string digit)
        {
            if (CurrentOperator == null)
            {
                Operand1 = double.Parse(Display + digit);
                Display = Operand1.ToString();
            }
            else
            {
                Operand2 = double.Parse(Display + digit);
                Display = Operand2.ToString();
            }

            if (HasPerformedOperation)
            {
                Display = digit;
                HasPerformedOperation = false;
            }
            else
            {
                if (digit == ".")
                {
                    if (!Display.Contains("."))
                    {
                        Display += digit;
                    }
                }
            }
        }

        public void SetOperator(string op)
        {
            CurrentOperator = op;

            if (!string.IsNullOrEmpty(CurrentOperator) && Operand2 != 0)
            {
                Calculate();
            }

            CurrentOperator = op;
            Display = "0";
        }

        public void Calculate()
        {
            double result = 0;

            switch (CurrentOperator)
            {
                case "+":
                    result = Operand1 + Operand2;
                    break;
                case "-":
                    result = Operand1 - Operand2;
                    break;
                case "*":
                    result = Operand1 * Operand2;
                    break;
                case "/":
                    result = Operand1 / Operand2;
                    break;
                case "%":
                    result = Operand1 % Operand2;
                    break;
            }

            string operation = $"{Operand1} {CurrentOperator} {Operand2} = {result}";
            //Result += operation + Environment.NewLine;
            Result = operation;
            Operand1 = result;
            Operand2 = 0;
            Display = result.ToString();
            
            HasPerformedOperation = true;
        }

        public void Clear()
        {
            Display = "0";
            Result = "0";
            Operand1 = 0;
            Operand2 = 0;
            CurrentOperator = null;
        }

        public void PerformOperation()
        {
            if (HasPerformedOperation)
            {
                Operand2 = double.Parse(Display);
                HasPerformedOperation = false;
            }

            Calculate();
        }

        public void DeleteLastDigit()
        {
            if (Display.Length > 1)
            {
                Display = Display.Substring(0, Display.Length - 1);
            }
            else
            {
                Display = "0";
            }
            if (Operand1 != 0)
            {
                Operand1 = double.Parse(Display);
            }
            if (Operand2 != 0)
            {
                Operand2 = double.Parse(Display);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
