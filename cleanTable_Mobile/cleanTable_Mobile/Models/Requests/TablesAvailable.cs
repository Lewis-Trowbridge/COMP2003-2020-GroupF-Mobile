﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class TablesAvailable
    {
        public int TableId { get; set; }
        public int VenueTableNumber { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
