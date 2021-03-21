using System;
using LCARS.Interfaces.Tricorder.Services;
using LCARS.Interfaces.Tricorder.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCARS.Interfaces.Tricorder
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
