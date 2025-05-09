using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Datas.Concrete
{
   public  class EmpEducationRepository : IEmpEducationRepository
    {
        public readonly IDatabaseContext _idb_context;

        public EmpEducationRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }

        //-------------------------------------------------- Save And Education Details ------------------------------------------
        public Response SaveOrUpdate(EducationModel education, int actionBy)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EducationId", education.EducationId); // 0 or actual ID
                parameters.Add("@UserID", education.UserID);
                parameters.Add("@DegreeName", education.DegreeName);
                parameters.Add("@InstName", education.InstName);
                parameters.Add("@PassingYear", education.PassingYear.Date, DbType.Date);
                parameters.Add("@Percentage", education.Percentage);
                parameters.Add("@ActionBy", actionBy);

                _idb_context.Execute("SaveOrUpdateUserEducation",
                                     parameters,
                                     commandType: CommandType.StoredProcedure);

                return new Response
                {
                    Status = 200,
                    Message = education.EducationId > 0 ? "Education Updated" : "Education Created"
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



        //-------------------------------------- Get All Education Details by EducationViewModels --------------------------
        public EducationViewModels GetAll()
		{
			EducationViewModels report = new EducationViewModels();

			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();

				var _report = _idb_context.Query<EducationModel>("GetUserEducationData", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.EducationViewModel = _report;

						if (report.EducationViewModel.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Education Details not found";
						}
					}
				}
				else
				{
					report.EducationViewModel = null;
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

		//----------------------------------------- Get Single Education List by UserID-----------------------------------------

		public singleEducationModel GetSingle(int userID)
        {
			singleEducationModel response = new singleEducationModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				
				parameters.Add("@UserID",userID);


				var _report = _idb_context.Query<EducationModel>("GetSingle_EmpEducation", parameters, null, CommandType.StoredProcedure);
				
				if (_report != null)
				{
					response.Status = parameters.Get<int>("@Status");
					response.Message = parameters.Get<string>("@Message");
					if (response.Status == 200)
					{
						response.SingleEducationList = _report.FirstOrDefault();

						
					}
				}
				else
				{
					response.SingleEducationList = null;
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


		//--------------------------------------------- Delete Education List by UserID---------------------------------------------------

		public EducationResponse Delete(int userID)
		{
			EducationResponse response = new EducationResponse();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@UserID", userID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<EducationModel>("Delete_EmpEducation", parameters, null, CommandType.StoredProcedure);
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



        public IEnumerable<UserEducation> Get(DataTable filters, int limit, int startingRow)
        {
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

                var result = _idb_context.Query<UserEducation>("GetUserEducation", parameters, commandType: CommandType.StoredProcedure);

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
