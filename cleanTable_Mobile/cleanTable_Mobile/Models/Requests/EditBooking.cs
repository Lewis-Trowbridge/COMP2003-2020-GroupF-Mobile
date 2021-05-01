using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class EditBooking
    {
        public int bookingId { get; set; }
        public DateTime bookingTime { get; set; }
        public int bookingSize { get; set; }
        public int venueTableId { get; set; }
    }
}
