﻿using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class VenuePageViewModel : BaseViewModel
    {
        private HttpClient _client;
        private string _venueName;
        private string _venueAddress;
        private int _totalCapacity;
        private int _venueId;
        public int id
        {
            get
            {
                return _venueId;
            }
            set
            {
                _venueId = value;
                OnPropertyChanged("id");
            }
        }
        public VenuePageViewModel(int VenID)
        {
            Title = "Venue Page";
            id = VenID;
            _client = new HttpClient();
            Debug.WriteLine(id);
            GetVenue(id);


            SendRequest = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new BookingPage(id));
            });

        }
        public async void GetVenue(int VenueID)
        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/venues/view";
            uri.Query = "venueId=" + VenueID; //will change when Homepage is all up and running
            HttpResponseMessage message = await _client.GetAsync(uri.Uri);

            GetVenueView venue = JsonConvert.DeserializeObject<GetVenueView>(await message.Content.ReadAsStringAsync());
            
            VenueName = venue.VenueName;
            VenueAddress = venue.AddLineOne + "\n"
                        + venue.AddLineTwo + "\n"
                        + venue.City + "\n"
                        + venue.County + "\n"
                        + venue.VenuePostcode;
            TotalCapacity = venue.TotalCapacity;
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
        public int TotalCapacity
        {
            get
            {
                return _totalCapacity;
            }
            set
            {
                _totalCapacity = value;
                OnPropertyChanged("TotalCapacity");
            }
        }

        public ICommand SendRequest { private set; get; }
        public int VenID { get; }
    }
}