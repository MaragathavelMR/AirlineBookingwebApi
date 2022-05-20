using SharedClassModels.DataModels;


namespace AdminFlightRegisterService
{
    public interface IFlightRegRepository
    {
        int InsertFlightDetails(TblFlightdetail flDetails);

        void DeleteFlightDetails(TblFlightdetail flDetails);

        void SaveFlightDetails();
    }
}
