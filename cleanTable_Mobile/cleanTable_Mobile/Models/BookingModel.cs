using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models
{
    class BookingModel
    {
        private int BookingId;
        private DateTime BookingTime;
        private int BookingSize;

        //getters
        public int getBookingID()
        {
            return BookingId;
        }

        public DateTime getBookingTime()
        {
            return BookingTime;
        }
        public int getBookingSize()
        {
            return BookingSize;
        }

        //setters

        public void setBookingID(int BookId)
        {
            BookingId = BookId;
        }

        public void setBoookingTime(DateTime BookTime)
        {
            BookingTime = BookTime;
        }

        public void setBookingSize(int BookSize)
        {
            BookingSize = BookSize;
        }

    }
}
