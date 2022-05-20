using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblBookingdetail
    {
        public int Id { get; set; }
        public int? Pnr { get; set; }
        public int UserId { get; set; }
        public string FlightNo { get; set; }
        public int? NoofPassengers { get; set; }
        public string IsOneWay { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime BookedOn { get; set; }
        public string BookedBy { get; set; }
        public string Status { get; set; }
    }
}
