using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Datas.Concrete
{
    public class EmpAddressRepository : IEmpAddressRepository
    {
        public readonly IDatabaseContext db_context;
        public EmpAddressRepository(IDatabaseContext _db_context)
        {
            db_context = _db_context;
        }




        //------------------------------- Save Update Address ---------------------------

        public Response SaveOrUpdate(UserAddress addr, int actionBy)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserAddressId", addr.UserAddressId); // 0 or actual ID
                parameters.Add("@UserID", addr.UserID);
                parameters.Add("@AddressLine1", addr.AddressLine1);
                parameters.Add("@AddressLine2", addr.AddressLine2);
                parameters.Add("@City", addr.City);
                parameters.Add("@StateId", addr.StateId);
                parameters.Add("@CountryId", addr.CountryId);
                parameters.Add("@ZipCode", addr.ZipCode);
                parameters.Add("@AddressTypeID", addr.AddressTypeID);
                parameters.Add("@ActionBy", actionBy);

                db_context.Execute("SaveOrUpdateUserAddress",
                                     parameters,
                                     commandType: CommandType.StoredProcedure);

                return new Response
                {
                    Status = 200,
                    Message = addr.UserAddressId > 0 ? "Address Updated" : "Address Created"
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


        //----------------------- Get All Address by AddressViewModel------------------------------

        public AddressViewModel GetAddress()
        {
            AddressViewModel report = new AddressViewModel();

            try


            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                var _report = db_context.Query<AddressModel>("GetAllAddress", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.AddressModelList = _report;

                        if (report.AddressModelList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Address not found";
                        }
                    }
                }
                else
                {
                    report.AddressModelList = null;
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




        //----------------------------Get Single Address by UserAddressID-------------------------------



        public singleAddressViewModel GetSingle(int UserID)
        {
            singleAddressViewModel report = new singleAddressViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@UserID", UserID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


                var _report = db_context.Query<AddressModel>("GetSingle_EmpAddress", parameters, null, CommandType.StoredProcedure);
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.SingleModelList = _report.FirstOrDefault();
                        if (report.SingleModelList == null)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Address Details not found";
                        }
                    }
                    else
                    {
                        report.SingleModelList = null;
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



        //----------------------------Delete Address by UserAddressID-------------------------------



        public Response Delete(int userAddressID)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserAddressID", userAddressID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = db_context.Query<string>("Delete_EmpAddress", parameters, null, CommandType.StoredProcedure);
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





        //----------------------- Get All Country by CountryViewModel------------------------------


        public CountryViewModel GetAll()
        {
            CountryViewModel report = new CountryViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var _report = db_context.Query<CountryDropdownModel>("GetCountryDropdown", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.CountryList = _report;
                        if (report.CountryList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Country not found";
                        }
                    }
                }
                else
                {
                    report.CountryList = null;
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


        ////----------------------- Get All State by StateViewModel------------------------------


        public StateViewModel GetAllState()
        {
            StateViewModel report = new StateViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var _report = db_context.Query<StateDropdownModel>("GetStateDropdown", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.StateList = _report;
                        if (report.StateList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "State not found";
                        }
                    }
                }
                else
                {
                    report.StateList = null;
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

        public IEnumerable<UserAddress> Get(DataTable filters, int limit, int startingRow)
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

                var result = db_context.Query<UserAddress>("GetAddress", parameters, commandType: CommandType.StoredProcedure);

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




