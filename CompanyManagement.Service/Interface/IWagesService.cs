using Dto.Model;
using Dto.Model.Common;


namespace Service.Abstract
{
    public interface IWagesService
    {
        

        //-----------------------------------Save Update Wages------------------------------
        Response SaveUpdate(WagesModel model);

        //-----------------------------------Get All Wages------------------------------
        WagesModelView Get();

        //-----------------------------------Delete Wages by wagesID----------------------------------
        Response Delete(int wagesID);
        MultiWagesModelView GetStructureSalary(string Box);
        //MultiWagesModelView GetUserStructure(int UserID);
    }
}
