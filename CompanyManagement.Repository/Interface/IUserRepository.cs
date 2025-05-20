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


		//--------------------------------------------------------- Save Update user-------------------------------------
		Response SaveOrUpdate(UserBasic model, int actionBy);


		//--------------------------------------- Delete User Details-------------------------------------------------------
		Response Delete(int userId);


		//------------------------------------------ Delete Company by Company ID------------------------------------------------

		Response DeleteCompany(int companyID);

        PaginatedResult<UserBasic> Get(DataTable filters, int limit, int startingRow);


    }
}
