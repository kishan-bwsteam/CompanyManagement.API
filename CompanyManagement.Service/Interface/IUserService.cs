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


		//--------------------------------------- Delete User Details-------------------------------------------------------
		Response Delete(int userId);


		

		//---------------------------------------upload Profile by profile ID---------------------------------------

		Response Upload(int profileid, string path, string msg);


		Response DeleteCompany(int companyID);

		UserBasic GetByUserId(int UserId);
		PaginatedResult<UserBasic> GetByUserTypeId(int UserTypeId, int limit = 10, int startingRow = 0);


    }
}
