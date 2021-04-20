using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class GetVenueView
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string VenuePostcode { get; set; }
        public string AddLineOne { get; set; }
        public string AddLineTwo { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int TotalCapacity { get; set; }
    }
}
