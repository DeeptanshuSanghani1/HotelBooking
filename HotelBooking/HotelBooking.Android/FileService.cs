using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelBooking.Droid;
using HotelBooking.Interface;
using System.IO;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace HotelBooking.Droid
{
    public class FileService : IFileService
    {
        public string GetRootPath()
        {
            return Application.Context.GetExternalFilesDir(null).ToString();
        }

        public bool CreateFile(BookingData data)
        {
            string fileName = "Booking.txt";
            string jsondata = JsonConvert.SerializeObject(data);

            string destination = Path.Combine(GetRootPath(), fileName);

            File.WriteAllText(destination, jsondata);

            return true;
        }

        public bool CreateRoomFiles(Room roomData)
        {
            string destFileName = roomData.RoomType + ".txt";

            string roomDestination = Path.Combine(GetRootPath(), destFileName);

            string[] contentToWrite = { roomData.RoomId.ToString(), roomData.RoomType, roomData.Roomrate.ToString(), roomData.Vacant.ToString() };
            File.WriteAllLines(roomDestination, contentToWrite);
            return true;
        }

        public void LoadRoomData(List<Room> _iroomsList)
        {
            string dataPath = GetRootPath();

            DirectoryInfo dInfo = new DirectoryInfo(dataPath);

            FileInfo[] roomFiles = dInfo.GetFiles("*.txt");
            
            foreach(FileInfo roomFile in roomFiles)
            {
                if (roomFile.Name != "Booking.txt")
                {
                    StreamReader sr = new StreamReader(roomFile.FullName);

                    _iroomsList.Add(new Room()
                    {
                        RoomId = Convert.ToInt32(sr.ReadLine()),
                        RoomType = sr.ReadLine(),
                        Roomrate = Convert.ToInt32(sr.ReadLine()),
                        Vacant = Convert.ToInt32(sr.ReadLine()),
                    });
                }
            }

        }
    }
}