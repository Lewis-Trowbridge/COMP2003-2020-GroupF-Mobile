using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cleanTable_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VenuePage : ContentPage
    {
        public VenuePage()
        {
            InitializeComponent();

        }
        async void ButtonClicked(object sender, EventArgs e)
        {
            //  await Shell.Current.GoToAsync($"{nameof(BookingPage)}");
            await ((Shell)Application.Current.MainPage).GoToAsync($"//Homepage/VenuePage/BookingPage");
        }
        async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}