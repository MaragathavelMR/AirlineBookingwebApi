using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClassModels.ViewModels
{
    public class SearchFlightDetails
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public int NoOfPassengers { get; set; }

    }
}

