using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
  public   class SummaryRepository : ISummaryRepository
    {
        public readonly IDatabaseContext _idb_context;
        public SummaryRepository(IDatabaseContext databaseContext)
        {
            _idb_context = databaseContext;
        }


        //---------------------Get Summary Report By SummaryReportView-------------------------------


        public SummaryReportView GetSummary(SummaryReportFetchModel model,int companyId)
        {
            SummaryReportView report = new SummaryReportView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanyID", companyId);
                parameters.Add("@Months", model.Months);
                parameters.Add("@Years", model.Years);



                var _report = _idb_context.Query<SummaryReportModel>("GetSummmaryReport", parameters, commandType: CommandType.StoredProcedure).ToList();
                {

                   
                        report.SingleModelList = _report;

                    if (report.SingleModelList.Count == 0)
                    {
                        report.Status = (int)ErrorStatus.Error;
                        report.Message = "Summary Report not found";

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



        //---------------------Get Attendance Details Report By AttendanceDettailReportView-------------------------------
        public AttendanceDettailReportView GetAttendance(SummaryReportFetchModel model, int employeeID)
        {
            AttendanceDettailReportView report = new AttendanceDettailReportView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@Months", model.Months);
                parameters.Add("@Years", model.Years);
                parameters.Add("@EmpID", employeeID);



                var _report = _idb_context.Query<AttendanceDetailReportModel>("GetSummmaryDetailReport", parameters, commandType: CommandType.StoredProcedure).ToList();
                {

                   
                        report.AttendanceDettailReportList = _report;

                        if (report.AttendanceDettailReportList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Attendance Report not found";
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
