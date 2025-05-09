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
    public class PerformanceAttributeRepository : IPerformanceAttributeRepository
    {
        public readonly IDatabaseContext _dbcontext;
        public PerformanceAttributeRepository(IDatabaseContext databaseContext)
        {
            _dbcontext = databaseContext;
        }
        public List<PerformanceAttribute> GetAll(int CompanyID)
        {
            List<PerformanceAttribute> performanceAttributes = new List<PerformanceAttribute>();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanyID", CompanyID);
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<PerformanceAttribute>("PerformanceAttribute_GetAll", parameters, null, CommandType.StoredProcedure).ToList();
                if(_report != null )
                {
                    performanceAttributes=_report;
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return performanceAttributes;
        }

        public PerformanceAttributeModel GetById(int id)
        {
            PerformanceAttributeModel performanceAttribute = new PerformanceAttributeModel();
            try
            {
                DynamicParameters parameters=CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@PerformanceAttributeId", id);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<PerformanceAttribute>("PerformanceAttribute_GetById", parameters, null, CommandType.StoredProcedure);
                if(_report != null )
                {
                    performanceAttribute.Status = parameters.Get<int>("Status");
                    performanceAttribute.Message = parameters.Get<string>("Message");
                    if (performanceAttribute.Status == 200)
                    {
                        performanceAttribute.SinglePerformanceAttributeList = _report.FirstOrDefault();
                    }
                    if (performanceAttribute.SinglePerformanceAttributeList==null)
                    {
                        performanceAttribute.Message = "Data Not Exist";
                    }
                }
                else
                {
                    performanceAttribute.SinglePerformanceAttributeList = null;

                }
            }
            catch (Exception)
            {

                throw;
            }
            return performanceAttribute;
        }

        public Response PerformanceAttributeDelete(int id)
        {
           Response response=new Response();
            try
            {
                DynamicParameters parameters=CommonRepository.GetLogParameters();
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@PerformanceAttributeId", id);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _report = _dbcontext.Query<string>("PerformanceAttribute_Delete", parameters, null, CommandType.StoredProcedure);
                if(_report.Count()>0 )
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

        public Response SaveUpdate(PerformanceAttribute performanceAttribute)
        {
           Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("PerformanceAttributeId", performanceAttribute.PerformanceAttributeId);
                parameters.Add("AttributeName", performanceAttribute.AttributeName);
                parameters.Add("CompanyID", performanceAttribute.CompanyID);
                parameters.Add("DataTypeId", performanceAttribute.DataTypeId);
                parameters.Add("MaxNumber", performanceAttribute.MaxNumber);
                parameters.Add("IsActive", performanceAttribute.IsActive);
                parameters.Add("CreatedBy", performanceAttribute.CompanyID);
                parameters.Add("UpdateBy", performanceAttribute.CompanyID);
                parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
               // var _report = _dbcontext.Query<string>("", parameters, null, CommandType.StoredProcedure);
                var _report = _dbcontext.Query<string>("PerformanceAttribute_SaveUpdate", parameters, null, CommandType.StoredProcedure);
                if (_report != null )
                {
                    response.Status = parameters.Get<int>("Status");
                    response.Message = parameters.Get<string>("Message");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }




        public DataTypeView GetData()
        {
            DataTypeView report = new DataTypeView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var _report = _dbcontext.Query<DataTypeModel>("DataTypeDropdown", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.DataTypeList = _report;
                        if (report.DataTypeList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Country not found";
                        }
                    }
                }
                else
                {
                    report.DataTypeList = null;
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
