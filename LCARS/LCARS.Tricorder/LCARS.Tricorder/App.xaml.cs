using System;
using LCARS.Tricorder.Services;
using LCARS.Tricorder.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCARS.Tricorder
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
