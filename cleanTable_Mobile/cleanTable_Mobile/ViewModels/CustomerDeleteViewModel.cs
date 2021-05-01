using cleanTable_Mobile.Models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class CustomerDeleteViewModel : BaseViewModel
    {
        private HttpClient _client;
        private string _deleteCheck;
        private int _customerID;
        public CustomerDeleteViewModel()
        {
            Title = "Delete Customer";
            _client = new HttpClient();
            _customerID = 90; //will be changed when account is logged in/created

            DeleteAccount = new Command(async () =>
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Question?", "Are you sure?" ,
                "Confirm", "Cancel");
                if (answer == true)
                {
                    DeleteCustomer(_customerID);
                }
                else
                {
                    return;
                }
            });
        }
        private async void DeleteCustomer(int customerID)
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/customers/delete";
            uri.Query = "customerId=" + customerID; //will change when login sorted
            HttpResponseMessage message = await _client.DeleteAsync(uri.Uri);

            if (message.IsSuccessStatusCode)
            {
                DeleteCheck = "Your Account has now been deleted";
            }
            else
            {
                DeleteCheck = "Your Account has not been deleted ";
            }
       
        }
        public bool IsSuccessStatusCode { get; }
        public string DeleteCheck
        {
            get
            {
                return _deleteCheck;
            }
            set
            {
                _deleteCheck = value;
                OnPropertyChanged("DeleteCheck");
            }
        }
        public ICommand DeleteAccount { private set; get; }
    }
}
