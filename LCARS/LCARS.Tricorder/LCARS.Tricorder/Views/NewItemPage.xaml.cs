using System;
using System.Collections.Generic;
using System.ComponentModel;
using LCARS.Tricorder.Models;
using LCARS.Tricorder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCARS.Tricorder.Views
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