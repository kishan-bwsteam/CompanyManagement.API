using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
  public  class CompanyRepository : ICompanyRepository
    {
        public readonly IDatabaseContext dbcontext;
        public CompanyRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }

      

        public DropdownListModel GetAll(int userId)
        {
            DropdownListModel report = new DropdownListModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@userID", userId);
                //parameters.Add("@FranchiseID", model.FranchiseID);

                var _report = dbcontext.Query<DropdownCompanyListModel>("DropDownCompany", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.Dropdowncompanylist = _report;
                        if (report.Dropdowncompanylist == null)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Comapanies Detail not found";
                        }
                    }
                    else
                    {
                        report.Dropdowncompanylist = null;
                    }
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

        public IEnumerable<CompanyModel> Get(DataTable filters, int limit, int startingRow)
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

                var result = dbcontext.Query<CompanyModel>("GetCompany", parameters, commandType: CommandType.StoredProcedure);

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

        public DropdownListModel Get(int companyID)
        {
            DropdownListModel report = new DropdownListModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                //parameters.Add("@userID", userId);
                parameters.Add("@CompanyID", companyID);


                var _report = dbcontext.Query<DropdownCompanyListModel>("DropDownCompanyByCompanyID", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.Dropdowncompanylist = _report;
                        if (report.Dropdowncompanylist == null)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Company Details not found";
                        }
                    }
                    else
                    {
                        report.Dropdowncompanylist = null;
                    }
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

        public Response SaveUpdate(CompanyModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanyID", model.CompanyId);
                parameters.Add("@UserID", model.UserID);
                parameters.Add("@CompanyName", model.CompanyName);
                parameters.Add("@GSTIN", model.GSTIN);
                parameters.Add("@CIN", model.CIN);
                parameters.Add("@AddressLine1", model.AddressLine1);
                parameters.Add("@AddressLine2", model.AddressLine2);
                parameters.Add("@City", model.City);
                parameters.Add("@StateId", model.StateId);
                parameters.Add("@CountryId", model.CountryId);
                parameters.Add("@ZipCode", model.ZipCode);
                parameters.Add("@Status", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Message", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);

                dbcontext.Execute("CreateUpdateCompany", parameters, commandType: CommandType.StoredProcedure);

                response.Status = parameters.Get<int>("@Status");
                response.Message = parameters.Get<string>("@Message");

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

        public Response Delete(int companyID)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyID", companyID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = dbcontext.Query<string>("Delete_Company", parameters, null, CommandType.StoredProcedure);
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
