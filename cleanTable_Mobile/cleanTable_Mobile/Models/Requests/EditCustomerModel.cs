using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models.Requests
{
    class EditCustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerPassword { get; set; }
    }
}
