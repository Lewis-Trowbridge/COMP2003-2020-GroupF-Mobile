using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Models.Responses;
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
    class EditCustomerViewModel : BaseViewModel
    {
        private HttpClient _client;
        private string _fullName;
        private string _lastName;
        private string _contactNumber;
        private string _username;
        private string _password;
        private string _errorCheck;
        
        public EditCustomerViewModel()
        {
            Title = "Edit Account";
            _client = new HttpClient();


            FillCustomerFields();

            CreateRequest = new Command(EditCustomer);

        }
        public async void FillCustomerFields()
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/customers/view";
            uri.Query = "customerId=" + CustomerId;
            HttpResponseMessage message = await _client.GetAsync(uri.Uri);

            GetCustomerViewModel customer = JsonConvert.DeserializeObject<GetCustomerViewModel>(await message.Content.ReadAsStringAsync());
            
            FullName = customer.CustomerName;
            ContactNumber = customer.CustomerContactNumber;
            UserName = customer.CustomerUsername;
        }
        public async void EditCustomer()
        {
            EditCustomerModel customer = new EditCustomerModel();
            customer.CustomerId = CustomerId;
            customer.CustomerName = _fullName;
            customer.CustomerContactNumber = _contactNumber;
            customer.CustomerUserName = _username;
            customer.CustomerPassword = _password;

            string JsonData = JsonConvert.SerializeObject(customer); 
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            UriBuilder uri = new UriBuilder();

            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "/COMP2003/COMP2003_F/api/api/customers/edit";

            HttpResponseMessage response = await _client.PutAsync(uri.Uri, content);

            if (response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CustomerView(CustomerId));
            }
            else
            {
                ErrorCheck = "Error - Please Try Again"; 
            }

        }

        public bool IsSuccessStatusCode { get; }

        public string ErrorCheck
        {
            get
            {
                return _errorCheck;
            }
            set
            {
                _errorCheck = value;
                OnPropertyChanged("ErrorCheck");
            }
        }
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                if (_contactNumber != value)
                {
                    _contactNumber = value;
                    OnPropertyChanged("ContactNumber");
                }
            }
        }
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("UserName");
                }
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public ICommand CreateRequest { private set; get; }

    }
}
