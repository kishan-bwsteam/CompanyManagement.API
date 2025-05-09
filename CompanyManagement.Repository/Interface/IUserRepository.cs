using CompanyManagement.Domain.Model;
using CompanyManagement.Domain.Model.Common;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Dto.Model.UserModel;

namespace CompanyManagement.Data.Datas.Abstract
{
   public interface IUserRepository

	{
		//---------------------------------------upload Profile by profile ID---------------------------------------

		Response Upload(int profileid, string path, string msg);

		//--------------------------------------------Get User Type------------------------------------------------
		List<IDictionary<string, object>> GetUserType();


		//--------------------------------------------Get Address Type--------------------------------------------
		IEnumerable<AddressType> GetAddressType();


		//--------------------------------------------------------- Save Update user-------------------------------------
		Response SaveOrUpdate(UserBasic model, int actionBy);



        //--------------------------------------------------------Get All User Data by userViewModel (List)-----------------

        userViewModels Get();

		//--------------------------------------- Delete User Details-------------------------------------------------------
		Response Delete(int userId);


		//----------------------------------------- Get Single User by UserID-------------------------------------------------------
		singleUserResponseModel GetSingle(int UserID);

		//------------------------------------------ Delete Company by Company ID------------------------------------------------

		Response DeleteCompany(int companyID);

        PaginatedResult<UserBasic> Get(DataTable filters, int limit, int startingRow);


    }
}
