using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IResetPasswordService
    {
        //--------------------------------Save Update Password -------------------------------- -------
        Response SaveUpdate(ChangePasswordModel changemodel);

        //-------------------------------Reset Password----------------------------------------------
        Response Reset(ResetPasswordModel model);
    }
}
