using Dto.Model.Common;


namespace Service.Abstract
{
    public interface ISummaryService
    {

        //---------------------Get Summary Report By SummaryReportView-------------------------------
        SummaryReportView GetSummary(SummaryReportFetchModel model, int companyId);

        //---------------------Get Attendance Details Report By AttendanceDettailReportView-------------------------------

        AttendanceDettailReportView GetAttendance(SummaryReportFetchModel model, int employeeID);
    }
}
