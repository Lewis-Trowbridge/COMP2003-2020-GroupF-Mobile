using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class GetTopVenues
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string City { get; set; }
        public string VenuePostcode { get; set; }
    }
}
