using System;
using System.Collections.Generic;
using LCARS.Interfaces.Tricorder.ViewModels;
using LCARS.Interfaces.Tricorder.Views;
using Xamarin.Forms;

namespace LCARS.Interfaces.Tricorder
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
