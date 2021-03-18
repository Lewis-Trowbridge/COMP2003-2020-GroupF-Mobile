using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models
{
    class CustomerModel
    {
        private int CustomerId;
        private string CustomerFirstName;
        private string CustomerLastName;
        private string CustomerContactNumber;
        private string CustomerUsername;
        private string CustomerPassword;

        public int GetCustomerId()
        {
            return CustomerId;
        }

        public string GetCustomerFirstName()
        {
            return CustomerFirstName;
        }
        public string GetCustomerLastName()
        {
            return CustomerLastName;
        }
        public string getCustomerContactNumber()
        {
            return CustomerContactNumber;
        }
        public string GetCustomerUsername()
        {
            return CustomerUsername;
        }

        public string GetCustomerPassword()
        {
            return CustomerPassword;
        }

        public void SetCustomerId(int ID)
        {
            CustomerId = ID;
        }
        public void SetCustomerFirstName(string FirstName)
        {
            CustomerFirstName = FirstName;
        }

        public void SetCustomerLastName(string LastName)
        {
            CustomerLastName = LastName;
        }
        public void SetCustomerContactNumber(string ContactNumber)
        {
            CustomerContactNumber = ContactNumber;
        }
        public void SetCustomerUsername(string Username)
        {
            CustomerUsername = Username;
        }

        public void SetCustomerPassword(string Password)
        {
            CustomerPassword = Password;
        }
    }
}
