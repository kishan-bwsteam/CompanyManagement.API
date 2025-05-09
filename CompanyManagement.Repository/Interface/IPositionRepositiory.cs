using Dto.Model;
using Dto.Responses;


namespace Datas.Abstract
{
    public interface IPositionRepositiory
    {




        //-----------------------------------------------------save update position---------------------------   
        PositionResponse Saveupdate(PositionModel model);

        //----------------------------------------Get All Postion by positionViewModels (List)----------------------------
        positionViewModels Get(int companyID);

        //----------------------------------------------Get Single Position RoleID----------------
        SinglePositionResponseModel GetSingle(int roleID);
        //-----------------------------------------------Delete Position Details by RoleID----------------------------------------------- 
        PositionResponse Delete(int roleId);
    }
}
