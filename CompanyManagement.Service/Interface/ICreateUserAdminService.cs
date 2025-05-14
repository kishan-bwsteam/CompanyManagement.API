using CompanyManagement.Domain.Model;
using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface ICreateUserAdminService
    {

        //----------------------------Save Update Admin User-------------------------------------
        Response SaveUpdate(AdminUser model, int ActionBy);


        //------------------------- Admin User by createViewUserAdminModel (list)------------------------ 

        PaginatedResult<AdminUser> GetAdmins(int adminId, int limit, int startingRow);

        AdminUser GetAdmin(int adminId, int userId);
        createViewUserAdminModel GetAll();

        //-------------------------------Single user Get by userID--------------------------------

        singlecreateViewUserAdminModel GetSingle(int userID);

        //--------------------------------Delete User by UserID-------------------------------------------
        Response Delete(int userID);
    }
}
