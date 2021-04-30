﻿using cleanTable_Mobile.Models.Requests;
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
        private string _firstName;
        private string _lastName;
        private string _contactNumber;
        private string _username;
        private string _password;
        private string _errorCheck;
        public EditCustomerViewModel()
        {
            Title = "Create Account";

            _client = new HttpClient();

            CreateRequest = new Command(EditCustomer);

        }
        public async void EditCustomer()
        {
            EditCustomers customer = new EditCustomers();
            customer.CustomerId = CustomerId;
            customer.CustomerName = _firstName + " " + _lastName;
            customer.CustomerContactNumber = _contactNumber;
            customer.CustomerUserName = _username;
            customer.CustomerPassword = _password;

            string JsonData = JsonConvert.SerializeObject(customer); //converts booking object to Json format
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            UriBuilder uri = new UriBuilder();

            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "/COMP2003/COMP2003_F/api/api/customers/edit";

            HttpResponseMessage response = await _client.PutAsync(uri.Uri, content);

            CreationResult result = JsonConvert.DeserializeObject<CreationResult>(await response.Content.ReadAsStringAsync());

            await Application.Current.MainPage.Navigation.PushAsync(new CustomerView(result.Id));

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
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
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
