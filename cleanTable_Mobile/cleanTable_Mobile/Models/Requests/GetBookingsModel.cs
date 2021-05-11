using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class GetBookingsModel
    {
        public int BookingId { get; set; }
        public DateTime BookingDateTime { get; set; }    
        public int BookingSize { get; set; }
        public string VenueName { get; set; }
        public string VenuePostcode { get; set; }

    }
}
