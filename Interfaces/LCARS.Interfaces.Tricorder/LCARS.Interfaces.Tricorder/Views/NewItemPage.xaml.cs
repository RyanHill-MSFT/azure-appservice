using System;
using System.Collections.Generic;
using System.ComponentModel;
using LCARS.Interfaces.Tricorder.Models;
using LCARS.Interfaces.Tricorder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCARS.Interfaces.Tricorder.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}