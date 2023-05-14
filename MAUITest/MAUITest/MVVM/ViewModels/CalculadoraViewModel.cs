using MAUITest.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITest.MVVM.ViewModels
{
    public class CalculadoraViewModel
    {
        public CalculadoraViewModel()
        {
            Calculadora = new()
            {
                num1= 1,
                num2= 2,
                num3= 3,
            };
        }

        public calculadora Calculadora { get; set; }
    }
}
