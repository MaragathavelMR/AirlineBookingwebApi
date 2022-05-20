using SharedClassModels.DataModels;
using System.Linq;

namespace AdminFlightRegisterService.Repository
{
    public class FlightRegRepository : IFlightRegRepository
    {

        private readonly AirlineDBContext _dbContext;
        public FlightRegRepository(AirlineDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteFlightDetails(TblFlightdetail flDetails)
        {
            var flightDet = _dbContext.TblFlightdetails.Find(flDetails);
            _dbContext.TblFlightdetails.Remove(flightDet);
            SaveFlightDetails();
        }

        public int InsertFlightDetails(TblFlightdetail flDetails)
        {
            var searchResults = _dbContext.TblAirlineRegisters.FirstOrDefault(u => u.AirlineName.Equals(flDetails.AirlineName) && u.IsActive.Equals("Active"));
            int IsSuccess = 0;
            if (searchResults == null)
            {
                return IsSuccess;
            }
            else
            {
                flDetails.AddedBy = "Admin";
                _dbContext.TblFlightdetails.Add(flDetails);
                IsSuccess=_dbContext.SaveChanges();
            }            
            return IsSuccess;
        }

        public void SaveFlightDetails()
        {
            _dbContext.SaveChanges();
        }
    }
}
