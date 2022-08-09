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
        /* The Hotel Booking project is invoked on a mobile app (developed for Android for now). 
         * The user is asked to select the type of Room and the Book Now button navigates to another form page where the user is 
         * required to enter details like the dates for which booking is required, Name, Address, Credit Card details for payment.
         * Certain basic validations are built-in like email validations, number format validations for credit card details, etc.
         * Once the user clicks on the Confirm booking button, the app calculates the total amount that the user should pay
         * and reduces the total room availability. The booking details are written to a file and the room availability is updated 
         * for the type of room booked.
         * The Room details are loaded from the Assets file initially when the app starts
         **/
        
        //Rooms List that stores the Room attributes
        List<Room> _roomsList = new List<Room>();

        //Object of Room selected
        Room _room;

        public MainPage(string frPage)
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(frPage))
            {
                LoadRooms();            // This method will be call initially when the app is invoked since the parameter value will be null
            }
            else
            {
                //This method will be called after from the Booking Page with a parameter string
                DependencyService.Get<IFileService>().LoadRoomData(_roomsList);
            }
            roomSelect.ItemsSource = _roomsList;
        }

        //Method to add rooms to the List and update the picker with the available rooms
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

        //OnClick Method that will be navigate to the booking page 
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
