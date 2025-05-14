using BussinessObject;
using Dapper;
using Datas.Abstract;
using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;

using System.Data;
using Microsoft.Data.SqlClient;



namespace Datas.Concrete
{
	public class RoleDataRepository : IRoleDataRepository
	{

        public readonly IDatabaseContext _idb_context;
        public RoleDataRepository(IDatabaseContext databaseContext)
        {
			_idb_context = databaseContext;
        }

		//----------------------------------- Save Update Role --------------------------
		public RoleResponse SaveUpdate(RoleModel model,int ActionBy)

		{
			RoleResponse response = new RoleResponse();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@RoleID", model.RoleID);
				parameters.Add("@RoleName", model.RoleName);
				parameters.Add("@RoleLevel", model.RoleLevel);
				parameters.Add("@Abbreviation", model.Abbreviation);
                parameters.Add("@ActionBy", ActionBy);
				parameters.Add("@UserID",model.userID);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var result = _idb_context.Query<string>("SaveUpdateRole", parameters, null, CommandType.StoredProcedure);
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
			

		//-----------------------------------Get Single Role by RoleID--------------------------------

		public SingleRoleResponseModel GetSingle(int roleID)

		{
			SingleRoleResponseModel report = new SingleRoleResponseModel();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@RoleID", roleID);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var _report = _idb_context.Query<RoleModel>("GetSingleRole", parameters, null, CommandType.StoredProcedure);
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.RModel = _report.FirstOrDefault();
						if (report.RModel == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Role Details not found";
						}
					}
					else
					{
						report.RModel = null;
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


		//----------------------------------- Get All  Role Data by roleViewModels ---------------------
		public roleViewModels Get(int userID)
		{
			roleViewModels report = new roleViewModels();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@UserID", userID);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var _report = _idb_context.Query<RoleModel>("GetAllRole", parameters, commandType: CommandType.StoredProcedure).ToList();

				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.roleViewModel = _report;
						if (report.roleViewModel.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "posi not found";
						}
					}
				}
				else
				{
					report.roleViewModel = null;
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

		//-------------------------------------Delete by RoleID-----------------------------------

		public RoleResponse Delete(int roleId)

		{
			RoleResponse response = new RoleResponse();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@RoleID", roleId);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("Delete_Role", parameters, null, CommandType.StoredProcedure);
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