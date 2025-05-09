using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IPositionService
    {
        //-----------------------------------------------------save update position---------------------------   
        PositionResponse Saveupdate(PositionModel model);

        //----------------------------------------Get All Postion by positionViewModels (List)----------------------------
        positionViewModels Get(int companyID);

        //----------------------------------------------Get Single Position by RoleID----------------
        SinglePositionResponseModel GetSingle(int roleID);


        //-----------------------------------------------Delete Position Details by RoleID----------------------------------------------- 
        PositionResponse Delete(int roleId);
    }
}
