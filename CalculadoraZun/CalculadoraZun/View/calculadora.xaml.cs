using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraZun.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class calculadora : ContentPage
    {
        public calculadora()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.ViewModelcalculadora();
        }
    }
}