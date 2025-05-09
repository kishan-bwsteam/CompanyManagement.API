using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IEmployeeDetailService
    {

        //------------------------------------------------------ Get Employee Deatils by Company Id---------------------------------------------------------

        EmployeeDetailViewModels Get(int companyId);

        Response SaveUpdate(EmployeeDetail emp, int ActionBy);

        //------------------------------------------------------------------Delete Employee by userID -------------------------

        Response Delete(int userID);

    }
}
