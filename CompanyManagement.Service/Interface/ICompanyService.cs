
using Dto.Model;
using Dto.Model.Common;
using System.Collections.Generic;
using System.Data;

namespace Service.Abstract
{
    public interface ICompanyService
    {
        //DropdownListModel GetAllCompany(int userId);

        //---------------------------------Get All Company By UserID & CompanyID--------------------------------
        //DropdownListModel Get(int userId, int companyID);
        //---------------------------------Get All Company By UserID--------------------------------
        //DropdownListModel GetAll(int userID);

        //---------------------------- Save Update Company -----------------------------
        CompanyModel GetSingle(int companyId);

        IEnumerable<CompanyModel> Get(int UserId, int limit = 10, int startingRow = 0);

        Response SaveUpdate(CompanyModel model);

        //--------------------- Delete Company by Company Id----------------------
        Response Delete(int companyID);
    }
}
