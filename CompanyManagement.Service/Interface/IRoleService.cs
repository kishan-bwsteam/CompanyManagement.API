using BussinessObject;
using Dto.Responses;


namespace Service.Abstract
{
    public interface IRoleService
    {
        RoleResponse SaveUpdate(RoleModel model,int ActionBy);
        roleViewModels Get(int userID);
        SingleRoleResponseModel GetSingle(int roleID);
        RoleResponse Delete(int roleId);
    }
}
