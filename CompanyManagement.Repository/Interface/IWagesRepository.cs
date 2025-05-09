using Dto.Model;
using Dto.Model.Common;


namespace Datas.Abstract
{
   public interface IWagesRepository
    {

        //-----------------------------------Save Update Wages------------------------------
        Response SaveUpdate(WagesModel model);

        //-----------------------------------Get All Wages------------------------------
        WagesModelView Get();

        //-----------------------------------Delete Wages by wagesID----------------------------------
        Response Delete(int wagesID);
        MultiWagesModelView GetStructureSalary(string Box);
       // MultiWagesModelView GetUserStructure(int UserID);
    }
}
