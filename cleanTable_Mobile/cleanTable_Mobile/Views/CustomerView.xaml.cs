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
    public partial class CustomerView : ContentPage
    {
        public CustomerView(int CustomerId)
        {
            InitializeComponent();
            BindingContext = new CustomerPageViewModel();
        }

        async void ButtonEdit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerEdit());
        }

        async void ButtonCancel(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
        }
    }
}