using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class GetBookingView
    {
        public int BookingID { get; set; }
        public DateTime BookingTime { get; set; }
        public int BookingSize { get; set; }
        public bool BookingAttended { get; set; }
        public int CustomerID { get; set; }
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string VenuePostcode { get; set; }
        public int VenueTableID { get; set; }
        public int VenueTableNum { get; set; }
        public int VenueTableCapcity { get; set; }
        public string AddLineOne { get; set; }
        public string AddLineTwo { get; set; }
        public string City { get; set; }
        public string County { get; set; }

    }
}
