
using System.Collections.Generic;


namespace Dto.Model.Common
{

    //------------------------Attendance Model ------------------------------------
    public class AttendanceModal
    {
        public int AttendanceID { get; set; }
        public int EmployeeID { get; set; }
        public string InDate { get; set; }
        public string OutDate { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public int CreatedBy { get; set; }
        public int CompanyID { get; set; }
    }


    //------------------------Attendance Model List  ------------------------------------
    public class AttendanceViewModels : Response
    {
        public List<AttendanceModal> AttendanceModel { get; set; }
        public List<SelectAttendanceModal> TotalTimeAttendanceModel { get; set; }
    }

    //----------------------- Single Attendance   Model List  ------------------------------------
    public class SingleAttendanceViewModels : Response
    {
        public List<AttendanceModal> SingleAttendanceModelList { get; set; }

        public List<SelectAttendanceModal> TotalTimeAttendanceModel { get; set; }
    }

    //------------------------ Fetch Attendance Model   ------------------------------------

    public class SelectAttendanceModal
    {
        public int EmployeeID { get; set; }
        public string InDate { get; set; }
        public string OutDate { get; set; }
        public string TotalTime { get; set; }

    }

    

    //-----------------------------SummaryReportModel---------------------------------------

    public class SummaryReportModel : Response
    {
        public int EmpCode { get; set; }
        public int TotalDays { get; set; }
        public string UserName { get; set; }
        public int TotalPaidDays { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int CompanyID { get; set; }
        public int EmployeeID { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }

    }
    //------------------------ Fetch SummaryReport Model Years & Months   ------------------------------------
    public class SummaryReportFetchModel : Response    
    {
        public string Months { get; set; }
        public string Years { get; set; }

    }


    //----------------------------------Summary Report Model List--------------------
    public class SummaryReportView : Response
    {
        public List<SummaryReportModel> SingleModelList { get; set; }
    }

    //-------------------------------------- Attendance DetailReport ----------------------------------

    public class AttendanceDetailReportModel : Response
    {
        public int EmployeeID { get; set; }
        public int TotalDays { get; set; }
        public int EmpCode { get; set; }
        public string UserName { get; set; }
        public int CompanyID { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
    }


    //-------------------------------------- Attendance DetailReport List ----------------------------------
    public class AttendanceDettailReportView : Response
    {
        public List<AttendanceDetailReportModel> AttendanceDettailReportList { get; set; }
    }

    //-------------------------------------- Attendance DetailReport for Gernate salary List ----------------------------------
    public class GernateSalaryReportModel 
    {
        public int Uid { get; set; }
        public int EmployeeID { get; set; }
        public int TotalDays { get; set; }
        public int EmpCode { get; set; }
        public string UserName { get; set; }
        public int CompanyID { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }
        public string TotalTime { get; set; }
        public string TCount { get; set; }
        public string InDate { get; set; }
        public string OutDate { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }

    }

    public class GernateSalaryDetailtModel
    {
        public int EmployeeID { get; set; }
        public int TotalDays { get; set; }
        public int EmpCode { get; set; }
        public string UserName { get; set; }
        public int CompanyID { get; set; }
        public int Years { get; set; }
        public string Months { get; set; }
        public int TotalMonthDays { get; set; }
        public int WorkingDays { get; set; }
        public int AbsentDays { get; set; }
        public int FullDays { get; set; }
        public int HalfDays { get; set; }
        public int ShortLeave { get; set; }
        public int LeaveDueLessTime { get; set; }
        public int Wage { get; set; } 

    }
    public class GernateSalaryStructureModels 
    {
        public int EmployeeID { get; set; }
        public string UserName { get; set; }
        public int CompanySalrayComponentId { get; set; }
        public int Wages { get; set; }
        public int IncomeTypeId { get; set; }
        public string CalculateValues { get; set; }
        public string ComponentValue { get; set; }
        public string DisplayName { get; set; }
    }
    public class FeildName
    {
        public string Name { get; set; }
    }
    //-----------------------  Gernatesalary   Model List  ------------------------------------
    public class GernateSalaryViewModels : Response
    {
        public List<GernateSalaryReportModel> ReportModelList { get; set; }

        public List<GernateSalaryDetailtModel> DetailModelList { get; set; }

        public List<GernateSalaryStructureModels> SalaryBreakUpModelList { get; set; }

        public List<FeildName> SalaryBreakUpFeildNameList { get; set; }
    }


}

