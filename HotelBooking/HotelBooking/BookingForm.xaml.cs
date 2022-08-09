using HotelBooking.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelBooking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingForm : ContentPage
    {
        Room b_room;

        public BookingForm(Room roomselected)
        {
            b_room = roomselected;

            InitializeComponent();
            roomlbl.Text = roomselected.RoomType + " (Available: " + roomselected.Vacant + ")";
            StDate.MinimumDate = DateTime.Today;
        }

        /*The Save Booking method will be invoked on click of Confirm Booking. 
         *It will validate each field and add the data to the booking object. Once all fields are validated
         *The dependency service will be called to write the data to a file. The data is converted to a Json object
         *and written to a file. After the file writting is successful, the application navigates back to the Main Page.*/
        public async void SaveBooking(object sender, EventArgs args)
        {
            BookingData data = new BookingData();
            bool validdata = true;

            data.RoomidBooked = b_room.RoomId;
            data.FromDate = StDate.Date.ToString();
            data.ToDate = EndDate.Date.ToString();

            try
            {
                if (!ValidateData(FirstName.Text))
                    data.FName = FirstName.Text;
                else
                {
                    FirstName.Placeholder = "First Name should be Entered";
                    FirstName.PlaceholderColor = Color.Red;
                    validdata = false;
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (!ValidateData(LastName.Text))
                    data.LName = LastName.Text;
                else
                {
                    LastName.Placeholder = "Last Name should be Entered";
                    LastName.PlaceholderColor = Color.Red;
                    validdata = false;
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            data.Email = email.Text;
            data.StreetName = StreetName.Text;
            data.City = City.Text;
            data.Province = Province.Text;
            data.ZipCode = Zip.Text;

            try
            {
                if (!ValidateData(CardNo.Text))
                    data.CreditCardNo = CardNo.Text;
                else
                {
                    CardNo.Placeholder = "Credit Card Number is required";
                    CardNo.PlaceholderColor = Color.Red;
                    validdata = false;
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (!ValidateData(ExpDate.Text))
                    data.Expdate = ExpDate.Text;
                else
                {
                    ExpDate.Placeholder = "Expiry Date must be entered";
                    ExpDate.PlaceholderColor = Color.Red;
                    validdata = false;
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (!ValidateData(CVV.Text))
                    data.Cvv = Convert.ToInt32(CVV.Text);
                else
                {
                    CVV.Placeholder = "Please enter CVV";
                    CVV.PlaceholderColor = Color.Red;
                    validdata = false;
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (validdata)
                {
                    data.DaysBooked = (EndDate.Date - StDate.Date).TotalDays;

                    data.TotAmount = data.DaysBooked * b_room.Roomrate;
                    b_room.Vacant--;

                    if (DependencyService.Get<IFileService>().CreateFile(data) && DependencyService.Get<IFileService>().CreateRoomFiles(b_room))
                    {
                        await DisplayAlert("Booking Confirmation !!", "Total number of days booked: " + data.DaysBooked +
                            " Total Amount that will be charged to your Credit Card: " + data.TotAmount, "Ok");
                        await Navigation.PushAsync(new MainPage("BookingPage"));
                    }
                }
                else
                    await DisplayAlert("Failed !!", "Please resolve errors before saving", "Ok");
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        //If the user clicks on the Cancel button, the system will go back to the Main Page without any booking.
        public async void GoToMainPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage("BookingPage"));
        }

        private void OnDateSelected(object sender, EventArgs args)
        {
            EndDate.MinimumDate = StDate.Date;
        }

        //Method to Validate Mandatory fields
        public bool ValidateData(string chkFld)
        {
            return String.IsNullOrEmpty(chkFld);
        }

        //Method to validate the credit card number entered is 16 digits.
        public async void OnCheckCard(object sender, EventArgs args)
        {
            string cardnumber = sender as string;
            if (cardnumber.Length != 16)
            {
                await DisplayAlert("Error !!", "Card Number must be 16 digits", "Ok");
            }
        }
    }
}