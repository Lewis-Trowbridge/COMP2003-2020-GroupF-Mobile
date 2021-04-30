using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class GetCustomerView
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string customerContactNumber { get; set; }
        public string customerUsername { get; set; }

    }
}
