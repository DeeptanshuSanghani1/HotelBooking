using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace HotelBooking
{
    public class Room
    {
        //Creating variables for room properties
        private int _roomId;
        private string _roomType;
        private int _roomrate;
        private int _roomVacant;

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public string RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }

        public int Roomrate
        {
            get { return _roomrate; }
            set { _roomrate = value; }
        }

        public int Vacant
        {
            get { return _roomVacant; }
            set { _roomVacant = value; }
        }

        public Room() { }

        public Room(int roomID, string roomType, int roomRate, int roomVacant)
        {
            this._roomId = roomID;
            this._roomType = roomType;
            this._roomrate = roomRate;
            this._roomVacant = roomVacant;
        }
    }
}
