using BussinessObject;
using Dto.Responses;


namespace Service.Abstract
{
    public interface IRoleService
    {
        RoleResponse SaveUpdate(RoleResponse model);
        roleViewModels Get(int userID);
        SingleRoleResponseModel GetSingle(int roleID);
        RoleResponse Delete(int roleId);
    }
}
