using Android.Content.Res;
using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Models.Responses;
using cleanTable_Mobile.Views;
using cleanTable_Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class EditBookingViewModel : BaseViewModel
    {
        private HttpClient _client;
        private TimeSpan _selectedTime;
        private int _numberOfPeople;
        private int _tableChosen;
        private bool _completeBooking;
        private bool _bookTable;
        private string _editCheck;
        private ObservableCollection<TablesAvailableModel> _tables;
        private TablesAvailableModel _selectedIndexTable { get; set; }
        private List<TablesAvailableModel> TableList = new List<TablesAvailableModel>();

        public DateTime SelectedDate { get; set; }

        public EditBookingViewModel(int VenueID, int BookingID)
        {
        
            Title = "Edit Booking";

            _client = new HttpClient();
            _tables = new ObservableCollection<TablesAvailableModel>();
            _completeBooking = false;
            _bookTable = true;

            TableRequest = new Command(async () =>
            {
                UriBuilder uri = new UriBuilder();
                uri.Host = "web.socem.plymouth.ac.uk";
                uri.Scheme = "http";
                uri.Path = "COMP2003/COMP2003_F/api/api/venues/tablesAvailable";
                uri.Query = "venueId=" + VenueID + "&partySize=" + NumberOfPeople
                + "&bookingTime=" + SelectedDate.Date.Add(_selectedTime).ToString("O");
                HttpResponseMessage message = await _client.GetAsync(uri.Uri);
                TableList = JsonConvert.DeserializeObject<List<TablesAvailableModel>>(await message.Content.ReadAsStringAsync());

                foreach (TablesAvailableModel tables in TableList)
                {
                    Tables.Add(tables);
                };
                CompleteBooking = true;
                BookTable = false;
            });

            SendRequest = new Command(async () =>
            {
                    EditBookingModel booking = new EditBookingModel();
                    booking.BookingId = BookingID;
                    booking.BookingTime = SelectedDate.Date.Add(_selectedTime);
                    booking.BookingSize = _numberOfPeople;
                    booking.VenueTableId = _tableChosen;

                    string JsonData = JsonConvert.SerializeObject(booking);
                    StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                    UriBuilder uri = new UriBuilder();
                    uri.Host = "web.socem.plymouth.ac.uk";
                    uri.Scheme = "http";
                    uri.Path = "/COMP2003/COMP2003_F/api/api/bookings/edit";

                    HttpResponseMessage response = await _client.PutAsync(uri.Uri, content);
                
                    if (response.IsSuccessStatusCode)
                    {
                    await Application.Current.MainPage.Navigation.PushAsync(new BookingView(BookingID));
                    }
                    else
                    {
                         EditCheck = "Your Booking has not been changed ";
                    }
                
            });

        }

        public ObservableCollection<TablesAvailableModel> Tables
        {
            get { return _tables; }
            set
            {
                _tables = value;
            }
        }

        public TimeSpan SelectedTime
        {
            get
            {
                return this._selectedTime;
            }
            set
            {
                this._selectedTime = value;
                OnPropertyChanged("SelectedTime");
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return (int)this._numberOfPeople;
            }
            set
            {
                this._numberOfPeople = value;
                OnPropertyChanged("NumberOfPeople");
            }
        }

        public TablesAvailableModel SelectedIndexTable
        {
            get { return _selectedIndexTable; }
            set
            {
                if (_selectedIndexTable != value)
                {
                    _selectedIndexTable = value;
                    _tableChosen = value.TableId;
                    OnPropertyChanged("SelectedIndexTable");
                }
            }
        }

        public int TableChosen
        {
            get
            {
                return _tableChosen;
            }
            set
            {
                if (_tableChosen != value)
                {
                    _tableChosen = value;
                    OnPropertyChanged("tableChosen");
                }
            }
        }
        public bool CompleteBooking
        {
            get
            {
                return _completeBooking;
            }
            set
            {
                _completeBooking = value;
                OnPropertyChanged("CompleteBooking");
            }
        }
        public bool BookTable
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
         public bool IsSuccessStatusCode { get; }
        public string EditCheck
        {
            get
            {
                return _editCheck;
            }
            set
            {
                _editCheck = value;
                OnPropertyChanged("EditCheck");
            }
        }
        public ICommand TableRequest { private set; get; }
        public ICommand SendRequest { private set; get; }

    }
}
