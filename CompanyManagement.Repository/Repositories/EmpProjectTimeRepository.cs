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
    public class EmpProjectTimeRepository: IEmpProjectTimeRepository
    {
        public readonly IDatabaseContext _idb_context;
        public EmpProjectTimeRepository(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }

        //-----------------------------------Save Update ------------------------------

        public Response saveUpdate(EmployeeProjectModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@EmployeeProjectTimeId", model.EmployeeProjectTimeId);
                parameters.Add("@StartDate", model.StartDate);
                //parameters.Add("@EndDate", model.EndDate);
                parameters.Add("@ProjectId", model.ProjectId);
                parameters.Add("@StartTime", model.StartTime);
                parameters.Add("@EndTime", model.EndTime);
                parameters.Add("@TotalHours", model.TotalHours);
                parameters.Add("@Notes", model.Notes);
                parameters.Add("@CreatedBy", model.CreatedBy);

                var result = _idb_context.Query<WagesModel>("saveUpdateEmpProjectTime", parameters, null, CommandType.StoredProcedure);
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
        //-----------------------------------Get All ------------------------------
        public EmployeeProjectList GetAll(string data)
        {
            EmployeeProjectList result = new EmployeeProjectList();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var split = data.Split(":");
                var userid = split[0].Split("=");
                var date = split[1].Split("=");
                parameters.Add("@UserID",Int32.Parse(userid[1]));
                parameters.Add("@StartDate", DateTime.Parse(date[1]));
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _idb_context.Query<EmployeeProjectModel>("GetAll_EmpProjectTime", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    result.Status = parameters.Get<int>("@Status");
                    result.Message = parameters.Get<string>("@Message");
                    if (result.Status == 200)
                    {
                        result.EmpProjectListModel = _report;
                        if (result.EmpProjectListModel.Count == 0)
                        {
                            result.Status = (int)ErrorStatus.Error;
                            result.Message = "Information Not Found";
                        }


                    }

                }
                else
                {
                    result.EmpProjectListModel = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }



        //-----------------------------------Get All ------------------------------
        public EmployeeProjectList Getsingle(int data)
        {
            EmployeeProjectList result = new EmployeeProjectList();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
               
                parameters.Add("@empProjectID", data);
              
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _idb_context.Query<EmployeeProjectModel>("GetSingle_EmpProjectTime", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    result.Status = parameters.Get<int>("@Status");
                    result.Message = parameters.Get<string>("@Message");
                    if (result.Status == 200)
                    {
                        result.EmpProjectListModel = _report;
                        if (result.EmpProjectListModel.Count == 0)
                        {
                            result.Status = (int)ErrorStatus.Error;
                            result.Message = "Information Not Found";
                        }


                    }

                }
                else
                {
                    result.EmpProjectListModel = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
        //-----------------------------------Delete  by ID----------------------------------
        public Response Delete(int data)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", data);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<WagesModel>("DeleteEmpProject", parameters, null, CommandType.StoredProcedure);
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
