using SharedClassModels.DataModels;
using System.Collections.Generic;

namespace SharedClassModels.ViewModels
{
    public interface IJWTManagerRepository
    {
        TokenDetails Authenticate(TblUserdetail users);

        //TokenDetails AdminAuthenticate(TblAdminDetail users);
        int RegisterUser(TblUserdetail users);

        List<string> Login(TblUserdetail users);
    }
}
