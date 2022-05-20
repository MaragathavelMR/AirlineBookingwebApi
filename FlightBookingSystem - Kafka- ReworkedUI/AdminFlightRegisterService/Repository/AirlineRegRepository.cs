using Microsoft.EntityFrameworkCore;
using SharedClassModels.DataModels;

namespace AdminFlightRegisterService.Repository
{
    public class AirlineRegRepository : IAirlineRegRepository
    {
        private readonly AirlineDBContext _dbContext;

        public AirlineRegRepository(AirlineDBContext dbContext)
        {
            _dbContext=dbContext; 
        }
        public int InsertAirline(TblAirlineRegister airlineRegister)
        {
            airlineRegister.RegBy = "Admin";
            _dbContext.TblAirlineRegisters.Add(airlineRegister);
            int IsSuccess = _dbContext.SaveChanges();
            return IsSuccess;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges(); 
        }

        public void UpdateAirlineStatus(TblAirlineRegister airlineRegister)
        {
            _dbContext.Entry(airlineRegister).State = EntityState.Modified;
            SaveChanges();
        }

    }
}
