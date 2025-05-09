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
    public class ShiftRulesRepository : IShiftRulesRepository
    {

        public readonly IDatabaseContext dbcontext;
        public ShiftRulesRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }

        public Response SaveUpdate(ShiftRulesModel modal)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@shiftRuleId", modal.ShiftRuleId);
                parameters.Add("@fullDay", modal.FullDay);
                parameters.Add("@halfDay", modal.HalfDay);
                parameters.Add("@oneFourthDay", modal.OneFourthDay);
                parameters.Add("@absent", modal.Absent);
                parameters.Add("@markAbsent", modal.MarkAbsent);
                parameters.Add("@holidayAsAbsent", modal.HolidayAsAbsent);
                parameters.Add("@absentIfLateFor", modal.AbsentIfLateFor);
                parameters.Add("@shiftConsider", modal.ShiftConsider==null? "Not Applicable":modal.ShiftConsider);
                parameters.Add("@minOT", modal.MinOT);
                parameters.Add("@maxOT", modal.MaxOT);
                parameters.Add("@companyId", modal.CompanyId);
                parameters.Add("@wage", modal.Wage);
                parameters.Add("@userId", modal.UserId);
                parameters.Add("@status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@message", "", DbType.String, ParameterDirection.Output);

                var result = dbcontext.Query<string>("SaveUpdateShiftRule", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@status");
                    response.Message = parameters.Get<string>("@message");
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
        public ShiftRulesModel GetSingle(int shifRuleId)
        {
            DynamicParameters parameters = CommonRepository.GetLogParameters();
            parameters.Add("@shiftRuleId", shifRuleId);
            parameters.Add("@status", 0, DbType.Int32, ParameterDirection.Output);
            parameters.Add("@message", "", DbType.String, ParameterDirection.Output);
            try
            {
                var result = dbcontext.Query<ShiftRulesModel>("FetchShiftRuleByShiftRuleId", parameters, null, CommandType.StoredProcedure).FirstOrDefault();
                if (result != null)
                {
                   // result.Status = parameters.Get<int>("@status");
                    //.Message = parameters.Get<string>("@message");
                    return result;
                }
                else
                {
                    //return new ShiftRulesModel() { Message = "shift rule not found", Status = (int)ErrorStatus.NotFound };
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public Response Delete(int shifRuleId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@shiftRuleId", shifRuleId);

                parameters.Add("@status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@message", "", DbType.String, ParameterDirection.Output);
                var result = dbcontext.Query<string>("DeleteShiftRuleByShifRuleId", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@status");
                    response.Message = parameters.Get<string>("@message");
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

        public AllShiftRulesModel GetAll()
        {
            AllShiftRulesModel response = new AllShiftRulesModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@message", "", DbType.String, ParameterDirection.Output);
                var result = dbcontext.Query<ShiftRulesModel>("GetAllShiftRule", parameters, null, CommandType.StoredProcedure).ToList();
                if (result != null)
                {
                    response.shiftRulesModels = result;
                    response.Status = parameters.Get<int>("@status");
                    response.Message = parameters.Get<string>("@message");
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
