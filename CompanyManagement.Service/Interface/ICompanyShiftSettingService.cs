using Dto.Model.Common;
 

namespace Service.Abstract
{
    public interface ICompanyShiftSettingService
    {

        //--------------------------------Save Update Company Shift------------------------------------
        Response SaveUpdate(ShiftSettingModel modal);


        //----------------------Get All Company Shift By CompanyID----------------------------------


        ShiftSettingViewModel Get(int companyID);

        //-----------------------------------Delete Shift by Shift ID-------------------------------------
        Response Delete(int shiftID);


        SingleShiftSettingModel GetSingle(int companyID, int ShiftID);
      
      

    }

}
