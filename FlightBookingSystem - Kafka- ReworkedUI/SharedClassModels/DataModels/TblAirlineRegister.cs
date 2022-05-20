using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblAirlineRegister
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string RegOn { get; set; }
        public string RegBy { get; set; }
        public string IsActive { get; set; }
        public string Remarks { get; set; }
    }
}
