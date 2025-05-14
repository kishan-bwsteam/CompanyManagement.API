using Authentication.DataManager.Helper;
using BussinessObject;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Responses;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


namespace Service.Concrete
{
    public class RoleService : IRoleService
    {

        EncryptHelperObj obj = new EncryptHelperObj();

        private readonly IRoleDataRepository _iroleDataRepository;

        public RoleService(IRoleDataRepository _roleDataRepository)
        {
            this._iroleDataRepository = _roleDataRepository; 
        }

        //----------------------------------- Save Update Role --------------------------

        public RoleResponse SaveUpdate(RoleModel model, int ActionBy)
        {
            try
            {
                return _iroleDataRepository.SaveUpdate(model, ActionBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //----------------------------------- Get All  Role Data by roleViewModels ---------------------
        public roleViewModels Get(int userID)
        {
            try
            {
                return _iroleDataRepository.Get( userID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //-----------------------------------Get Single Role by RoleID--------------------------------


        public SingleRoleResponseModel GetSingle(int roleID)
        {
            try
            {
                return _iroleDataRepository.GetSingle(roleID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //-------------------------------------Delete by RoleID-----------------------------------


        public RoleResponse Delete(int roleId)
        {
            try
            {
                return _iroleDataRepository.Delete(roleId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

}