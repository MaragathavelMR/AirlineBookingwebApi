using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblFlightdetail
    {
        public int FlightId { get; set; }
        public string FlightNo { get; set; }
        public string AirlineName { get; set; }
        public string FlightName { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime DepartureDetails { get; set; }
        public DateTime ArrivalDetails { get; set; }
        public int AvailableSeats { get; set; }
        public string SchldDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int? TicketFare { get; set; }
        public string MealOption { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
    }
}
