using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
    public class PositionRepositiory : IPositionRepositiory
    {

        public readonly IDatabaseContext _idb_context;

        public PositionRepositiory(IDatabaseContext _db_Context)
        {
            _idb_context = _db_Context;
        }



		//-----------------------------------------------------save update position---------------------------
		public PositionResponse Saveupdate(PositionModel model)
		{
			PositionResponse response = new PositionResponse();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@PositionID", model.@PositionID);
				parameters.Add("@RoleName", model.PositionName);
				parameters.Add("@RoleLevel", model.PositionLevel);
				parameters.Add("@Abberivation", model.Abberivation);
				parameters.Add("@DepartmentID", model.DepartmentID);
				parameters.Add("@CreatedBy", model.UserID);
				parameters.Add("@UpdatedBy", model.UserID);
				//parameters.Add("@UserID", model.UserID);

                parameters.Add("@companyID", model.companyID);

				var result = _idb_context.Query<string>("SaveUpdatePosition", parameters, null, CommandType.StoredProcedure);
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



		//----------------------------------------Get All Postion by positionViewModels (List)----------------------------
		public positionViewModels Get(int companyID)
		{
			positionViewModels report = new positionViewModels();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", companyID);
				var _report = _idb_context.Query<PositionModel>("GetAllPosition", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.positionViewModel = _report;
						if (report.positionViewModel.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "position not found";
						}
					}
				}
				else
				{
					report.positionViewModel = null;
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



		//----------------------------------------------Get Single Position RoleID----------------


		public SinglePositionResponseModel GetSingle(int roleID)
		{
			SinglePositionResponseModel report = new SinglePositionResponseModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@PositionID", roleID);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var _report = _idb_context.Query<PositionModel>("GetSinglePosition", parameters, null, CommandType.StoredProcedure);
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.PModel = _report.FirstOrDefault();
						if (report.PModel == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Position Details not found";
						}
					}
					else
					{
						report.PModel = null;
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




		//-----------------------------------------------Delete Position Details by RoleID----------------------------------------------- 

		public PositionResponse Delete(int roleId)
		{
			PositionResponse response = new PositionResponse();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@PositionID", roleId);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("DeletePosition", parameters, null, CommandType.StoredProcedure);
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
