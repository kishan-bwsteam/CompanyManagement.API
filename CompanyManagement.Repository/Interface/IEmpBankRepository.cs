using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using System.Data;


namespace Datas.Abstract
{
  public   interface IEmpBankRepository
    {
        // -----------------------------Save And Update Bank Details------------------------ 
        Response SaveOrUpdate(UserBankDetail model, int actionBy);


        //----------------------------Get all Bank Details by BankModeltModels-------------------
        BankViewModels GetAll();
        IEnumerable<UserBankDetail> Get(DataTable filters, int limit, int startingRow);
    }
}
