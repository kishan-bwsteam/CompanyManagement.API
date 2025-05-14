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
using CompanyManagement.Domain.Model;



namespace Datas.Concrete
{

    public class CreateUserAdminRepository : ICreateUserAdminRepository
    {
        public readonly IDatabaseContext _idb_context;
        public CreateUserAdminRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }

		//----------------------------Save Update Admin User-------------------------------------
		public Response SaveUpdate(AdminUser model, int ActionBy)

        {

			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@UserID", model.UserID);
				parameters.Add("@FirstName", model.FirstName);
				parameters.Add("@MiddleName", model.MiddleName);
				parameters.Add("@LastName", model.LastName);
				parameters.Add("@UserName ", model.UserName);
				parameters.Add("@LoginUserID", ActionBy);
				//parameters.Add("@UserGuid", model.UserGuid);
				parameters.Add("@DOB", model.DOB);
				//parameters.Add("@IsDeleted", model.IsDeleted);
				parameters.Add("@EmailID ", model.EmailId);
				parameters.Add("@PrimaryPhoneNo", model.PhoneNumber);
				parameters.Add("@CompanyID", model.CompanyId);
				parameters.Add("@AddressLine1", model.Address.AddressLine1);
				parameters.Add("@AddressLine2", model.Address.AddressLine2);
                parameters.Add("@City", model.Address.City);
				parameters.Add("@ZipCode",model.Address.ZipCode);
				parameters.Add("@StateId", model.Address.StateId);
				parameters.Add("@CountryId", model.Address.CountryId);

				parameters.Add("@PassKey", model.userPassKey.PassKey);
				parameters.Add("@SaltKey", model.userPassKey.SaltKey);
				parameters.Add("@SaltKeyIV", model.userPassKey.SaltKeyIV);
                parameters.Add("@status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@message", "", DbType.String, ParameterDirection.Output);


				var result = _idb_context.Query<CreateUserAdminModel>("SaveUpdateAdminUser", parameters, null, CommandType.StoredProcedure);
				if (result != null)
				{
					response.Status = parameters.Get<int>("status");
					response.Message = parameters.Get<string>("message");
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
				throw ex;
			}

			return response;
		}
        public PaginatedResult<AdminUser> Get(DataTable filters, int limit, int startingRow)
        {
            PaginatedResult<AdminUser> result = new PaginatedResult<AdminUser>();
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

                result.Data = _idb_context.Query<AdminUser>("GetAdminUser", parameters, commandType: CommandType.StoredProcedure);
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


        //------------------------- Admin User by createViewUserAdminModel (list)------------------------

        public createViewUserAdminModel GetAll()
		
		{
			createViewUserAdminModel report = new createViewUserAdminModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();

				var _report = _idb_context.Query<CreateUserAdminModel>("GetAllAdminUser", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.CreateUserAllModelList = _report;

						if (report.CreateUserAllModelList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "User not found";
						}
					}
				}
				else
				{
					report.CreateUserAllModelList = null;
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


		//-------------------------------Single user Get by userID--------------------------------

		public singlecreateViewUserAdminModel GetSingle(int userID)

		{
			singlecreateViewUserAdminModel report = new singlecreateViewUserAdminModel();

			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@UserID", userID);

				var _report = _idb_context.Query<CreateUserAdminModel>("GetSingleAdminUser", parameters, null, CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.CreateUserSingleList = _report;
						if (report.CreateUserSingleList == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "User Details not found";
						}
					}
					else
					{
						report.CreateUserSingleList = null;
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


		//--------------------------------Delete User by UserID-------------------------------------------


		public Response Delete(int userID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@UserID", userID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("DeleteAdminUser", parameters, null, CommandType.StoredProcedure);
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
		

	}
}
