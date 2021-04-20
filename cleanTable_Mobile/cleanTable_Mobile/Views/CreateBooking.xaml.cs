using cleanTable_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cleanTable_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        public BookingPage(int VenueId)
        {
            InitializeComponent();
            BindingContext = new CreateBookingViewModel(VenueId);
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            value = Convert.ToInt32(value);
            displayLabel.Text = String.Format("Party Size: {0}", value);
        }
       
        

         async void ButtonCancel(object sender, EventArgs e)
         {
             await Navigation.PopToRootAsync();
         }
    }
}