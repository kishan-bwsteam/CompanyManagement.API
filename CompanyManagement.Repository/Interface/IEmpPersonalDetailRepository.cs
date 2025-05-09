using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datas.Abstract
{
    public interface IEmpPersonalDetailRepository
    {
        //---------------------------------------- Save Update Personal Details------------------------------------------
        Response SaveUpdate(EmpPersonalDetailModel model);

        //--------------------------------------- Get All Personal Detail by EmpPersonalDetailViewModels----------------------------
        EmpPersonalDetailViewModels Get();

        //-------------------------------------- Get Single Details by  SinglePersonalDetailResponseModel------------------
        SinglePersonalDetailResponseModel GetSingle(int userID);


        //---------------------------------------- Delete User Details By UserID----------------------
        Response Delete(int userID);


        //--------------------------------------------------- Get All Department by DepartmentViewModel-------------------------------

        DepartmentViewModel GetDepartment();


        //---------------------------------------------------- Get All Position by PositionViewModel---------------------
        PositionViewModel GetPosition();
    }
}
