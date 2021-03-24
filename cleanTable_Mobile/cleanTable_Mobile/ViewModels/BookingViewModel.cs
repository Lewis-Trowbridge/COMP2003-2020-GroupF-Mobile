using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using cleanTable_Mobile.Views;
using cleanTable_Mobile.Models.Requests;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;

namespace cleanTable_Mobile.ViewModels
{
    class BookingViewModel : BaseViewModel
    {
        private HttpClient client;
        private TimeSpan selectedTime;
        private int numberOfPeople;

       
        public BookingViewModel()
        {

            Title = "Bookings";
            client = new HttpClient();

           
            SendRequest = new Command(async () =>
            {
                
                //Set booking object
                CreateBookingRequest booking = new CreateBookingRequest();
                booking.BookingSize = numberOfPeople;
   
                booking.BookingDateTime = SelectedDate.Date.Add(selectedTime); //adds time to datetime 
                booking.CustomerId = 24; //hardcoded
                booking.VenueTableId = 1;



                
                string JsonData = JsonConvert.SerializeObject(booking); //converts booking object to Json format
                StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                UriBuilder uri = new UriBuilder();

                uri.Host = "web.socem.plymouth.ac.uk";
                uri.Scheme = "http";
                uri.Path = "/COMP2003/COMP2003_F/api/api/venues/booktable";
              

                HttpResponseMessage response = await client.PostAsync(uri.Uri, content);

               
                Console.WriteLine(response.Headers.Location);
               



            });
        }
       
        public DateTime SelectedDate { get; set; }

        public TimeSpan SelectedTime
        {
            get
            {
                return this.selectedTime;
            }
            set
            {
                this.selectedTime = value;
                OnPropertyChanged("SelectedTime");
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            set
            {
                this.numberOfPeople = value;
                OnPropertyChanged("NumberOfPeople");
            }
        }

        public ICommand SendRequest { private set; get; }
    }


}

