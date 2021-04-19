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

        public DateTime SelectedDate { get; set; }
        private TablesAvailable _selectedIndexTable { get; set; }
        public List<TablesAvailable> TableList { get; set; }
        public List<TablesAvailable> GetTables()
        {
            var Tables = new List<TablesAvailable>()
            {
                new TablesAvailable(){TableId = 1, VenueTableNumber = 1, NumberOfSeats = 2},
                new TablesAvailable(){TableId = 2, VenueTableNumber = 2, NumberOfSeats = 4},
                new TablesAvailable(){TableId = 3, VenueTableNumber = 5, NumberOfSeats = 6}
            };
            return Tables;
        }

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

        public CreateBookingViewModel(int VenID)
        {
            Title = "Bookings";

            TableList = GetTables().OrderBy(t => t.VenueTableNumber).ToList();

            _client = new HttpClient();

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


        public ICommand SendRequest { private set; get; }

    }
}
