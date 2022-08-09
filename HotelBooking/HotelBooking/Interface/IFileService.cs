using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Interface
{
    public interface IFileService
    {
        string GetRootPath();
        bool CreateFile(BookingData data);
        bool CreateRoomFiles(Room roomData);
        void LoadRoomData(List<Room> _iroomsList);
    }
}
