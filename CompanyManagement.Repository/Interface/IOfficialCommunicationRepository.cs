
using Dto.Responses;


namespace Datas.Abstract
{
  public   interface IOfficialCommunicationRepository
    {

        ////--------------------------------------------Save Upadte Offical information----------------------

        //OfficalCommResponse SaveUpdate(OfficalCommModel model);

        ////------------------------------------------- Get All offical Communication by OfficalViewModel--------------
        //OfficalViewModel Get();

        //------------------------------------------- Get SaveUpdate Other-----------------------------------------
        OfficalCommResponse SaveUpdate(OfficialOtherModel model);

        //----------------------------------------Get AllOthers Details-----------------------------------------
        OfficalOtherModelList Get();

        //-----------------------------------------------------Delete Offical Details by OfficalID--------------------------------
        OfficalCommResponse Delete(int OfficalID);
    }
    
}
