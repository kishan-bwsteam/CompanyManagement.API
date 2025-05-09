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

    public class WeekOffRepository : IWeekOffRepository
	{
        public readonly IDatabaseContext dbcontext;
        public WeekOffRepository(IDatabaseContext _dbcontext)
        {
            dbcontext = _dbcontext;
           
        }
   

	public Response SaveUpdateWeakOff(WeakOffModel model,DataTable dt)

	{

		Response response = new Response();
		try
		{
			DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@WeakOffID", model.WeakOffID);
				parameters.Add("@NoOfOFF", model.NOOfWeekOff);
				parameters.Add("@CompanyID", model.CompanyID);
				parameters.Add("@CreatedBy", model.CreatedBy);
				parameters.Add("@WKdetails", dt, DbType.Object, null, -1);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var result = dbcontext.Query<string>("SaveUpdateWeakOff", parameters, null, CommandType.StoredProcedure);
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

        #region Comment

        public Response SaveUpdateWeakOffDetail(WeakOffDetailModel model)

	{
			WeakOffModel weakOffModel = new WeakOffModel();
					Response response = new Response();
		try
		{
			DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@WkOffDetID", weakOffModel.WkOffDetID);
				parameters.Add("@CompanyID", weakOffModel.CompanyID);
				parameters.Add("@CreatedBy", weakOffModel.CreatedBy);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var result = dbcontext.Query<string>("SaveUpdateWeakOffDetail", parameters, null, CommandType.StoredProcedure);
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
        #endregion

        #region commmet
        public WeakOffViewModal GetAllWeakOff(int CompanyID)
		{
			{
				WeakOffViewModal report = new WeakOffViewModal();
				try
				{
					DynamicParameters parameters = CommonRepository.GetLogParameters();
					parameters.Add("@CompanyID", CompanyID);
					parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
					parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

					var _report = dbcontext.Query<WeakOffModel>("GetAllWeakOff", parameters, commandType: CommandType.StoredProcedure).ToList();

					if (_report != null)
					{
						report.Status = parameters.Get<int>("@Status");
						report.Message = parameters.Get<string>("@Message");
						if (report.Status == 200)
						{
							report.WeakOffModelList = _report;
							if (report.WeakOffModelList.Count == 0)
							{
								report.Status = (int)ErrorStatus.Error;
								report.Message = "Weak Information not found";
							}
						}
					}
					else
					{
						report.WeakOffModelList = null;
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

        #endregion

        public WeakOffDetailViewModal GetAllWeakOffDetail(int CompanyID)
		{
			{
				WeakOffDetailViewModal report = new WeakOffDetailViewModal();
				try
				{
					DynamicParameters parameters = CommonRepository.GetLogParameters();
					parameters.Add("@CompanyID", CompanyID);
					parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
					parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
					var _report = dbcontext.Query<WeakOffDetailModel>("GetAllWeakOffDetail", parameters, commandType: CommandType.StoredProcedure).ToList();

					if (_report != null)
					{
						report.Status = parameters.Get<int>("@Status");
						report.Message = parameters.Get<string>("@Message");
						if (report.Status == 200)
						{
							report.weakOffDetailModel = _report;
							if (report.weakOffDetailModel.Count == 0)
							{
								report.Status = (int)ErrorStatus.Error;
								report.Message = "Weak Detail Information not found";
							}
						}
					}
					else
					{
						report.weakOffDetailModel = null;
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




		public Response DeleteWeakOff(int wkOffDetID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@WeakOffDetID", wkOffDetID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = dbcontext.Query<string>("DeleteWeakOff", parameters, null, CommandType.StoredProcedure);
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

        #region Comment
        public Response DeleteWeakOffDetail(int WeakOffDetailID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@WkOffDetID", WeakOffDetailID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = dbcontext.Query<string>("DeleteWeakDetailOff", parameters, null, CommandType.StoredProcedure);
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
        #endregion

        public WeakOffDetailViewModal GetSingleWeakOffDetail(int WeakOffDetailID)
		{
			{
				WeakOffDetailViewModal report = new WeakOffDetailViewModal();
				try
				{
					DynamicParameters parameters = CommonRepository.GetLogParameters();
					parameters.Add("@WkOffDetID", WeakOffDetailID);
					parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
					parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
					var _report = dbcontext.Query<WeakOffDetailModel>("GetSingleWeakOffDetail", parameters, commandType: CommandType.StoredProcedure).ToList();

					if (_report != null)
					{
						report.Status = parameters.Get<int>("@Status");
						report.Message = parameters.Get<string>("@Message");
						if (report.Status == 200)
						{
							report.weakOffDetailModel = _report;
							if (report.weakOffDetailModel.Count == 0)
							{
								report.Status = (int)ErrorStatus.Error;
								report.Message = "Weak Detail Information not found";
							}
						}
					}
					else
					{
						report.weakOffDetailModel = null;
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


		public WeakOffViewModal GetSingleWeakOff(int WeakOffID)
		{
			{
				WeakOffViewModal report = new WeakOffViewModal();
				try
				{
					DynamicParameters parameters = CommonRepository.GetLogParameters();
					parameters.Add("@WeakOffID", WeakOffID);
					parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
					parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

					var _report = dbcontext.Query<WeakOffModel>("GetSingleWeakOff", parameters, commandType: CommandType.StoredProcedure).ToList();

					if (_report != null)
					{
						report.Status = parameters.Get<int>("@Status");
						report.Message = parameters.Get<string>("@Message");
						if (report.Status == 200)
						{
							report.WeakOffModelList = _report;
							if (report.WeakOffModelList.Count == 0)
							{
								report.Status = (int)ErrorStatus.Error;
								report.Message = "Weak off Information not found";
							}
						}
					}
					else
					{
						report.WeakOffModelList = null;
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

}
