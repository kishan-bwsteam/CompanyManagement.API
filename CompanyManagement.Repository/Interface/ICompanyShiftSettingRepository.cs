using System;
using System.Collections.Generic;
using System.Text;
using Dto.Model.Common;

namespace Datas.Abstract
{
    public interface ICompanyShiftSettingRepository
    {


        //--------------------------------Save Update Company Shift------------------------------------
        Response SaveUpdate(ShiftSettingModel modal);
        
        
        //----------------------Get All Company Shift By CompanyID----------------------------------


        ShiftSettingViewModel Get(int companyID);

        //-----------------------------------Delete Shift by Shift ID-------------------------------------
        Response Delete(int shiftID);

        
        SingleShiftSettingModel GetSingle(int CompanyId,int ShiftID);


    }
}
