using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking
{
    public class BookingData
    {
        private int _roomidBooked;
        private string _fromDate;
        private string _toDate;
        private string _fName;
        private string _lName;
        private string _email;
        private string _streetName;
        private string _city;
        private string _province;
        private string _zipCode;
        private string _creditcardno;
        private string _expdate;
        private int _cvv;
        private double _daysBooked;
        private double _totAmount;

        public int RoomidBooked { get { return _roomidBooked; } set { _roomidBooked = value; } }

        public string FromDate { get { return _fromDate; } set { _fromDate = value; } }

        public string ToDate { get { return _toDate; } set { _toDate = value; } }

        public string FName { get { return _fName; } set { _fName = value; } }

        public string LName { get { return _lName; } set { _lName = value; } }

        public string Email { get { return _email; } set { _email = value; } }

        public string StreetName { get { return _streetName; } set { _streetName = value; } }

        public string City { get { return _city; } set { _city = value; } }

        public string Province { get { return _province; } set { _province = value; } }

        public string ZipCode { get { return _zipCode; } set { _zipCode = value; } }

        public string CreditCardNo { get { return _creditcardno; } set { _creditcardno = value; } }

        public string Expdate { get { return _expdate; } set { _expdate = value; } }

        public int Cvv { get { return _cvv; } set { _cvv = value; } }

        public double DaysBooked { get { return _daysBooked; } set { _daysBooked = value; } }

        public double TotAmount { get { return _totAmount; } set { _totAmount = value; } }

        public BookingData() { }

        public BookingData(int roomIdBooked, string fromDate, string toDate, string fName, string lName, string email, string streetName, string city, string province, string zipCode, string creditcardno, string expdate, int cvv, double daysbooked, double totamount)
        {
            this._roomidBooked = roomIdBooked;
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._fName = fName;
            this._lName = lName;
            this._email = email;
            this._streetName = streetName;
            this._city = city;
            this._province = province;
            this._zipCode = zipCode;
            this._creditcardno = creditcardno;
            this._expdate = expdate;
            this._cvv = cvv;
            this._daysBooked = daysbooked;
            this._totAmount = totamount;
        }
    }
}
