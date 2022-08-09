using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Interface
{
    //Interface Method for File Service. This File Service in the Android app implemments this method to store data in the Andoid file manager
    public interface IFileService
    {
        string GetRootPath();
        bool CreateFile(BookingData data);
        bool CreateRoomFiles(Room roomData);
        void LoadRoomData(List<Room> _iroomsList);
    }
}
