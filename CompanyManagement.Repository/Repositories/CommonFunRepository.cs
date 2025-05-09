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
    public class CommonFunRepository : ICommonRepository
    {
        public readonly IDatabaseContext _idb_context;
        public CommonFunRepository(IDatabaseContext databaseContext)
        {
            _idb_context = databaseContext;
        }



        //-------------------------------------------Get Country Dropdown-------------------------------------------------------
        public CountryDropdown GetCountry( )

        {
            CountryDropdown report = new CountryDropdown();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var _report = _idb_context.Query<CommonFunModel>("GetCountryDropdown", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.dropdowncountry = _report;
                        if (report.dropdowncountry.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Company Detail not found";
                        }
                    }
                }
                else
                {
                    report.dropdowncountry = null;
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





        //--------------------------------------------Get State Dropdown-----------------------------------------------------------

        public StateDropdown GetState()

        {
            StateDropdown report = new StateDropdown();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                
                var _report = _idb_context.Query<CommonFunModel>("GetStateDropdown", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.dropdownState = _report;
                        if (report.dropdownState.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "State Detail not found";
                        }
                    }
                }
                else
                {
                    report.dropdownState = null;
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
