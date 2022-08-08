using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelBooking
{
    public partial class MainPage : ContentPage
    {
        //Create a List of all Rooms
        List<Room> _roomsList = new List<Room>();
        Room _room;

        public MainPage()
        {
            InitializeComponent();
            CreateRooms();        //Method to add rooms to the List and update the picker with the available rooms
        }

        public void CreateRooms()
        {
            _roomsList.Clear();

            _roomsList.Add(new Room
            {
                RoomId = 1,
                RoomType = "Single Room",
                Roomrate = 65,
                Vacant = 25
            });

            _roomsList.Add(new Room
            {
                RoomId = 2,
                RoomType = "Double Room",
                Roomrate = 95,
                Vacant = 25
            });

            _roomsList.Add(new Room
            {
                RoomId = 3,
                RoomType = "Twin Room",
                Roomrate = 85,
                Vacant = 10
            });

            _roomsList.Add(new Room
            {
                RoomId = 4,
                RoomType = "Triple Room",
                Roomrate = 125,
                Vacant = 10
            });
            _roomsList.Add(new Room
            {
                RoomId = 5,
                RoomType = "Quad Room",
                Roomrate = 185,
                Vacant = 5
            });
            _roomsList.Add(new Room
            {
                RoomId = 6,
                RoomType = "Delux Room",
                Roomrate = 200,
                Vacant = 5
            });
            roomSelect.ItemsSource = _roomsList;
        }

        private async void GoToBookingPage(object sender, EventArgs e)
        {
            _room = roomSelect.SelectedItem as Room;
            //await Navigation.PushAsync(new BookingForm(_room));
        }
    }
}
