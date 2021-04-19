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
        private bool _doneIsAvailable;

        private ObservableCollection<TablesAvailable> _tables;
        public ObservableCollection<TablesAvailable> Tables
        {
            get { return _tables; }
            set
            {
                _tables = value;
            }
        }

        public DateTime SelectedDate { get; set; }
        private TablesAvailable _selectedIndexTable { get; set; }
        private List<TablesAvailable> TableList = new List<TablesAvailable>();
        

        public TablesAvailable SelectedIndexTable
        {
            get { return _selectedIndexTable; }
            set
            {
                if (_selectedIndexTable != value)
                {
                    _selectedIndexTable = value;
                    _tableChosen = value.TableId;

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

        public bool DoneIsAvailable
        {
            get
            {
                return _doneIsAvailable;
            }
            set
            {
                _doneIsAvailable = value;
                OnPropertyChanged("DoneIsAvailable");
            }
        }

        public CreateBookingViewModel(int VenID)
        {
            Title = "Bookings";

            _client = new HttpClient();
            _tables = new ObservableCollection<TablesAvailable>();
            _doneIsAvailable = false;
            TableRequest = new Command(async () =>
            {
                UriBuilder uri = new UriBuilder();
                uri.Host = "web.socem.plymouth.ac.uk";
                uri.Scheme = "http";
                uri.Path = "COMP2003/COMP2003_F/api/api/venues/tablesAvailable";
                uri.Query = "venueId=" + VenID + "&partySize=" + NumberOfPeople
                + "&bookingTime=" + SelectedDate.Date.Add(_selectedTime).ToString("O");
                Debug.WriteLine(uri.Uri);
                HttpResponseMessage message = await _client.GetAsync(uri.Uri);
                Debug.WriteLine(await message.Content.ReadAsStringAsync());
                TableList = JsonConvert.DeserializeObject<List<TablesAvailable>>(await message.Content.ReadAsStringAsync());
                
                foreach (TablesAvailable tables in TableList)
                {
                    Tables.Add(tables);
                };
                DoneIsAvailable = true;
            });
            

            SendRequest = new Command(async () =>
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Question?", "Please Confirm your Booking" + "\n"
                    + "Venue : Subway" + "\n"
                    + "Date & Time: " + SelectedDate.Date.Add(_selectedTime).ToString() + "\n"
                    + "Party Size : " + NumberOfPeople.ToString() + "\n"
                    + "Table Chosen : " + TableChosen.ToString(),
                    "Confirm", "Cancel");
                
                if (answer == true)
                {
                    //Set booking object
                    CreateBookingRequest booking = new CreateBookingRequest();
                    booking.BookingSize = _numberOfPeople;

                    booking.BookingDateTime = SelectedDate.Date.Add(_selectedTime); //adds time to datetime 
                    booking.CustomerId = CustomerId; //hardcoded
                    booking.VenueTableId = _tableChosen;

                    string JsonData = JsonConvert.SerializeObject(booking); //converts booking object to Json format
                    StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                    UriBuilder uri = new UriBuilder();

                    uri.Host = "web.socem.plymouth.ac.uk";
                    uri.Scheme = "http";
                    uri.Path = "/COMP2003/COMP2003_F/api/api/venues/booktable";

                    HttpResponseMessage response = await _client.PostAsync(uri.Uri, content);

                    Debug.WriteLine(await response.Content.ReadAsStringAsync());

                    CreationResult result = JsonConvert.DeserializeObject<CreationResult>(await response.Content.ReadAsStringAsync());

                    await Application.Current.MainPage.Navigation.PushAsync(new BookingView(result.Id));
                }
                else
                {
                    return;
                }
            });

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

        public ICommand TableRequest { private set; get; }
        public ICommand SendRequest { private set; get; }

    }
}
