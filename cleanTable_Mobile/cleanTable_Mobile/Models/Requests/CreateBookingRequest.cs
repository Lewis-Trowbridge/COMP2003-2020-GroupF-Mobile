using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class CreateBookingRequest
    {
        
        public int VenueTableId { get; set; }
        
        public int CustomerId { get; set; }
        
        public DateTime BookingDateTime { get; set; }
        
        public int BookingSize { get; set; }

        
    }
}
