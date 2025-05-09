using Dapper;
using Dto.Request;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;
using Dto.Model.Common;
using System.Linq;
using System.Data.SqlClient;
using Dto.Responses;
using CompanyManagement.Data.Datas.Abstract;

namespace CompanyManagement.Data.Datas.Abstract
{
    public class LoginRepository : ILoginRepository
    {
       // public loginRepository(IDatabaseContext dbcontext) : base(dbcontext) { }
        private readonly IDatabaseContext dbcontext;

        public LoginRepository()
        {
        }

        public LoginRepository(IDatabaseContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        //public LoginResponse    (LoginRequest loginRequest)
        //{
        //    LoginResponse response = new LoginResponse();
        //    try
        //    {
        //        DynamicParameters parameters = commonRepository.GetLogParameters();
        //        parameters.Add("@UserName", loginRequest.UserName);

        //        var result = dbcontext.Query<LoginResponse>("LoginCheck", parameters, null, CommandType.StoredProcedure).ToList();
        //        if (result != null)
        //        {
        //            response.PassKey = result.FirstOrDefault().PassKey;
        //            //response.FirstName = result[0].FirstName;
        //            //response.LastName = result[0].LastName;
        //            //response.UserTypeID = result[0].RoleId;
        //            //response.RoleId = result[0].RoleId;
        //            response.SaltKey = result[0].SaltKey;
        //            response.SaltKeyIV = result[0].SaltKeyIV;
        //            response.UserID = result[0].UserID;
        //            response.UserName = result[0].UserName;
        //            response.UserTypeName = result[0].UserTypeName;
        //            response.FullName = result[0].FullName;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        response.Status = (int)ErrorStatus.Exception;
        //        response.Message = ex.Message;
        //    }
        //    catch (DataException ex)
        //    {
        //        response.Status = (int)ErrorStatus.Exception;
        //        response.Message = ex.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = (int)ErrorStatus.Exception;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}

        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse response = new LoginResponse();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserName", loginRequest.UserName);
            parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
            parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

            var res = dbcontext.Query<LoginResponse>("login", parameters, null, CommandType.StoredProcedure).FirstOrDefault();
            //Console.WriteLine("list",res);
            if (res != null)
            {
                response.PassKey = res.PassKey;
                response.FirstName = res.FirstName;
                response.LastName = res.LastName;
                response.UserTypeID = res.UserTypeID;
                response.SaltKey = res.SaltKey;
                response.SaltKeyIV = res.SaltKeyIV;
                response.UserID = res.UserID;
                response.UserName = res.UserName;
                response.Password = "123456";
                response.Status = parameters.Get<int>("@Status");
                response.Message = parameters.Get<string>("@Message");
            }
            return response;
        }
    }
}

