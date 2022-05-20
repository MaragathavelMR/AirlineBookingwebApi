using SharedClassModels.DataModels;
using System;

namespace UserFlightBookingService.Models
{
    public class BookingDetails
    {
        public int UserId { get; set; }
        public string FlightNo { get; set; }
        public int NoOfPassengers { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string IsOneWay { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public TblPassengerList[] TblPassengerDetails { get; set; }
    }
}
