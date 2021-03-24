using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class CreateBookingRequest
    {
        //venueTableId
        public int VenueTableId { get; set; }
        //customerId
        public int CustomerId { get; set; }
        //bookingDateTime
        public DateTime BookingDateTime { get; set; }
        //bookingSize
        public int BookingSize { get; set; }

        
    }
}
