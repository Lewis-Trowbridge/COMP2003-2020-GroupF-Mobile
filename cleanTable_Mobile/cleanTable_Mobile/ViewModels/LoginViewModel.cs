using cleanTable_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public string EnteredId { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            Title = "Login";
        }

        private async void OnLoginClicked(object obj)
        {
            CustomerId = Convert.ToInt32(EnteredId);
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
        }
    }
}
