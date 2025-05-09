using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datas.Abstract
{
   public interface IShiftRulesRepository
    {
        //---------------------------- Save And Update Shift---------------------------- 
        Response SaveUpdate(ShiftRulesModel modal);

        //---------------------------- Get Single Shift Rule shiftRuleId---------------------------- 
        ShiftRulesModel GetSingle(int shifRuleId);

        //-------------------------- Delete Shift By shiftRuleId-----------------
        Response Delete(int shifRuleId);

        //--------------------------- Get All Shift By AllShiftRulesModel-----------------

        AllShiftRulesModel GetAll();
    }
}
