using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class GetTopVenues
    {
        public int venueId { get; set; }
        public string venueName { get; set; }
        public string venueCity { get; set; }
        public string venuePostcode { get; set; }

    }
}
