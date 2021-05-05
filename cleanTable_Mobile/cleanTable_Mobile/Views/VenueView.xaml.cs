using cleanTable_Mobile.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cleanTable_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VenueView : ContentPage
    {
        
        public VenueView(int VenueId)
        { 
            InitializeComponent();
            BindingContext = new VenuePageViewModel(VenueId);
            
        }

        async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}