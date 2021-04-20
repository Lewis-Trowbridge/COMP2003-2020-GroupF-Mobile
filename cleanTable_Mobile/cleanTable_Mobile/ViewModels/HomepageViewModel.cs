using cleanTable_Mobile.Models.Requests;
using cleanTable_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class HomepageViewModel : BaseViewModel
    {
        private HttpClient _client;
        private GetTopVenues _selectedItem;
        private List<GetTopVenues> venue = new List<GetTopVenues>();
        private ObservableCollection<GetTopVenues> _venues;

        private int _venueChosen;

        public GetTopVenues SelectedVenue
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    _venueChosen = value.VenueID;
                    NextPage();

                }
            }
        }

        public int VenueChosen
        {
            get
            {
                return _venueChosen;
            }
            set
            {
                if (_venueChosen != value)
                {
                    _venueChosen = value;
                    OnPropertyChanged("VenueChosen");
                    
                }
            }
        }

        public async void NextPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VenuePage(_venueChosen));
        }

        public HomepageViewModel()
        {
            Title = "Homepage";

            _client = new HttpClient();

            _venues = new ObservableCollection<GetTopVenues>();

            GetTopVenueList();

        }
        public ObservableCollection<GetTopVenues> Venues
        {
            get { return _venues; }
            set
            {
                _venues = value;
            }
        }
        public async void GetTopVenueList()

        {
            UriBuilder uri = new UriBuilder();
            uri.Host = "web.socem.plymouth.ac.uk";
            uri.Scheme = "http";
            uri.Path = "COMP2003/COMP2003_F/api/api/venues/top";

            HttpResponseMessage message = await _client.GetAsync(uri.Uri);

            venue = JsonConvert.DeserializeObject<List<GetTopVenues>>(await message.Content.ReadAsStringAsync());

            foreach (GetTopVenues item in venue)
            {
                Venues.Add(item);
            };
        }


    }
}
