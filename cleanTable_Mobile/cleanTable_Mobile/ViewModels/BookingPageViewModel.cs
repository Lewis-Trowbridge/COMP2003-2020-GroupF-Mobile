using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class BookingPageViewModel : BaseViewModel
    {
        private HttpClient _client;
        private string _venueName;
        private string _venueAddress;
        private DateTime _bookDateTime;
        private int _bookPartySize;
        private int _bookTable;
        private int _venueID;


        public BookingPageViewModel(int bookingId)
        {
            Title = "Booking View";

            _client = new HttpClient();

            GetBooking(bookingId);

            SendRequest = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new BookingDelete(bookingId));
            });
            SendRequestEdit = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new BookingEdit(VenueId,bookingId));
            });

        }           

        public async void GetBooking(int BookingID)
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";            
            uri.Path = "COMP2003/COMP2003_F/api/api/bookings/view";            
            uri.Query = "bookingId=" + BookingID + "&customerId=" + CustomerId;
            HttpResponseMessage message = await _client.GetAsync(uri.Uri);
            
            GetBookingViewModel book = JsonConvert.DeserializeObject<GetBookingViewModel>(await message.Content.ReadAsStringAsync());
            VenueId = book.VenueID;
            VenueName = book.VenueName;
            VenueAddress = book.AddLineOne + "\n"
                         + book.AddLineTwo + "\n"
                         + book.City + "\n"
                         + book.County + "\n"
                         + book.VenuePostcode;
            BookDateTime = book.BookingTime;
            BookPartySize = book.BookingSize;
            BookTable = book.VenueTableNum;

        }

        public int VenueId
        {
            get
            {
                return _venueID;
            }
            set
            {
                _venueID = value;
                OnPropertyChanged("VenueId");
            }
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
        public int BookTable
        {
            get
            {
                return _bookTable;
            }
            set
            {
                _bookTable = value;
                OnPropertyChanged("BookTable");
            }
        }

        public ICommand SendRequest { private set; get; }
        public ICommand SendRequestEdit { private set; get; }
    }

}
