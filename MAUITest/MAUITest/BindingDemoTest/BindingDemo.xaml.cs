using Android.App;
using Microsoft.Maui.Controls;

namespace MAUITest.BindingDemoTest;

public partial class BindingDemo : ContentPage
{
	public BindingDemo()
	{
		InitializeComponent();
	}

	private void btnOK_Clicked(object sender, EventArgs e)
	{
		var calculadora = new calculadora
		{
			num1 = 1,
			num2 = 2,
		};
		BindingContext = calculadora;
		//lblName.SetBinding(Label.TextProperty, "num1");

		//var calculadoraBinding = new Binding();
		//calculadoraBinding.Source= calculadora;
		//calculadoraBinding.Path = "num1";

		//lblName.SetBinding(Label.TextProperty, calculadoraBinding);	
	}
}