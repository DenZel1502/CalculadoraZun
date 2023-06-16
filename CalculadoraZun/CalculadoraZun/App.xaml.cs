using CalculadoraZun.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraZun
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new calculadora();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
