using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datas.Abstract
{
   public interface IEmployeeDetailRepository
    {

        //------------------------------------------------------ Get Employee Deatils by Company Id---------------------------------------------------------

        Response SaveOrUpdate(EmployeeDetail model, int actionBy);
        EmployeeDetailViewModels Get(int companyId);


        //------------------------------------------------------------------Delete Employee by userID -------------------------

        Response Delete(int userID);

    }
}
