using System.ComponentModel;
using LCARS.Interfaces.Tricorder.ViewModels;
using Xamarin.Forms;

namespace LCARS.Interfaces.Tricorder.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}