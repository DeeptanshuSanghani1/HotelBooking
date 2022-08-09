using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using HotelBooking.Interface;


namespace HotelBooking
{
    public partial class MainPage : ContentPage
    {
        //Create a List of all Rooms
        List<Room> _roomsList = new List<Room>();
        Room _room;

        public MainPage(string frPage)
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(frPage))
            {
                LoadRooms();            //Method to add rooms to the List and update the picker with the available rooms
            }
            else
            {
                DependencyService.Get<IFileService>().LoadRoomData(_roomsList);
            }
            roomSelect.ItemsSource = _roomsList;
        }

        private async void LoadRooms()
        {
            string[] templateFileName = new string[] { "Singleroom.txt", "Doubleroom.txt", "Twinroom.txt","Tripleroom.txt","Quadroom.txt","Duplexroom.txt"};

            try
            {
                for(int i = 0; i < templateFileName.Count(); i++)
                {
                    using (var stream = await FileSystem.OpenAppPackageFileAsync(templateFileName[i]))
                    {
                        using (var rd = new StreamReader(stream))
                        {
                            _roomsList.Add(new Room
                            {
                                RoomId = Convert.ToInt32(rd.ReadLine()),
                                RoomType = rd.ReadLine(),
                                Roomrate = Convert.ToInt32(rd.ReadLine()),
                                Vacant = Convert.ToInt32(rd.ReadLine())
                            });
                            DependencyService.Get<IFileService>().CreateRoomFiles(_roomsList[i]);
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        private async void GoToBookingPage(object sender, EventArgs e)
        {
            _room = roomSelect.SelectedItem as Room;
            await Navigation.PushAsync(new BookingForm(_room));
        }

        public void OnImageTapped(object sender, EventArgs args)
        {
            Image imgSender = (Image)sender;

            imgSender.AnchorX = 150;
            imgSender.AnchorY = 150;
        }
    }
}
