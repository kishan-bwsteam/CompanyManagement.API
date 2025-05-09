using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.Summary
{
    [Route("api/Summary")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService _isummaryService;
        private readonly IConfiguration _iconfig;

        public SummaryController(ISummaryService _summaryService, IConfiguration _config)
        {
            _isummaryService = _summaryService;
            _iconfig = _config;
        }


        //----- -----------------------SummaryReport Report------------------------------ 

        [HttpGet]
        // [Route("GetSummary")]


        public SummaryReportView GetSummary(string month,string year,int companyId)
        {

            try
            {
                SummaryReportFetchModel model = new SummaryReportFetchModel();
                model.Months = month;model.Years = year;
                return _isummaryService.GetSummary(model, companyId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //---------------------Get Attendance Details Report By AttendanceDettailReportView-------------------------------

        [HttpGet("month/{month},year/{year},employee/{employeeID}")]

        public AttendanceDettailReportView GetAttendance(string month, string year, int employeeID)
        {

            try

            {
                SummaryReportFetchModel model = new SummaryReportFetchModel();
                model.Months = month; model.Years = year;
                
                return _isummaryService.GetAttendance(model, employeeID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
