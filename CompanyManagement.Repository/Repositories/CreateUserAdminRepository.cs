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

    public class CreateUserAdminRepository : ICreateUserAdminRepository
    {
        public readonly IDatabaseContext _idb_context;
        public CreateUserAdminRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }

		//----------------------------Save Update Admin User-------------------------------------
		public Response SaveUpdate(CreateUserAdminModel model)

		{

			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@UserID", model.UserID);
				parameters.Add("@UserTypeID", model.UserTypeID);
				parameters.Add("@FirstName", model.FirstName);
				parameters.Add("@MiddleName", model.MiddleName);
				parameters.Add("@LastName", model.LastName);
				parameters.Add("@UserName ", model.UserName);
				parameters.Add("@UpdatedBy", model.UserID);
				parameters.Add("@LoginUserID", model.UserID);
				//parameters.Add("@UserGuid", model.UserGuid);
				parameters.Add("@DOB", model.DOB);
				parameters.Add("@IsDeleted", model.IsDeleted);
				parameters.Add("@EmailID ", model.EmailID);
				parameters.Add("@CreatedBy", model.CreatedBy);
				parameters.Add("@PrimaryPhoneNo", model.PhoneNo);
				parameters.Add("@CompanyID", model.CompanyID);
				parameters.Add("@City", model.City);
				parameters.Add("@ZipCode",model.ZipCode);
				parameters.Add("@State", model.State);
				parameters.Add("@Country", model.Country);

				parameters.Add("@PassKey", model.PassKey);
				parameters.Add("@SaltKey", model.SaltKey);
				parameters.Add("@SaltKeyIV", model.SaltKeyIV);
				parameters.Add("@Status", model.Status);
				parameters.Add("@Message",model.Message);


				var result = _idb_context.Query<CreateUserAdminModel>("SaveUpdateAdminUser", parameters, null, CommandType.StoredProcedure);
				if (result != null)
				{
					response.Status = parameters.Get<int>("Status");
					response.Message = parameters.Get<string>("Message");
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
