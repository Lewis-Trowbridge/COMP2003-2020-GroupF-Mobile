using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models
{
    class BookingModel
    {
      public int BookingId;
        ////public TimeSpan BookingTime;
        public int BookingSize;
        public DateTime BookingDate;

        //getters
        public int getBookingID()
        {
            return BookingId;
        }

        //public TimeSpan getBookingTime()
        //{
        //    return BookingTime;
        //}

        public DateTime getBooingDate()
        {
            return BookingDate;
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

        //public void setBoookingTime(TimeSpan BookTime)
        //{
        //    BookingTime = BookTime;
        //}

        public void setBookingSize(int BookSize)
        {
            BookingSize = BookSize;
        }
        
        public void setBookingDate(DateTime BookDate)
        {
            BookingDate = BookDate;
        }

        

    }
}
