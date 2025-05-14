using CompanyManagement.Domain.Model;
using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datas.Abstract
{
    public interface ICreateUserAdminRepository
    {
        //----------------------------Save Update Admin User-------------------------------------
        Response SaveUpdate(AdminUser model, int ActionBy);


        //------------------------- Admin User by createViewUserAdminModel (list)------------------------ 
        PaginatedResult<AdminUser> Get(DataTable filters, int limit, int startingRow);


        createViewUserAdminModel GetAll();

        //-------------------------------Single user Get by userID--------------------------------

        singlecreateViewUserAdminModel GetSingle(int userID);

        //--------------------------------Delete User by UserID-------------------------------------------
        Response Delete(int userID);
    }
}
