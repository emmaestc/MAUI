using PropertyChanged;
using System.Windows.Input;

namespace MAUITest.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }

        public ICommand AddCommand => new Command(() => Result = Number1 + Number2);
    }
}
