using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Domain.Model;
using CompanyManagement.Service.Helper;
using CompanyManagement.Services.Service.Abstract;

using Dto.Request;
using Dto.Responses;

using SqlDapper.Concrete;
using System;

namespace CompanyManagement.Services.Service.Concrete
{
   public class LoginService : ILoginService
    {
        EncryptHelperModel obj = new EncryptHelperModel();
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepositery)
        {
            _loginRepository = loginRepositery;
        }

        /*****[start]Login user *****/
        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse result = new LoginResponse();
            try
            {
                //var passkey = EncryptHelper.Get_EncryptedPassword(obj, Password);
                result = _loginRepository.Login(loginRequest);
                obj.SaltKey = result.SaltKey;
                obj.SaltKeyIV = result.SaltKeyIV;
                if (result.Status > 0)
                {
                    if (loginRequest.Password == EncryptHelper.Get_DecryptedPassword(obj, result.PassKey) && !String.IsNullOrEmpty(result.UserName))
                    {
                        result.Status = 200;
                    }
                    else
                    {
                        result.FirstName = null;
                        result.LastName = null;
                        result.PassKey = null;
                        result.Password = null;
                        result.SaltKeyIV = null;
                        result.SaltKey = null;
                        result.UserName = null;
                        result.Status = 500;
                        result.Message = "Invalid Password.";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Status = 500;
                result.Message = "Invalid UserName Or Password.";
            }
            return result;
        }

    }
}
