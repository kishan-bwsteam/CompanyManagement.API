using Dto.Model;
using Dto.Model.Common;
using System.Data;

namespace Datas.Abstract
{
    public interface ICompanyRepository
    {
        //DropdownListModel GetAllCompany(int companyId);
        //---------------------------------Get All Company By UserID & CompanyID--------------------------------
        IEnumerable<CompanyModel> Get(DataTable filters, int limit, int startingRow);
        DropdownListModel Get(int companyID);
        //---------------------------------Get All Company By UserID--------------------------------
        DropdownListModel GetAll(int userID);

        //---------------------------- Save Update Company -----------------------------
        Response SaveUpdate(CompanyModel model);


        //--------------------- Delete Company by Company Id----------------------
        Response Delete(int companyID);
    }
}
