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
            await Navigation.PushAsync(new BookingPage());
        }
        async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}