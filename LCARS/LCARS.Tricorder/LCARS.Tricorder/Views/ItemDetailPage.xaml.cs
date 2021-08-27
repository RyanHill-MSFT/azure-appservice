using System.ComponentModel;
using LCARS.Tricorder.ViewModels;
using Xamarin.Forms;

namespace LCARS.Tricorder.Views
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