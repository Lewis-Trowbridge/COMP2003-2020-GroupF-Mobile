using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class CustomerPageViewModel : BaseViewModel
    {
        private HttpClient _client;
        private string _customerName;
        private string _customerNumber;
        private string _customerUsername;
        

        public CustomerPageViewModel()
        {
            Title = "Customer View";

            _client = new HttpClient();

            GetCustomer();

            SendRequest = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CustomerDelete());
            });

        }
        public async void GetCustomer()
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/customers/view";
            uri.Query =  "customerId=" + CustomerId;
            HttpResponseMessage message = await _client.GetAsync(uri.Uri);

            GetCustomerViewModel customer = JsonConvert.DeserializeObject<GetCustomerViewModel>(await message.Content.ReadAsStringAsync());
            CustomerName = customer.CustomerName;
            CustomerNumber = customer.CustomerContactNumber;
            CustomerUsername = customer.CustomerUsername;
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }
        public string CustomerNumber
        {
            get
            {
                return _customerNumber;
            }
            set
            {
                _customerNumber = value;
                OnPropertyChanged("CustomerNumber");
            }
        }
        public string CustomerUsername
        {
            get
            {
                return _customerUsername;
            }
            set
            {
                _customerUsername = value;
                OnPropertyChanged("CustomerUsername");
            }
        }

        public ICommand SendRequest { private set; get; }
    }
}

