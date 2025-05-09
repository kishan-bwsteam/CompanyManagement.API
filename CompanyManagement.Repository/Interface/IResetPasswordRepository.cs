using Dto.Model;
using Dto.Model.Common;


namespace Datas.Abstract
{
    public interface IResetPasswordRepository
    {

        //--------------------------------Save Update Password -------------------------------- -------
        Response SaveUpdate(ChangePasswordModel changemodel);

        //-------------------------------Reset Password----------------------------------------------
        GetSingleData Reset(ResetPasswordModel model);
    }
}
