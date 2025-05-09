using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;
using Microsoft.Data.SqlClient;



namespace Datas.Concrete
{
    public class EmpEmploymentRepository : IEmpEmploymentRepository
    {
        public readonly IDatabaseContext _idb_context;

        public EmpEmploymentRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }

        //--------------------------------------------- Save Update Employment ------------------------------------------------------------
        public EmploymentResponse SaveUpdate(EmploymentModel model)
        {
            EmploymentResponse response = new EmploymentResponse();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();


                parameters.Add("@EmploymentID", model.EmploymentID);
                parameters.Add("@UserID", model.UserID);
                parameters.Add("@CompanyName", model.CompanyName);
                parameters.Add("@Position", model.Position);
                parameters.Add("@FromDate", model.FromDate);
                parameters.Add("@ToDate", model.ToDate);
                parameters.Add("@CTC", model.CTC);
                parameters.Add("@Responsibilities", model.Responsibilities);
                parameters.Add("@CreatedBy", model.UserID);
                parameters.Add("@UpdatedBy", model.UserID);


                var result = _idb_context.Query<string>("SaveUpdate_EmpEmployement", parameters, null, CommandType.StoredProcedure);
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

        //-------------------------------------- Get All Employement by AllEmploymentList----------------------------

        public AllEmploymentList GetAll()
        {
            AllEmploymentList report = new AllEmploymentList();

            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                var _report = _idb_context.Query<EmploymentModel>("GetUserEmployementData", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.EmploymentListModel = _report;

                        if (report.EmploymentListModel.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Employment Details not found";
                        }
                    }
                }
                else
                {
                    report.EmploymentListModel = null;
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


        //-------------------------------------------------- Get Single Employment data by userID-----------------------------

        public SingleEmpModel GetSingle(int userID)
        {
            SingleEmpModel response = new SingleEmpModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@UserID", userID);


                var _report = _idb_context.Query<EmploymentModel>("GetSingle_Employement", parameters, null, CommandType.StoredProcedure);

                if (_report != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                    if (response.Status == 200)
                    {
                        response.SingleModelList = _report.FirstOrDefault();


                    }
                }
              
                   else
                {
                    response.SingleModelList = null;
                }
            }

                        
			catch (SqlException ex)
			{
                response.Status = (int) ErrorStatus.Exception;
                response.Message = ex.Message;
			}
			catch (DataException ex)
			{
                response.Status = (int) ErrorStatus.Exception;
                response.Message = ex.Message;
			}

            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;

		}


        //----------------------------------------------------------- Delete Employment by UserID------------------------------------

        public EmploymentResponse Delete(int userID)
        {
            EmploymentResponse response = new EmploymentResponse();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", userID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<EmploymentModel>("Delete_EmpEmployement", parameters, null, CommandType.StoredProcedure);
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
  

