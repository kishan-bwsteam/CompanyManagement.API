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
    public class EmployeePerformanceRepository : IEmployeePerformanceRepository
    {
        public readonly IDatabaseContext _dbcontext;
        public EmployeePerformanceRepository(IDatabaseContext databaseContext)
        {
            _dbcontext = databaseContext;
        }
        public Response EmployeePerformanceDelete(int id)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@EmployeePerformanceId", id);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<string>("EmployeePerformance_Delete", parameters, null,CommandType.StoredProcedure);
                if (_report.Count() > 0)
                {
                    response.Status = parameters.Get<int>("status");
                    response.Message = parameters.Get<string>("message");
                }
                else
                {
                    response.Status = (int)200;
                    response.Message = ("Data Deleted Successfully");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public List<EmployeePerformance> GetAll( int companyID)
        {
            List<EmployeePerformance> employeePerformances = new List<EmployeePerformance>();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
               
                 parameters.Add("companyID", companyID);
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<EmployeePerformance>("EmployeePerformance_GetAll", parameters, null, CommandType.StoredProcedure).ToList();
                if(_report != null )
                {
                    employeePerformances = _report;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return employeePerformances;
        }

        public EmployeePerformanceModel GetById(int id)
        {
            EmployeePerformanceModel employeePerformance= new EmployeePerformanceModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@EmployeePerformanceId", id);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<EmployeePerformance>("EmployeePerformance_GetById", parameters, null, CommandType.StoredProcedure);
                if (_report != null)
                {
                    employeePerformance.Status = parameters.Get<int>("Status");
                    employeePerformance.Message = parameters.Get<string>("Message");
                    if (employeePerformance.Status == 200)
                    {
                        employeePerformance.SingleEmployeePerformanceList = _report.FirstOrDefault();
                    }
                    if (employeePerformance.SingleEmployeePerformanceList == null)
                    {
                        employeePerformance.Message = "Data Not Existed";
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return employeePerformance;
        }

        public Response SaveUpdate(EmployeePerformanceList model, DataTable AttributeData)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@AttributeData", AttributeData, DbType.Object);
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<string>("EmployeePerformance_SaveUpdate", parameters, null, CommandType.StoredProcedure);
                if(_report != null )
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
    }
    
}
