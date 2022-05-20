using SharedClassModels.CmnModels;
using SharedClassModels.DataModels;
using SharedClassModels.ViewModels;
using System.Collections.Generic;
using System.Linq;
using UserFlightBookingService.Models;

namespace UserFlightBookingService.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AirlineDBContext _dbContext;

        public BookingRepository(AirlineDBContext Dbcontext)
        {
                _dbContext= Dbcontext;
        }
        public bool CancelBookings(int pnr)
        {
            var bookings = _dbContext.TblBookingdetails.FirstOrDefault(p => p.Pnr == pnr);
            _dbContext.TblBookingdetails.Remove(bookings);
            Save();
            //_dbContext.TblBookingdetails.Remove((TblBookingdetail)resultBookingDetails);

            var resultUserBookingDetails = _dbContext.TblPassengerLists.FirstOrDefault(p => p.Pnr == pnr);
            _dbContext.TblPassengerLists.Remove(resultUserBookingDetails);
            Save();
            //_dbContext.TblPassengerLists.Remove((TblPassengerList)resultUserBookingDetails);

            return true;
        }

        public string InsertBookings(BookingDetails[] bookinginputdetails)
        {
            //     
            //Save();
            TblBookingdetail bookingDetail = new TblBookingdetail();
            GenerateBookingPnr pnrobj = new GenerateBookingPnr();
            int noOfSeats = 0;

            foreach (var itemBookingInputDetails in bookinginputdetails)
            {
                bookingDetail.Pnr= pnrobj.GeneratePnr();
                bookingDetail.UserId = itemBookingInputDetails.UserId;
                bookingDetail.FlightNo = itemBookingInputDetails.FlightNo;
                bookingDetail.NoofPassengers = noOfSeats=itemBookingInputDetails.TblPassengerDetails.Length;
                bookingDetail.DepartureTime = itemBookingInputDetails.DepartureDateTime;
                bookingDetail.IsOneWay = "One Way";
                bookingDetail.ArrivalTime = itemBookingInputDetails.ReturnDateTime;
                bookingDetail.Status = "Confirmed";
                bookingDetail.BookedBy =itemBookingInputDetails.UserId.ToString();

                _dbContext.TblBookingdetails.Add(bookingDetail);
                Save();

                //Insert data into tblPassengerDetails table (Includes passenger wise details)
                foreach (var item in itemBookingInputDetails.TblPassengerDetails)
                {
                    item.Pnr = bookingDetail.Pnr;                  
                    item.BookedBy = itemBookingInputDetails.UserId.ToString();
                    item.Status = "Confirmed";
                    item.IsMealOpted = "Yes";

                    _dbContext.TblPassengerLists.Add(item);
                    Save();
                }
            }

            TblFlightdetail flightDetails = _dbContext.TblFlightdetails
                .FirstOrDefault(m => m.FlightNo == bookingDetail.FlightNo
                && m.DepartureDetails == bookingDetail.DepartureTime
                );
            flightDetails.AvailableSeats = flightDetails.AvailableSeats - noOfSeats;
            //_context.TblFlightMasters.Add(flightDetails);
            _dbContext.SaveChanges();

            return bookingDetail.Pnr.ToString();
        }

 
        //Not used
        //public void InsertPassengerDetails(List<TblPassengerList> passengerList)
        //{
        //    //_dbContext.TblPassengerLists.Add(passengerdetails);
        //    if (passengerList != null)
        //    {
        //        foreach (var passenger in passengerList)
        //        {
        //            _dbContext.TblPassengerLists.Add(passenger);
        //        }
        //    }
        //    Save();
        //}  

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<TblFlightdetail> SearchFlights(SearchFlightDetails searchDet)
        {

            IEnumerable<TblFlightdetail> searchResults = _dbContext.TblFlightdetails.ToList()
                                                        .Where(m => m.FromPlace == searchDet.FromLocation
                                                                 && m.ToPlace == searchDet.ToLocation
                                                                 && m.DepartureDetails.ToString("yyyy-MM-dd") == searchDet.DepartureDate
                                                                );



            return searchResults;
        }

        //Not used
        //public List<TblBookingdetail> ViewBookings(string pnr)
        //{
        //    List<TblBookingdetail> bookings = _dbContext.TblBookingdetails.ToList();
        //    if (bookings!=null)
        //    {
        //        return bookings;    
        //    }
        //    else
        //        return null;
        //}
    }
}
