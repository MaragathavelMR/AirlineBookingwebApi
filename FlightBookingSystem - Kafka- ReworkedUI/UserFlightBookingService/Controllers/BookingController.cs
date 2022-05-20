using MassTransit;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SharedClassModels.CmnModels;
using SharedClassModels.DataModels;
using SharedClassModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using UserFlightBookingService.Models;

namespace UserFlightBookingService.Controllers
{
    [Route("api/v1.0/flight/[Controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IJWTManagerRepository _iJWTManager;
        //private readonly IAdminNUserRegister _adminNUserRegister;
        private readonly IGenerateBookingPnr _generateBookingPnr;
        private readonly AirlineDBContext _airlineDBContext;
        private ITopicProducer<TblBookingdetail> _topicProducer;
     
        public BookingController(IBookingRepository bookingRepository, IJWTManagerRepository iJWTManager, ITopicProducer<TblBookingdetail> topicProducer, IGenerateBookingPnr generateBookingPnr, AirlineDBContext airlineDBContext)
        {
            _bookingRepository = bookingRepository;
            _iJWTManager = iJWTManager;
            _topicProducer = topicProducer;
            _generateBookingPnr = generateBookingPnr;
            _airlineDBContext = airlineDBContext;
        }
        
        [HttpPost]
        [Route("BookTicketsQueue")]
        public async Task<IActionResult> BookTicketsQueue([FromBody] TblBookingdetail bookingdetail)
        {          
            int pnr = _generateBookingPnr.GeneratePnr();
            string pnrs = pnr.ToString();
            await _topicProducer.Produce(new TblBookingdetail
            {
                //TimingDetails = bookingdetail.TimingDetails,
                //FlightInfo = bookingdetail.FlightInfo,
                //FlightFrom = bookingdetail.FlightFrom,
                //FlightTo = bookingdetail.FlightTo,
                //Duration = bookingdetail.Duration,
                //Price = bookingdetail.Price,
                //Pnr = pnrs,
            });
            return Ok(pnr);
        }

        [HttpPost]
        [Route("BookTickets")]
        public IActionResult BookTickets([FromBody] BookingDetails[] bookingdetail)
        {
            try
            {
                string pnr = _bookingRepository.InsertBookings(bookingdetail);
                return Ok(new {response="Your Flight Has been booked sucessfully...!!! & PNR:"+pnr});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost]
        [Route("SearchFlights")]
        public IActionResult SearchFlights([FromBody] SearchFlightDetails searchDet)
        {
            try
            {
                var searchResults = _bookingRepository.SearchFlights(searchDet);

                if (searchResults.ToList().Count != 0)
                {
                    return Ok(searchResults.ToList());
                }
                else
                {
                    return NotFound("No data found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }

        }       
    
        [HttpGet]
        [Route("ticketdetails/{pnr}")]
        public IActionResult GetHistorybypnr(int pnr)
        {
            try
            {
                TblBookingdetail details = _airlineDBContext.TblBookingdetails.ToList().Find(m => m.Pnr == pnr);
                if (details != null)
                {
                    IEnumerable<TblBookingdetail> bookingDetails = _airlineDBContext.TblBookingdetails.ToList().Where(m => m.Pnr == pnr);
                    IEnumerable<TblPassengerList> passengerLists = _airlineDBContext.TblPassengerLists.ToList().Where(m => m.Pnr == pnr);
                    IEnumerable<TblUserdetail> userdetails = _airlineDBContext.TblUserdetails.ToList().Where(m => m.UserId == bookingDetails.FirstOrDefault().UserId);

                    var result = (from p in passengerLists
                                  join t in bookingDetails on p.Pnr equals t.Pnr
                                  join c in userdetails on t.UserId equals c.UserId
                                  where t.Pnr == pnr && t.Status == "Confirmed"
                                  select new
                                  {
                                      t.Pnr,c.UserName,t.FlightNo,p.PsngrName,p.PsngrAge,p.PsngrGender,p.IsMealOpted,                                    
                                      t.DepartureTime,t.IsOneWay,t.ArrivalTime,t.NoofPassengers,p.Price,p.Status
                                  }).ToList();
                    return Ok(result);
                }
                return NotFound("Record not Found for given PNR.. Please enter valid one.!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("history/{email}")]
        public IActionResult GethistorybyEmail(string email)
        {
            try
            {
                IEnumerable<TblUserdetail> userdetails = _airlineDBContext.TblUserdetails.ToList().Where(m => m.EmailId == email);
                IEnumerable<TblBookingdetail> bookingDetails = _airlineDBContext.TblBookingdetails.ToList().Where(m => m.UserId == userdetails.FirstOrDefault().UserId);
                IEnumerable<TblPassengerList> passengerLists = _airlineDBContext.TblPassengerLists.ToList().Where(m => m.Pnr == bookingDetails.FirstOrDefault().Pnr);

                var result = (from p in passengerLists
                              join t in bookingDetails on p.Pnr equals t.Pnr
                                  join c in userdetails on t.UserId equals c.UserId
                                  where c.EmailId==email
                                  select new
                                  {
                                      t.Pnr,c.UserName,t.FlightNo,p.PsngrName,p.PsngrAge,p.PsngrGender,p.IsMealOpted,
                                      t.DepartureTime,t.IsOneWay,t.ArrivalTime,t.NoofPassengers,p.Price,p.Status
                                  }).ToList();
                    return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("cancel/{pnr}")]
        public IActionResult delete(int pnr)
        {
            try 
            {
                var IsBookingCancelled = _bookingRepository.CancelBookings(pnr);
                    if (IsBookingCancelled)
                    {
                var message = "Booking for PNR No: " + pnr + " is cancelled successfully";
                return Accepted(message);
                    }   
                    else
                    {
                return NotFound("No records found with PNR: " + pnr);
                    }
             }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }
        }   
 
    }
}

