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
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly IDatabaseContext _idb_context;
        public DepartmentRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }

//-------------------------------------------Save Update Department----------------------------------
		public Response Saveupdate(DepartmentModel model)
		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@DepartmentId", model.DepartmentId);
				parameters.Add("@DepartmentName", model.DepartmentName);
				parameters.Add("@Abberivation", model.Abberivation);
				parameters.Add("@CompanyID", model.CompanyID);
				parameters.Add("@IsMarketing", model.IsMarketing);
				parameters.Add("@UpdatedBy", model.userID);
				parameters.Add("@CreatedBy", model.userID);
				var result = _idb_context.Query<string>("SaveUpdateDepartment", parameters, null, CommandType.StoredProcedure);
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

		//---------------------------------------------------Get All Department by DepartmentViewModels (List)------------------------
		public DepartmentViewModels GetAll(int companyID)
		{
			DepartmentViewModels report = new DepartmentViewModels();
			try
			 {
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", companyID);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var _report = _idb_context.Query<DepartmentModel>("GetDepartmentData", parameters, commandType: CommandType.StoredProcedure).ToList();

				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.DepartmentModelList = _report;
						if (report.DepartmentModelList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Dept not found";
						}
					}
				}
				else
				{
					report.DepartmentModelList = null;
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


		//------------------------------ Single Department by Department ID--------------------------------

		public SingleDepartmentModel GetSingle(int departmentId)
		{
			SingleDepartmentModel report = new SingleDepartmentModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@DepartmentId", departmentId);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var _report = _idb_context.Query<DepartmentModel>("GetSingleDepartment", parameters, null, CommandType.StoredProcedure);
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.SingleDeparmentList = _report.FirstOrDefault();
						if (report.SingleDeparmentList == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Dept Details not found";
						}
					}
					else
					{
						report.SingleDeparmentList = null;
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
		

		//-------------------------------------------- Delete Department By Department ID---------------------------------
		public Response Delete(int departmentId)
		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@DepartmentId", departmentId);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("Delete_Department", parameters, null, CommandType.StoredProcedure);
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
