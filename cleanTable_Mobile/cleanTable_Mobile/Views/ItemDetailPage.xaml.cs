using System.ComponentModel;
using Xamarin.Forms;
using cleanTable_Mobile.ViewModels;

namespace cleanTable_Mobile.Views
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