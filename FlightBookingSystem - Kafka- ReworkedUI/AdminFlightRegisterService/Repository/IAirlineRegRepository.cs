using SharedClassModels.DataModels;

namespace AdminFlightRegisterService.Repository
{
    public interface IAirlineRegRepository
    {
        int InsertAirline(TblAirlineRegister airlineRegister);

        void UpdateAirlineStatus(TblAirlineRegister airlineRegister);

        void SaveChanges();
    }
}
