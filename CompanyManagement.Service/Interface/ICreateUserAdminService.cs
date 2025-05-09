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
        Response SaveUpdate(CreateUserAdminModel model);


        //------------------------- Admin User by createViewUserAdminModel (list)------------------------ 


        createViewUserAdminModel GetAll();

        //-------------------------------Single user Get by userID--------------------------------
       
        singlecreateViewUserAdminModel GetSingle(int userID);

        //--------------------------------Delete User by UserID-------------------------------------------
        Response Delete(int userID);
    }
}
