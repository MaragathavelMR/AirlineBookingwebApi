using SharedClassModels.DataModels;
using SharedClassModels.ViewModels;
using System.Collections.Generic;
using UserFlightBookingService.Models;

namespace UserFlightBookingService
{
    public interface IBookingRepository
    {      
        string InsertBookings(BookingDetails[] bookingdetails);

        IEnumerable<TblFlightdetail> SearchFlights(SearchFlightDetails searchDet);        

        //commenting Pasenger insert as booking details itself perform d action
        //void InsertPassengerDetails(List<TblPassengerList> passengerdetails);

        bool CancelBookings(int pnr);

        //void ViewBookings(string pnr);

        //TblBookingdetail ViewBookings(string emailid);

        void Save();
    }
}
