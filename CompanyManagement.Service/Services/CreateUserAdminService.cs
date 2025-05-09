using Authentication.DataManager.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class CreateUserAdminService : ICreateUserAdminService
    {
        EncryptHelperObj obj = new EncryptHelperObj();
        private readonly ICreateUserAdminRepository _icreateUserAdminRepository;

        public CreateUserAdminService(ICreateUserAdminRepository _createUserAdminRepository)

        {
            _icreateUserAdminRepository = _createUserAdminRepository;
        }



		//----------------------------Save Update Admin User-------------------------------------



        public Response SaveUpdate(CreateUserAdminModel model)
        {
            try
            {

                return _icreateUserAdminRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


		//------------------------- Admin User by createViewUserAdminModel (list)------------------------ 


		public createViewUserAdminModel GetAll()
		{
			try
			{
				return _icreateUserAdminRepository.GetAll();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		//-------------------------------Single user Get by userID--------------------------------


		public singlecreateViewUserAdminModel GetSingle(int userID)
		{
			try
			{
				return _icreateUserAdminRepository.GetSingle(userID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		//--------------------------------Delete User by UserID-------------------------------------------



		public Response Delete(int userID)
		{
			try
			{
				return _icreateUserAdminRepository.Delete(userID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
