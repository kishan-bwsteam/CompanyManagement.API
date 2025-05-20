using CompanyManagement.Datas.Concrete;
using Dapper;
using Dto.Model.Common;
using Dto.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDapper.Abstract;
using CompanyManagement.Repository.Interface;
using Datas.Abstract;
using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Domain.Model;
using Microsoft.IdentityModel.Tokens;

namespace CompanyManagement.Repository.Repositories
{
    public class AdminRepository:IAdminRepository
    {


        public readonly IDatabaseContext _idb_context;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public AdminRepository(IDatabaseContext _dbcontext, ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _idb_context = _dbcontext;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        public Response SaveUpdate(AdminDetails model, DataTable dt, int ActionBy, EncryptHelperModel credentials)
        { 
            Response response = new Response();
            try
            {
                //DataTable dt = new DataTable();
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@ActionBy", ActionBy);
                parameters.Add("@UserID", model.UserID);
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@MiddleName", model.MiddleName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@UserName ", model.UserName);
                parameters.Add("@IsActive ", 1);
                parameters.Add("@UserTypeID", 2);
                parameters.Add("@EmailID ", model.EmailID);
                parameters.Add("@PassKeyId", 1);
                parameters.Add("@PassKey ", credentials.Value);
                parameters.Add("@SaltKey", credentials.SaltKey);
                parameters.Add("@SaltKeyIV", credentials.SaltKeyIV);
                parameters.Add("@AddressTypeId ", 1);
                parameters.Add("@City ", model.City);
                parameters.Add("@StateId ", model.StateId);
                parameters.Add("@ZipCode ", model.ZipCode);
                parameters.Add("@CountryID ", model.CountryId);
                parameters.Add("@AddressLine1", model.AddressLine1);
                parameters.Add("@AddressLine2", model.AddressLine2);



                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                parameters.Add("@companydetails", dt, DbType.Object);


                var result = _idb_context.Query<string>("SaveUpdateUser", parameters, null, CommandType.StoredProcedure);
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

        public PaginatedResult<AdminDetails> Get(DataTable filters, int limit, int startingRow)
        {
            PaginatedResult<AdminDetails> result = new PaginatedResult<AdminDetails>();
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

                result.Data = _idb_context.Query<AdminDetails>("GetAdmin", parameters, commandType: CommandType.StoredProcedure);
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

    }
}
