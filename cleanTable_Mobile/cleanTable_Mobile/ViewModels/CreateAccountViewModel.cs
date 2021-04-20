using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using cleanTable_Mobile.Models.Requests;
using Newtonsoft.Json;

namespace cleanTable_Mobile.ViewModels
{
    class CreateAccountViewModel: BaseViewModel
    {
        private HttpClient _client;
        private string _firstName;
        private string _lastName;
        private string _contactNumber;
        private string _username;
        private string _password;

        public CreateAccountViewModel()
        {
            Title = "Create Account";

            _client = new HttpClient();

            CreateRequest = new Command(async () =>
            {
                //Set Account object
                CreateAccountRequest createAccount = new CreateAccountRequest();
                
                createAccount.CustomerName = _firstName + " " +_lastName;
                createAccount.CustomerContactNumber = _contactNumber;
                createAccount.CustomerUserName = _username;
                createAccount.CustomerPassword = _password;
            
                string JsonData = JsonConvert.SerializeObject(createAccount); //converts booking object to Json format
                StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                UriBuilder uri = new UriBuilder();

                uri.Host = "web.socem.plymouth.ac.uk";
                uri.Scheme = "http";
                uri.Path = "/COMP2003/COMP2003_F/api/api/customers/create";

                HttpResponseMessage response = await _client.PostAsync(uri.Uri, content);

                Console.WriteLine(response.Headers.Location);

            });
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
