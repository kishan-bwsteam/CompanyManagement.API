
using Dapper;
using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;
using Microsoft.Data.SqlClient;

//using static Dto.Model.UserModel;
using CompanyManagement.Datas.Concrete;
using CompanyManagement.Data.Datas.Abstract;
using Dto.Model;
using CompanyManagement.Domain.Model.Common;
using CompanyManagement.Domain.Model;

namespace CompanyManagement.Data.Datas.Concrete
{
    public class UserRepository : IUserRepository
    { 
        public readonly IDatabaseContext _idb_context;

        public UserRepository(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }






        //--------------------------------------------------------- Save Update user-------------------------------------


        public Response SaveOrUpdate(UserBasic model, int actionBy)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@UserID", model.UserID);
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@MiddleName", model.MiddleName);
                parameters.Add("@UserName", model.UserName);
                parameters.Add("@UserTypeID", model.UserTypeID);
                parameters.Add("@ParentUserID", model.ParentUserID);
                parameters.Add("@isActive", model.isActive, DbType.Boolean);
                parameters.Add("@ActionBy", actionBy);

                _idb_context.Execute("SaveOrUpdateUserBasic",
                                     parameters,
                                     commandType: CommandType.StoredProcedure);

                return new Response
                {
                    Status = 200,
                    Message = model.UserID > 0 ? "User Basic Details Updated" : "User Basic Details Created"
                };
            }
            catch (SqlException ex)
            {
                return new Response { Status = 500, Message = "SQL Error: " + ex.Message };
            }
            catch (Exception ex)
            {
                return new Response { Status = 500, Message = "Error: " + ex.Message };
            }
        }

        //--------------------------------------------------------Get All User Data by userViewModel (List)-----------------

        public userViewModels Get()
        {
            userViewModels report = new userViewModels();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _idb_context.Query<UserResponse>("GetUserData", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.userViewModel = _report;

                        if (report.userViewModel.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "User not found";
                        }
                    }
                }
                else
                {
                    report.userViewModel = null;
                }
            }
            catch (SqlException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (DataException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (Exception ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            return report;
        }



        //----------------------------------------- Get Single User by UserID-------------------------------------------------------

        public singleUserResponseModel GetSingle(int userID)
        {
            singleUserResponseModel report = new singleUserResponseModel();

            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                //  DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@UserID", userID);

                var _report = _idb_context.Query<UserResponse>("GetSingleUser", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 1)
                    {
                        report.SUDModel = _report;
                        if (report.SUDModel == null)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "User Details not found";
                        }
                    }
                    else
                    {
                        report.SUDModel = null;
                    }
                }

            }
            catch (SqlException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (DataException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (Exception ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            return report;

        }




        //--------------------------------------- Delete User Details-------------------------------------------------------


        public Response Delete(int userId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@UserID", userId);

                //parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                //parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<string>("Delete_User", parameters, null, CommandType.StoredProcedure);
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




        //--------------------------------------------Get Address Type--------------------------------------------
        public IEnumerable<AddressType> GetAddressType()

        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
            parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
            //DynamicParameters parameters = CommonRepository.GetLogParameters();
            var result = _idb_context.Query<AddressType>("Sp_Drop_AddressType", parameters, null, CommandType.StoredProcedure);
            return result;
        }




     

        //--------------------------------------------Get User Type------------------------------------------------

        public List<IDictionary<string, object>> GetUserType()

        {
            //DynamicParameters parameters = CommonRepository.GetLogParameters();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
            parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
            var result = _idb_context.Query("Sp_Drop_UserType", parameters, null, CommandType.StoredProcedure).Cast<IDictionary<string, object>>().ToList();
            return result;
        }


     


        //---------------------------------------upload Profile by profile ID---------------------------------------

        public Response Upload(int profileid, string path, string msg)

        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                //DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@profileid", profileid);
                parameters.Add("@path", path);
                parameters.Add("@msg", msg);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<string>("Profile", parameters, null, CommandType.StoredProcedure);
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


        //------------------------------------------ Delete Company by Company ID------------------------------------------------

        public Response DeleteCompany(int companyID)

        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", companyID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<string>("Delete_CompanyData", parameters, null, CommandType.StoredProcedure);
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






        public PaginatedResult<UserBasic> Get(DataTable filters, int limit, int startingRow)
        {
            PaginatedResult<UserBasic> result = new PaginatedResult<UserBasic>();
            try
            {
                var parameters = new DynamicParameters();

                // Pass the filter DataTable as a table-valued parameter
                if (filters == null)
                {
                    filters = new DataTable("filter_type");
                    filters.Columns.Add("operator", typeof(string));
                    filters.Columns.Add("col", typeof(string));
                    filters.Columns.Add("condition", typeof(string));
                    filters.Columns.Add("val", typeof(string));
                }

                parameters.Add("@filters", filters.AsTableValuedParameter("filter_type"));
                parameters.Add("@limit", limit);
                parameters.Add("@startingRow", startingRow);
                parameters.Add("@totalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

                result.Data = _idb_context.Query<UserBasic>("GetUserBasic", parameters, commandType: CommandType.StoredProcedure);
                result.TotalRecords = parameters.Get<int>("@totalRecords");
                return result;
            }
            catch (SqlException ex)
            {
                // Log and rethrow or handle as needed
                throw new Exception("SQL Error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Log and rethrow or handle as needed
                throw new Exception("General Error: " + ex.Message, ex);
            }
        }



    }
}
