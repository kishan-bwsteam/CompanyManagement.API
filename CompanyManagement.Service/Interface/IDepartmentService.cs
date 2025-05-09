using Dto.Model;
using Dto.Model.Common;


namespace Service.Abstract
{
    public interface IDepartmentService
    {

        //----------------------------------------------Save Upadate Department------------------------------- 
        Response Saveupdate(DepartmentModel model);

        //---------------------------------------------------Get All Department by DepartmentViewModels (List)------------------------
        DepartmentViewModels GetAll(int companyID);

        //------------------------------------------------- Get Single Department By Department ID------------------------- 
        SingleDepartmentModel GetSingle(int departmentId);

        //-------------------------------------------- Delete Department By Department ID---------------------------------
        Response Delete(int departmentId);
    }
}
