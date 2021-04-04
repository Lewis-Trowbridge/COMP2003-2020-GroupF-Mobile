using cleanTable_Mobile.Models.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace cleanTable_Mobile.ViewModels
{
    class BookingPageViewModel : BaseViewModel
    {
        private HttpClient _client;
        private string _venueName;
        private string _venueAddress;
        private DateTime _bookDateTime;
        private int _bookPartySize;

        public BookingPageViewModel()
        {
            Title = "Booking View";

            _client = new HttpClient();

            GetBooking(34); //hard coded for now

        }           
        public async void GetBooking(int BookingID)
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";            
            uri.Path = "COMP2003/COMP2003_F/api/api/bookings/view";            
            uri.Query = "bookingId=" + BookingID + "&customerId=" + 24; //will change when login sorted
            HttpResponseMessage message = await _client.GetAsync(uri.Uri);
            
            GetBookingView book = JsonConvert.DeserializeObject<GetBookingView>(await message.Content.ReadAsStringAsync());

            VenueName = book.VenueName;
            VenueAddress = book.AddLineOne + "\n"
                         + book.AddLineTwo + "\n"
                         + book.City + "\n"
                         + book.County + "\n"
                         + book.VenuePostcode;
            BookDateTime = book.BookingTime;
            BookPartySize = book.BookingSize;
        }

        public string VenueName
        {
            get
            {
                return _venueName;
            }
            set
            {
                _venueName = value;
                OnPropertyChanged("VenueName");
            }
        }
        public string VenueAddress
        {
            get
            {
                return _venueAddress;
            }
            set
            {
                _venueAddress = value;
                OnPropertyChanged("VenueAddress");
            }
        }
        public DateTime BookDateTime
        {
            get
            {
                return _bookDateTime;
            }
            set
            {
                _bookDateTime = value;
                OnPropertyChanged("BookDateTime");
            }
        }
        public int BookPartySize
        {
            get
            {
                return _bookPartySize;
            }
            set
            {
                _bookPartySize = value;
                OnPropertyChanged("BookPartySize");
            }
        }
    }
}
