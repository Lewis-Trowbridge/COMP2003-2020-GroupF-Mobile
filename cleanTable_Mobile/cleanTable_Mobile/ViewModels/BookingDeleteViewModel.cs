using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class BookingDeleteViewModel : BaseViewModel
    {
        private HttpClient _client;
        private string _deleteCheck;
        private int _bookingID;
        public BookingDeleteViewModel(int bookingId)
        {

            Title = "Delete Booking";
            _client = new HttpClient();
            _bookingID = bookingId; //will be changed when account is logged in/created

            DeleteAccount = new Command(async () =>
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Question?", "Are you sure?",
                "Confirm", "Cancel");
                if (answer == true)
                {
                    DeleteBooking(_bookingID);
                }
                else
                {
                    return;
                }
            });
        }
        private async void DeleteBooking(int BookingID)
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/bookings/delete";
            uri.Query = "bookingId=" + BookingID; //will change when login sorted
            HttpResponseMessage message = await _client.DeleteAsync(uri.Uri);

            if (message.IsSuccessStatusCode)
            {
                DeleteCheck = "worked";
            }
            else
            {
                DeleteCheck = "nah";
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


