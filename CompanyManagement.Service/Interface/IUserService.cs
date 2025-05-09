using CompanyManagement.Domain.Model;
using CompanyManagement.Domain.Model.Common;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using System.Collections.Generic;
using static Dto.Model.UserModel;

namespace CompanyManagement.Services.Service.Abstract
{
   public interface IUserService

	{

		//--------------------------------------------------------- Save Update user-------------------------------------
		Response SaveUpdate(UserBasic model, int actionBy);


        //--------------------------------------------------------Get All User Data by userViewModel (List)-----------------

        userViewModels Get();


		//----------------------------------------- Get Single User by UserID-------------------------------------------------------
		singleUserResponseModel GetSingle(int UserID);

		//--------------------------------------- Delete User Details-------------------------------------------------------
		Response Delete(int userId);


		

		//---------------------------------------upload Profile by profile ID---------------------------------------

		Response Upload(int profileid, string path, string msg);

		//--------------------------------------------Get User Type------------------------------------------------
		List<IDictionary<string, object>> GetUserType();


		//--------------------------------------------Get Address Type--------------------------------------------
		IEnumerable<AddressType> GetAddressType();


	

		//------------------------------------------ Delete Company by Company ID------------------------------------------------

		Response DeleteCompany(int companyID);

		UserBasic GetByUserId(int UserId);
		PaginatedResult<UserBasic> GetByUserTypeId(int UserTypeId, int limit = 10, int startingRow = 0);


    }
}
