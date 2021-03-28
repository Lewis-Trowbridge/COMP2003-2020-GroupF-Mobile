using System;
using System.Collections.Generic;
using System.Text;

namespace cleanTable_Mobile.Models
{
    class VenueTableModel
    {
        private int VenueTableId;
        private int VenueTableNumber;
        private int VenueTableCapacity;


        public int getVenueTableID()
        {
            return VenueTableId;
        }
        public int getVenueTableNumber()
        {
            return VenueTableNumber;
        }

        public int getVenueTableCapacity()
        {
            return VenueTableCapacity;
        }

        public void setVenueTableID(int TableId)
        {
            VenueTableId = TableId;
        }

        public void setVenueTableNumber(int TableNumber)
        {
            VenueTableNumber = TableNumber;
        }
        public void setVenueTableCapacity(int TableCapacity)
        {
            VenueTableCapacity = TableCapacity;
        }

    }
}
