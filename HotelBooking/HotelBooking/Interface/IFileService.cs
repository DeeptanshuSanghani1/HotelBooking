using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Interface
{
    public interface IFileService
    {
        bool CreateFile(BookingData data);
    }
}
