using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;
using Microsoft.Data.SqlClient;



namespace Datas.Concrete
{
    public class ResetPasswordRepository : IResetPasswordRepository
    {
        public readonly IDatabaseContext _idb_context;

        public ResetPasswordRepository(IDatabaseContext _databaseContext)
        {
            _idb_context = _databaseContext;
        }




        //--------------------------------Save Update Password -------------------------------- -------

        public Response SaveUpdate(ChangePasswordModel changemodel)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@UserGuid", changemodel.UserGuid);
                parameters.Add("@PassKey", changemodel.PassKey);
                parameters.Add("@SaltKey", changemodel.SaltKey);
                parameters.Add("@SaltKeyIV", changemodel.SaltKeyIV);

                var result = _idb_context.Query<string>("ChangePassword", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;
        }

        //------------------------------------------Reset Password---------------------------------------------


        public GetSingleData Reset(ResetPasswordModel model)
        {
            GetSingleData data = new GetSingleData();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("UserName", model.UserName);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                var result =  _idb_context.Query<ResetPasswordModel>("ResetPassword", parameters, null, CommandType.StoredProcedure).FirstOrDefault();
                if (result != null)
                {
                    data.ModelReset = result;
                    data.Status = parameters.Get<int>("@Status");
                    data.Message = parameters.Get<string>("@Message");
                }
                //else
                //{
                //    data.Status = result.Status;
                //}
            }
            catch (SqlException ex)
            {
                data.Status = (int)ErrorStatus.Exception;
                data.Message = ex.Message;
            }
            catch (DataException ex)
            {
                data.Status = (int)ErrorStatus.Exception;
                data.Message = ex.Message;
            }
            catch (Exception ex)
            {
                data.Status = (int)ErrorStatus.Exception;
                data.Message = ex.Message;
            }

            return data;

        }


    }
}
