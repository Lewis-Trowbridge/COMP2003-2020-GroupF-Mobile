using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cleanTable_Mobile.ViewModels;

namespace cleanTable_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingView : ContentPage
    {
        public BookingView(int bookingId)
        {
            InitializeComponent();
            BindingContext = new BookingPageViewModel(bookingId);
        }
        async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}