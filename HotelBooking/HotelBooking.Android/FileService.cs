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
    }
}