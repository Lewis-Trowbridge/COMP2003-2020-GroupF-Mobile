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
    public partial class BookingEdit : ContentPage
    {
        public BookingEdit(int venueId, int bookingId)
        {
            InitializeComponent();
            BindingContext = new EditBookingViewModel(venueId,bookingId);
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