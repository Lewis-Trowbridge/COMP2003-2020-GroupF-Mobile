using cleanTable_Mobile.ViewModels;
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
    public partial class BookingPage : ContentPage
    {
        public BookingPage()
        {
            
            InitializeComponent();
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            value = Convert.ToInt32(value);
            displayLabel.Text = String.Format("Party Size: {0}",  value);
        }

        //async void ButtonClicked(object sender, EventArgs e)
        //{
        //   // await Navigation.PushAsync(new VenuePage());
        //    await Shell.Current.GoToAsync("//VenuePage");
        //    //Shell.Current.CurrentItem.CurrentItem.Items.Add(new VenuePage());
        //    //Shell.Current.CurrentItem.CurrentItem.Items.RemoveAt(0);
        //} 
        
         async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}