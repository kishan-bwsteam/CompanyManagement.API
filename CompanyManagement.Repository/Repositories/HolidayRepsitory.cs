using CompanyManagement.Domain.Model;
using CompanyManagement.Repository.Interface;
using Dapper;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.Data.SqlClient;
using SqlDapper.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CompanyManagement.Repository.Repositories
{
    public class HolidayRepsitory : IHolidayRepsitory
    {
        public readonly IDatabaseContext _idb_context;

        public HolidayRepsitory(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }
        public Response SaveOrUpdate(HolidayModel model, int actionBy)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@HolidayID", model.HolidayID);
                parameters.Add("@CompanyID", model.CompanyID);
                parameters.Add("@HolidayDate", model.HolidayDate);
                parameters.Add("@HolidayName", model.HolidayName);
                parameters.Add("@ActionBy", actionBy);
                parameters.Add("@ReturnHolidayID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                _idb_context.Execute("SaveOrUpdateHoliday",
                                     parameters,
                                     commandType: CommandType.StoredProcedure);
                var res = new Response
                {
                    Status = 200,
                    Message = model.HolidayID > 0 ? "Holiday Details Updated" : "Holiday Details Created"
                };

                model.HolidayID = parameters.Get<int>("@ReturnHolidayID");
                return res;
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
        public PaginatedResult<HolidayModel> Get(DataTable filters, int limit, int startingRow)
        {
            PaginatedResult<HolidayModel> result = new PaginatedResult<HolidayModel>();
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
                parameters.Add("@totalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

                result.Data = _idb_context.Query<HolidayModel>("GetHolidays", parameters, commandType: CommandType.StoredProcedure);
                result.TotalRecords = parameters.Get<int>("@totalRecords");
                result.limit = limit;
                result.startingRow = startingRow;
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
        public Response Delete(int HolidayID, int actionBy)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@HolidayID", HolidayID);
                parameters.Add("@ActionBy", actionBy);

                var res = _idb_context.Execute("Delete_holiday",
                                     parameters,
                                     commandType: CommandType.StoredProcedure);

                return new Response
                {
                    Status = res > 0 ? 200 : 400,
                    Message = res > 0 ? "Holiday deleted successfully" : "Somthing went wrong!!"
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
    }
}
