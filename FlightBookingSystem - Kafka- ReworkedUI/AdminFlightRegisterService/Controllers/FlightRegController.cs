using AdminFlightRegisterService.Repository;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedClassModels.DataModels;
using SharedClassModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace AdminFlightRegisterService.Controllers
{
    [Route("api/v1.0/[Controller]")]
    [ApiController]
    public class FlightRegController : ControllerBase
    {
        private readonly IFlightRegRepository _flightRegRepository;
        private readonly IAirlineRegRepository _airlineRegRepository;
        private readonly IJWTManagerRepository _iJWTManager;
        private readonly AirlineDBContext _airlineDBContext;
        private ITopicProducer<TblAirlineRegister> _topicProducer; 
        public FlightRegController(IFlightRegRepository flightRegRepository, IAirlineRegRepository airlineRegRepository, IJWTManagerRepository iJWTManager, AirlineDBContext airlineDBContext, ITopicProducer<TblAirlineRegister> topicProducer)
        {
            _flightRegRepository = flightRegRepository;
            _airlineRegRepository = airlineRegRepository;
            _iJWTManager = iJWTManager;
            _airlineDBContext = airlineDBContext;
            _topicProducer = topicProducer;
        }  

        [Route("AirlinesList")]
        [HttpGet]
        public List<TblAirlineRegister> GetAllAirlines()
        {
            return _airlineDBContext.TblAirlineRegisters.ToList();
        }

        [Route("FlightList")]
        [HttpGet]
        public List<TblFlightdetail> GetAllFlights()
        {
            return _airlineDBContext.TblFlightdetails.ToList();
        }
    
        [HttpPost]
        [Route("airline/add")]
        public IActionResult Post([FromBody] TblFlightdetail flDetails)
        {
            try
            {
                int isFlightAddedSuccessfully = _flightRegRepository.InsertFlightDetails(flDetails); 

                if (isFlightAddedSuccessfully > 0)
                {
                    return Ok(new { response = "Flight Added Successfully" });
                }
                else
                {
                    return Ok(new { response = "Flight Could not be added in inventory... Invalid/Inactive" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }

        //[HttpPost]
        //[Route("airline/Register")]
        //public IActionResult Post([FromBody] TblAirlineRegister airline)
        //{
        //    try
        //    {
        //        int isFlightAddedSuccessfully = _airlineRegRepository.InsertAirline(airline);

        //        if (isFlightAddedSuccessfully > 0)
        //        {
        //            return Ok(new { response = "Airline Registration succesfull" });
        //        }
        //        else
        //        {
        //            return BadRequest("Airline Registration Failed..!!!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
        //    }
        //}

        [HttpPost]
        [Route("airline/Register")]
        public async Task<IActionResult> Post([FromBody] TblAirlineRegister airline)
        {
            try
            {
                await _topicProducer.Produce(new TblAirlineRegister
                {
                    AirlineName = airline.AirlineName,
                    RegOn = airline.RegOn,
                    RegBy = "Admin",
                    IsActive = airline.IsActive,
                    Remarks = airline.Remarks,                   
                });
                return Ok(new { response = "Airline Registration succesfull" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }

        [HttpPut]        
        public IActionResult Put([FromBody] TblAirlineRegister airline)
        {
            if (airline != null)
            {
                using (var scope = new TransactionScope())
                {
                    _airlineRegRepository.UpdateAirlineStatus(airline);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
    }
}
