using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models
{
    class VenueModel
    {
        private int VenueID;
        private string VenueName;
        private string VenuePostcode;
        private string AddLineOne;
        private string AddLineTwo;
        private string City;
        private string County;

        public int GetVenueID()
        {
            return VenueID;
        }

        public string GetVenueName()
        {
            return VenueName;
        }
        public string GetVenuePostcode()
        {
            return VenuePostcode;
        }
        public string GetAddLineOne()
        {
            return AddLineOne;
        }

        public string GetAddLineTwo()
        {
            return AddLineTwo;
        }
        public string GetCity()
        {
            return City;
        }

        public string GetCounty()
        {
            return County;
        }

        public void SetVenueID(int ID)
        {
            VenueID = ID;
        }
        public void SetVenueName(string Name)
        {
            VenueName = Name;
        }

        public void SetVenuePostcode(string Postcode)
        {
            VenuePostcode = Postcode;
        }
        public void SetAddLineOne(string LineOne)
        {
            AddLineOne = LineOne;
        }
        public void SetAddLineTwo(string LineTwo)
        {
            AddLineTwo = LineTwo;
        }

        public void SetCity(string VenueCity)
        {
            City = VenueCity;
        }
        public void SetCounty(string VenueCounty)
        {
            County = VenueCounty;
        }
    }
}
