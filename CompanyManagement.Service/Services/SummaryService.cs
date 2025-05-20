using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class SummaryService : ISummaryService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly ISummaryRepository _iSummaryRepository;


        public SummaryService(ISummaryRepository _summaryRepository)
        {
            _iSummaryRepository = _summaryRepository;
        }



        //---------------------Get Summary Report By SummaryReportView-------------------------------
        public SummaryReportView GetSummary(SummaryReportFetchModel model,int companyId)
        {
            try
            {
                return _iSummaryRepository.GetSummary(model, companyId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------------Attendance Detail Report------------------------------ 

        public AttendanceDettailReportView GetAttendance(SummaryReportFetchModel model, int employeeID)
        {

            try
            {
                return _iSummaryRepository.GetAttendance(model, employeeID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
