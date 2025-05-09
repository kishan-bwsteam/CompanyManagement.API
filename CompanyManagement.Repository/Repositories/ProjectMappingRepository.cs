using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
   public class ProjectMappingRepository : IProjectMappingRepository
	{
		public readonly IDatabaseContext _idb_context;
		public ProjectMappingRepository(IDatabaseContext databaseContext)
		{
			_idb_context = databaseContext;
		}

		//----------------------------------- Save Update Role --------------------------
		public Response SaveUpdateMapping(DataTable MappingProject)

		{
			Response mappingproject = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@MappingProject", MappingProject, DbType.Object);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var result = _idb_context.Query<string>("ProjectMappingSave_update", parameters, null, CommandType.StoredProcedure);
				if (result != null)
				{
					mappingproject.Status = parameters.Get<int>("@Status");
					mappingproject.Message = parameters.Get<string>("@Message");
				}

			}
			catch (SqlException ex)
			{
				mappingproject.Status = (int)ErrorStatus.Exception;
				mappingproject.Message = ex.Message;
			}
			catch (DataException ex)
			{
				mappingproject.Status = (int)ErrorStatus.Exception;
				mappingproject.Message = ex.Message;
			}
			catch (Exception ex)
			{
				mappingproject.Status = (int)ErrorStatus.Exception;
				mappingproject.Message = ex.Message;
			}
			return mappingproject;

		}


		//-------------------------------------Get All Project List --------------------



		public  MultipleMappingView GetAllProjectList(int CompanyID)
		{
			MultipleMappingView report = new MultipleMappingView();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", CompanyID);

				var _report = _idb_context.Query<ProjectMappingModel>("GetAllProjectMappingList", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.EmployeeMapppingList = _report;

						if (report.EmployeeMapppingList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "User not found";
						}
					}
				}
				else
				{
					report.EmployeeMapppingList = null;
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





		public MultipleMappingView GetAllProjectMapping(int CompanyID,int ProjectID)
		{
			MultipleMappingView report = new MultipleMappingView();
			try
				 
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", CompanyID);
				parameters.Add("@ProjectID", ProjectID);

				var _report = _idb_context.Query<ProjectMappingModel>("ProjectMappingList", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.EmployeeMapppingList = _report;

						if (report.EmployeeMapppingList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "User not found";
						}
					}
				}
				else
				{
					report.EmployeeMapppingList = null;
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


	}
}
