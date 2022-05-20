using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblPassengerList
    {
        public int PsngrId { get; set; }
        public int? Pnr { get; set; }
        public string PsngrName { get; set; }
        public int? PsngrAge { get; set; }
        public string PsngrGender { get; set; }
        public string PsngrSeatNo { get; set; }
        public string IsMealOpted { get; set; }
        public int? Price { get; set; }
        public string BookedBy { get; set; }
        public DateTime BookedOn { get; set; }
        public string Status { get; set; }
    }
}
