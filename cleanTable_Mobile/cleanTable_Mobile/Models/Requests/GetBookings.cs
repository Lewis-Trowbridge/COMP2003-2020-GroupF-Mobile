using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class GetBookings
    {
        public int bookingId { get; set; }
        public DateTime bookingDateTime { get; set; }    
        public int bookingSize { get; set; }
        public string venueName { get; set; }
        public string venuePostcode { get; set; }

    }
}
