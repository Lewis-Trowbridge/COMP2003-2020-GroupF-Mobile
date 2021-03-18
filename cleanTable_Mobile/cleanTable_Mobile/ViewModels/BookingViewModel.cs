using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using cleanTable_Mobile.Views
using cleanTable_Mobile.Models;

namespace cleanTable_Mobile.ViewModels
{
    class BookingViewModel : BaseViewModel
    {
       static HttpClient httpClient = new HttpClient();
        public BookingViewModel()
        {
            Title = "Booking";
           
        }

        public class MyHTTP
        {
            BookingPage booking = new BookingPage();
            
          
               

           
            public async Task<Uri> CreateBookingAsync(BookingModel booking)
            {
                int partysize = booking.getBookingSize();
                DateTime BookingTime = booking.getBookingTime();


                UriBuilder uri = new UriBuilder();

                uri.Host = "web.socem.plymouth.ac.uk";
                uri.Scheme = "http";
                uri.Path = "api/api/venue/booktable";
               // var request = new HttpRequestMessage(HttpMethod.Post,"https://localhost:44370/api/venues/bookTable?venueTableId=2&customerId=3&bookingTime=2077-08-03 15:10:00&bookingSize=3");

                HttpResponseMessage response = await httpClient.PostAsync(uri.Uri, );
                response.EnsureSuccessStatusCode();

                return response.Headers.Location;
            }
            
            

        }

    }
}
