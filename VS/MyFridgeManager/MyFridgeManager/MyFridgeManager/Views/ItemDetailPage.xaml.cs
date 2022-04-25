using MyFridgeManager.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyFridgeManager.Views
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