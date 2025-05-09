using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;



namespace Service.Abstract
{
    public interface IEmpBankService
    {

        // -----------------------------Save And Update Bank Details------------------------ 
        Response SaveUpdate(UserBankDetail model, int actionBy);


        //----------------------------Get all Bank Details by BankViewModels (List)-------------------
        BankViewModels GetAll();
        UserBankDetail GetByUserId(int UserId);
    }
}
