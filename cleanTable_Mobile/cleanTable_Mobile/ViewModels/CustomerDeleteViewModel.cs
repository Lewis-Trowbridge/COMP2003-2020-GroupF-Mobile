﻿using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Views;
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
        private bool _completeDelete;

        public CustomerDeleteViewModel()
        {
            Title = "Delete Customer";
            _client = new HttpClient();
           

            DeleteAccount = new Command(async () =>
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Question?", "Are you sure?" ,
                "Confirm", "Cancel");
                if (answer == true)
                {
                    DeleteCustomer();
                    await Shell.Current.GoToAsync($"//{nameof(Homepage)}");
                }
                else
                {
                    return;
                }
            });
        }
        private async void DeleteCustomer()
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/customers/delete";
            uri.Query = "customerId=" + CustomerId; 
            HttpResponseMessage message = await _client.DeleteAsync(uri.Uri);

            if (message.IsSuccessStatusCode)
            {
                DeleteCheck = "This Customer has been DELETED";
            }
            else
            {
                DeleteCheck = "Error - Please Try Again";
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
        public bool CustomerDeleted
        {
            get
            {
                return _completeDelete;
            }
            set
            {
                _completeDelete = value;
                OnPropertyChanged("CompleteDelete");
            }
        }
        public ICommand DeleteAccount { private set; get; }
    }
}
