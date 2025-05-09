using CompanyManagement.Domain.Model;
using CompanyManagement.Repository.Interface;
using Dapper;
using Dto.Model;
using Microsoft.Data.SqlClient;
using SqlDapper.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Repository.Repositories
{
    public class CountryStateRepository:ICountryStateRepository
    {
        public readonly IDatabaseContext _idb_context;

        public CountryStateRepository(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }


        public IEnumerable<CountryStateModel> Get(DataTable filters, int limit, int startingRow)
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

                var result = _idb_context.Query<CountryStateModel>("GetCountryStates", parameters, commandType: CommandType.StoredProcedure);

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
