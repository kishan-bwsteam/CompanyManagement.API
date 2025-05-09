using Dto.Model;
using Dto.Model.Common;


namespace Datas.Abstract
{
    public interface IEmergencyRepository
    {
        //-----------------------------------------------save Update Emergency Details---------------------------------------
        Response SaveUpdate(EmergencyModel model);

        //--------------------------------- Get All Emergency Details by EmergencyModelView----------------------------------------
        EmergencyModelView GetAll(int userID);



        //----------------------------------------------Delete Emergency Details by emergency ID--------------------------------------------
        Response Delete(int emergencyID);
    }
}
