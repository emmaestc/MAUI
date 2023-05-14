using MAUITest.MVVM.ViewModels;

namespace MAUITest.MVVM.Views;

public partial class CalculadoraView : ContentPage
{
    public CalculadoraView()
    {
        InitializeComponent();
        BindingContext = new CalculadoraViewModel();
    }
}