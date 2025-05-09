using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
    public   class EmpBankRepository : IEmpBankRepository
    {
        public readonly IDatabaseContext _idb_context;

        public EmpBankRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }

        // -----------------------------Save And Update Bank Details------------------------ 

        public Response SaveOrUpdate(UserBankDetail model, int actionBy)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@BankDetailID", model.BankDetailID); // 0 or actual ID
                parameters.Add("@UserID", model.UserID);
                parameters.Add("@BankName", model.BankName);
                parameters.Add("@IFSCCode", model.IFSCCode);
                parameters.Add("@AccountNo", model.AccountNo);
                parameters.Add("@ActionBy", actionBy);

                _idb_context.Execute("SaveOrUpdateUserBankDetail",
                                     parameters,
                                     commandType: CommandType.StoredProcedure);

                return new Response
                {
                    Status = 200,
                    Message = model.BankDetailID > 0 ? "Bank Details Updated" : "Bank Details Created"
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

        //----------------------------Get all Bank Details by BankViewModels (List)-------------------

        public BankViewModels GetAll()
        {
            BankViewModels report = new BankViewModels();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                var _report = _idb_context.Query<BankModel>("GetUserBankDetails", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.banklist = _report;

                        if (report.banklist.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "User not found";
                        }
                    }
                }
                else
                {
                    report.banklist = null;
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

        public IEnumerable<UserBankDetail> Get(DataTable filters, int limit, int startingRow)
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

                var result = _idb_context.Query<UserBankDetail>("GetBankDetails", parameters, commandType: CommandType.StoredProcedure);

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
