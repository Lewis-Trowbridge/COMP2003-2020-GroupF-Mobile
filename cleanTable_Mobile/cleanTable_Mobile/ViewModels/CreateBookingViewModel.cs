using Android.Content.Res;
using cleanTable_Mobile.Models.Requests;
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
        private Tables _selectedIndexTable { get; set; }
        public List<Tables> TableList { get; set; }
        public List<Tables> GetTables()
        {
            var Tables = new List<Tables>()
            {
                new Tables(){TableId = 1, TableNumber = 1, TableCapacity = 2},
                new Tables(){TableId = 2, TableNumber = 2, TableCapacity = 4},
                new Tables(){TableId = 3, TableNumber = 5, TableCapacity = 6}
            };
            return Tables;
        }

        public Tables SelectedIndexTable
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

        public CreateBookingViewModel()
        {
            Title = "Bookings";

            TableList = GetTables().OrderBy(t => t.TableNumber).ToList();

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
                    booking.CustomerId = 24; //hardcoded
                    booking.VenueTableId = _tableChosen;

                    string JsonData = JsonConvert.SerializeObject(booking); //converts booking object to Json format
                    StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                    UriBuilder uri = new UriBuilder();

                    uri.Host = "web.socem.plymouth.ac.uk";
                    uri.Scheme = "http";
                    uri.Path = "/COMP2003/COMP2003_F/api/api/venues/booktable";

                    HttpResponseMessage response = await _client.PostAsync(uri.Uri, content);

                    Debug.WriteLine(await response.Content.ReadAsStringAsync());
                    

                    //await Application.Current.MainPage.Navigation.PushAsync(new BookingView());
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
        public class Tables
        {
            public int TableId { get; set; }
            public int TableNumber { get; set; }
            public int TableCapacity { get; set; }

        }

        public ICommand SendRequest { private set; get; }

    }
}
