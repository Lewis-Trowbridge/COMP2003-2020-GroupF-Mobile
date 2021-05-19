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
    class CreateBookingViewModel : BaseViewModel
    {
        private HttpClient _client;
        private TimeSpan _selectedTime;
        private int _numberOfPeople;
        private int _tableChosen;
        private bool _completeBooking;
        private bool _bookTable;
        private ObservableCollection<TablesAvailableModel> _tables;
        private int _tableNum;
        private TablesAvailableModel _selectedIndexTable { get; set; }
        private List<TablesAvailableModel> TableList = new List<TablesAvailableModel>();
        
        public DateTime SelectedDate { get; set; }

        public CreateBookingViewModel(int VenueID)
        {
            Title = "Bookings";

            _client = new HttpClient();
            _tables = new ObservableCollection<TablesAvailableModel>();
            _completeBooking = false;
            _bookTable = true;

            if (CustomerId == 0)
            {
                UserLogin();
            }

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
                bool answer = await App.Current.MainPage.DisplayAlert("Check Your Booking Below", "Please Confirm your Booking" + "\n"
                    + "Date & Time: " + SelectedDate.Date.Add(_selectedTime).ToString() + "\n"
                    + "Party Size : " + NumberOfPeople.ToString() + "\n"
                    + "Table Chosen : " + _tableNum.ToString(),
                    "Confirm", "Cancel");
                
                if (answer == true)
                {
                    CreateBookingModel booking = new CreateBookingModel();
                    booking.BookingSize = _numberOfPeople;
                    booking.BookingDateTime = SelectedDate.Date.Add(_selectedTime); 
                    booking.CustomerId = CustomerId; 
                    booking.VenueTableId = _tableChosen;
                    Debug.WriteLine(booking.ToString());
                    string JsonData = JsonConvert.SerializeObject(booking); 
                    StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                    UriBuilder uri = new UriBuilder();
                    uri.Host = "web.socem.plymouth.ac.uk";
                    uri.Scheme = "http";
                    uri.Path = "/COMP2003/COMP2003_F/api/api/bookings/create/";

                    HttpResponseMessage response = await _client.PostAsync(uri.Uri, content);

                    CreationResultModel result = JsonConvert.DeserializeObject<CreationResultModel>(await response.Content.ReadAsStringAsync());

                    await Application.Current.MainPage.Navigation.PushAsync(new BookingView(result.Id));
                }
                else
                {
                    return;
                }
            });

        } 
        public async void UserLogin()
        {
            bool result = await Application.Current.MainPage.DisplayAlert("Question?", "Please log in? If you don't have an account please create one below", "Login", "Create Account");

            if (result == true)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CreateCustomer());
            }
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
                    _tableNum = value.VenueTableNumber;
                    
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
        public ICommand TableRequest { private set; get; }
        public ICommand SendRequest { private set; get; }

    }
}
