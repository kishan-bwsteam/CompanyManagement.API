using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
    public class LetterRepository : ILetterRepository
    {
		public readonly IDatabaseContext _idb_context;
		public LetterRepository(IDatabaseContext _db_context)
		{
			_idb_context = _db_context;
		}


		//-------------------------------------------------Save Update Letter Template ------------------------------ 

		public Response SaveUpdate(LetterModel model)
		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@LetterID", model.LetterID);
				parameters.Add("@CompanyID", model.CompanyID);
				parameters.Add("@UserID", model.UserID);
				parameters.Add("@TempleteName", model.TempleteName);
				parameters.Add("@Body", model.Body);
			    parameters.Add("@CreatedBy", model.CreatedBy);
				parameters.Add("@UpdatedBy", model.UpdatedBy);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var result = _idb_context.Query<LetterModel>("SaveUpdateLetter", parameters, null, CommandType.StoredProcedure);
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



		//---------------------------------------------Get All Letter Template By LetterViewModel------------------
		public LetterViewModel GetAll(int companyID)

		{
			LetterViewModel report = new LetterViewModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", companyID);

				var _report = _idb_context.Query<LetterModel>("GetAllLetterTemplate", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.LetterModelList = _report;

						if (report.LetterModelList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Letter not found";
						}
					}
				}
				else
				{
					report.LetterModelList = null;
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


		//--------------------------------------------- Get  Single Template (List) by EmpID-----------------------

		public SingleLetterViewModel GetSingle(int letterID)

		{
			SingleLetterViewModel report = new SingleLetterViewModel();

			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@LetterID", letterID);

				var _report = _idb_context.Query<LetterModel>("GetSingleTemplete", parameters, null, CommandType.StoredProcedure);
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.SingleModelList = _report.FirstOrDefault();
						if (report.SingleModelList == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Letter Template not found";
						}
					}
					else
					{
						report.SingleModelList = null;
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







		//-------------------------------------------- Delete Letter Template by EmpID----------------------------------


		public Response Delete(int letterID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@LetterID", letterID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("Delete_LetterTemplete", parameters, null, CommandType.StoredProcedure);
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
