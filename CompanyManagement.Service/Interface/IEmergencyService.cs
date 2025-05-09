using Dto.Model;
using Dto.Model.Common;

namespace Service.Abstract
{
    public interface IEmergencyService
    {


        //-----------------------------------------------save Update Emergency Details---------------------------------------
        Response SaveUpdate(EmergencyModel model);

        //--------------------------------- Get All Emergency Details by EmergencyModelView----------------------------------------
        EmergencyModelView GetAll(int userID);



        //----------------------------------------------Delete Emergency Details by emergency ID--------------------------------------------
        Response Delete(int emergencyID);

    }
}
