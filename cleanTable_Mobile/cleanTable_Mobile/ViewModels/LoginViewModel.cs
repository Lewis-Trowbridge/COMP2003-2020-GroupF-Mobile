using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Models.Responses;
using cleanTable_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private HttpClient _client;
        private string _username;
        private string _password;
        private string _errorCheck;

        public LoginViewModel()
        {
            
            Title = "Login";
            _client = new HttpClient();
            LoggedIn();
            LoginCommand = new Command(OnLoginClicked);

            
        }
        public async void LoggedIn()
        {
            if(CustomerId != 0)
            {
               await Application.Current.MainPage.Navigation.PushAsync(new CustomerView(CustomerId));
            } 
        }

        private async void OnLoginClicked()
        {
            LoginUser login = new LoginUser();
            login.CustomerUserName = _username;
            login.CustomerPassword = _password;


            string JsonData = JsonConvert.SerializeObject(login); //converts booking object to Json format
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            UriBuilder uri = new UriBuilder();

            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "/COMP2003/COMP2003_F/api/api/login";

            HttpResponseMessage response = await _client.PostAsync(uri.Uri, content);

            Debug.WriteLine(await response.Content.ReadAsStringAsync());

            CreationResult result = JsonConvert.DeserializeObject<CreationResult>(await response.Content.ReadAsStringAsync());

            CustomerId = result.Id;

            if (response.IsSuccessStatusCode)
            {
               await Application.Current.MainPage.Navigation.PushAsync(new CustomerView(CustomerId));
            }
            else
            {
                ErrorCheck = "Error - Username or Password incorrect!"; 
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
        public string Username
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
                    OnPropertyChanged("Username");
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
    }
}
