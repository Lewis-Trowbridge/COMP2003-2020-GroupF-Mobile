﻿using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace cleanTable_Mobile.ViewModels
{
    class GetBookingsViewModel: BaseViewModel
    {
        public ObservableCollection<GetBookings> _histBookings;
        HttpClient _client;
        private GetBookings _selectedItem;
        private int _bookingChosen;

        public GetBookingsViewModel()
        {
            _histBookings = new ObservableCollection<GetBookings>();
            _client = new HttpClient();
            Title = "Your Bookings";

        UpcomingBookings();
            

            GetHistoryBookings = new Command(() =>
            {
                HistoricBookings();
            });
            GetUpcomingBookings = new Command(() =>
            {
                UpcomingBookings();
            });
           
        }
        public async void NextPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BookingView(_bookingChosen));
        }
       
        public async void HistoricBookings()
        {
            GetBookings.Clear();
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/bookings/history";
            uri.Query = "customerId=" + CustomerId;

            HttpResponseMessage message = await _client.GetAsync(uri.Uri);

            List<GetBookings> histBookings = JsonConvert.DeserializeObject<List<GetBookings>>(await message.Content.ReadAsStringAsync());

            foreach (GetBookings items in histBookings)
            {
                GetBookings.Add(items);
            };
        }
        public async void UpcomingBookings()
        {
            GetBookings.Clear();
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/bookings/upcoming";
            uri.Query = "customerId=" + CustomerId;

            HttpResponseMessage message = await _client.GetAsync(uri.Uri);

            List<GetBookings> upcomingBookings = JsonConvert.DeserializeObject<List<GetBookings>>(await message.Content.ReadAsStringAsync());

            foreach (GetBookings items in upcomingBookings)
            {
                GetBookings.Add(items);
            };
        }
        public ObservableCollection<GetBookings> GetBookings
        {
            get { return _histBookings; }
            set
            {
                _histBookings = value;
            }
        }
        public ICommand GetHistoryBookings { private set; get; }
        public ICommand GetUpcomingBookings { private set; get; }
        public GetBookings selectedBooking
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    _bookingChosen = value.BookingId;
                    NextPage();
                }
            }
        }
        public int BookingChosen
        {
            get
            {
                return _bookingChosen;
            }
            set
            {
                if (_bookingChosen != value)
                {
                    _bookingChosen = value;
                    OnPropertyChanged("BookingChosen");

                }
            }
        }
    }
}
