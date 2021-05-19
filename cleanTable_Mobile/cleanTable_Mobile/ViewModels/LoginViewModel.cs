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
        public Command UserLoggedIn { get; }
        public Command LogOutCommand { get; }

        private HttpClient _client;
        private string _username;
        private string _password;
        private string _errorCheck;
        private bool _userLogin;
        private bool _userLogOut;

        public LoginViewModel()
        {
            Title = "Login";
            _client = new HttpClient();
            UserLogin = false;
            UserLogOut = true;

            if (CustomerId != 0)
            {
                UserLogin = true;
                UserLogOut = false;
                LoggedIn();
            }

            LoginCommand = new Command(OnLoginClicked);
            LogOutCommand = new Command(LoggedOut);
            UserLoggedIn = new Command(LoggedIn);
        }
        public async void LoggedIn()
        {
               await Application.Current.MainPage.Navigation.PushAsync(new CustomerView(CustomerId));
        }

        public async void LoggedOut()
        {
            CustomerId = 0;
            UserLogin = false;
            UserLogOut = true;
            await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
        }
        private async void OnLoginClicked()
        {
            LoginUserModel login = new LoginUserModel();
            login.CustomerUserName = _username;
            login.CustomerPassword = _password;


            string JsonData = JsonConvert.SerializeObject(login); 
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            UriBuilder uri = new UriBuilder();

            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "/COMP2003/COMP2003_F/api/api/login";

            HttpResponseMessage response = await _client.PostAsync(uri.Uri, content);

            CreationResultModel result = JsonConvert.DeserializeObject<CreationResultModel>(await response.Content.ReadAsStringAsync());

            CustomerId = result.Id;
            
            if (response.IsSuccessStatusCode)
            {
                UserLogin = true;
                UserLogOut = false;
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
        public bool UserLogin
        {
            get
            {
                return _userLogin;
            }
            set
            {
                _userLogin = value;
                OnPropertyChanged("UserLogin");
            }
        }
        public bool UserLogOut
        {
            get
            {
                return _userLogOut;
            }
            set
            {
                _userLogOut = value;
                OnPropertyChanged("UserLogOut");
            }
        }
    }
}
