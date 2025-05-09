
using CompanyManagement.Repository.Interface;
using Dapper;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.Data.SqlClient;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;

namespace CompanyManagement.Repository.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        public readonly IDatabaseContext _idb_context;
        public EmployeeRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }

        public Response SaveEmployee(EmployeeModel emp)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActionBy", emp.ActionBy);
                parameters.Add("@UserId", emp.UserID);
                parameters.Add("@FirstName", emp.UserBasic.FirstName);
                parameters.Add("@LastName", emp.UserBasic.LastName);
                parameters.Add("@MiddleName", emp.UserBasic.MiddleName);
                parameters.Add("@UserName", emp.UserBasic.UserName);
                parameters.Add("@UserTypeID", emp.UserBasic.UserTypeID);
                parameters.Add("@ParentUserID", emp.UserBasic.ParentUserID);

                parameters.Add("@EmailID", emp.EmailID);

                parameters.Add("@EmpCode", emp.EmpCode, System.Data.DbType.String);
                parameters.Add("@DOB", emp.DOB.Date, System.Data.DbType.Date);
                parameters.Add("@DOH", emp.DOH.Date, System.Data.DbType.Date);
                parameters.Add("@DepartmentID", emp.DepartmentID, System.Data.DbType.Int32);
                parameters.Add("@EmployeeStatusID", emp.EmployeeStatusID, System.Data.DbType.Int32);
                parameters.Add("@BloodGroup", emp.BloodGroup, System.Data.DbType.String);
                parameters.Add("@CompanyId", emp.CompanyId, System.Data.DbType.Int32);
                parameters.Add("@RoleId", emp.RoleId, System.Data.DbType.Int32);

                parameters.Add("@PassKey", emp.UserPassKey?.PassKey);
                parameters.Add("@SaltKey", emp.UserPassKey?.SaltKey);
                parameters.Add("@SaltKeyIV", emp.UserPassKey?.SaltKeyIV);

                // TVP for Address
                var addressTVP = new DataTable();
                addressTVP.Columns.Add("AddressTypeID", typeof(int));
                addressTVP.Columns.Add("AddressLine1", typeof(string));
                addressTVP.Columns.Add("AddressLine2", typeof(string));
                addressTVP.Columns.Add("City", typeof(string));
                addressTVP.Columns.Add("StateId", typeof(string));
                addressTVP.Columns.Add("CountryId", typeof(string));
                addressTVP.Columns.Add("ZipCode", typeof(string));
                // ... other columns
                foreach (var addr in emp.UserAddress)
                    addressTVP.Rows.Add(addr.AddressTypeID, addr.AddressLine1, addr.AddressLine2, addr.City, addr.StateId, addr.CountryId, addr.ZipCode);

                parameters.Add("@UserAddresses", addressTVP.AsTableValuedParameter("dbo.UserAddressType"));

                // Same for Education
                var eduTVP = new DataTable();
                eduTVP.Columns.Add("DegreeName", typeof(string));
                eduTVP.Columns.Add("InstName", typeof(string));
                eduTVP.Columns.Add("PassingYear", typeof(string));
                eduTVP.Columns.Add("Percentage", typeof(string));

                foreach (var edu in emp.UserEducation)
                    eduTVP.Rows.Add(edu.DegreeName, edu.InstName, edu.PassingYear.Date, edu.Percentage);

                parameters.Add("@UserEducation", eduTVP.AsTableValuedParameter("dbo.UserEducationType"));

                parameters.Add("@BankName", emp.UserBankDetail.BankName);
                parameters.Add("@IFSCCode", emp.UserBankDetail.IFSCCode);
                parameters.Add("@AccountNo", emp.UserBankDetail.AccountNo);
                var result = _idb_context.Query<int>("SaveEmployee",
                                                    parameters,
                                                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (result > 0)
                {
                    return new Response() { Status = 200, Message = "Employee Created" };
                }
                else
                {
                    return new Response() { Status = 400, Message = "Somthing went wrong!!" };

                }
            }
            catch (Exception ex)
            {
                return new Response() { Status = 500, Message = ex.Message };
            }
        }



        public IEnumerable<EmployeeModel> Get(DataTable filters, int limit, int startingRow)
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

                var result = _idb_context.Query<EmployeeModel>("GetEmployee", parameters, commandType: CommandType.StoredProcedure);

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
