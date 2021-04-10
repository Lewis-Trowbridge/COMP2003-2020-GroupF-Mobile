using System;
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
           // await ((Shell)Application.Current.MainPage).GoToAsync($"//Homepage/VenuePage/BookingPage");
            await Navigation.PushAsync(new BookingPage());
        }
        async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}