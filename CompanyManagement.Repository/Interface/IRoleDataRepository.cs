using BussinessObject;
using Dto.Responses;


namespace Datas.Abstract
{
 public interface IRoleDataRepository
       {
        //----------------------------------- Save Update Role --------------------------
        RoleResponse SaveUpdate(RoleModel model, int ActionBy);


        //----------------------------------- Get All  Role Data by roleViewModels ---------------------
        roleViewModels Get(int userID);

        //-----------------------------------Get Single Role by RoleID--------------------------------
        SingleRoleResponseModel GetSingle(int RoleID);

        //-------------------------------------Delete by RoleID-----------------------------------
        RoleResponse Delete(int roleId);

    }
}
