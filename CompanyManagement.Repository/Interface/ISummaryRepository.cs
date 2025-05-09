using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datas.Abstract
{
    public interface ISummaryRepository
    {
        //---------------------Get Summary Report By SummaryReportView-------------------------------
        SummaryReportView GetSummary(SummaryReportFetchModel model,int companyId);

        //---------------------Get Attendance Details Report By AttendanceDettailReportView-------------------------------

        AttendanceDettailReportView GetAttendance(SummaryReportFetchModel model, int employeeID);

    }
}
