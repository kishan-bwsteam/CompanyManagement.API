using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model.Common;
using Microsoft.Data.SqlClient;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;

namespace Datas.Concrete
{
    public class AttandanceRegisterRepository : IAttendanceRegisterRepository
    {

        public readonly IDatabaseContext dbcontext;
        public AttandanceRegisterRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }

        public AttendanceViewModels GetAll(int companyID)
        {
            AttendanceViewModels report = new AttendanceViewModels();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@CompanyID", companyID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                using (var multi = dbcontext.QueryMultiple("GetAllEmployeeAttendanceRegister", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.AttendanceModel = (List<AttendanceModal>)multi.Read<AttendanceModal>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.TotalTimeAttendanceModel = (List<SelectAttendanceModal>)multi.Read<SelectAttendanceModal>();
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

        public GernateSalaryViewModels GernateSalary(int companyID ,int date,int year)
        {
            GernateSalaryViewModels report = new GernateSalaryViewModels();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@CompanyID", companyID);
                parameters.Add("@Months", '0'+date.ToString());
                parameters.Add("@Years", year);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                using (var multi = dbcontext.QueryMultiple("GernateSalaryReport", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.ReportModelList = (List<GernateSalaryReportModel>)multi.Read<GernateSalaryReportModel>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.DetailModelList = (List<GernateSalaryDetailtModel>)multi.Read<GernateSalaryDetailtModel>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.SalaryBreakUpModelList = (List<GernateSalaryStructureModels>)multi.Read<GernateSalaryStructureModels>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.SalaryBreakUpFeildNameList = (List<FeildName>)multi.Read<FeildName>();
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
    }
}
