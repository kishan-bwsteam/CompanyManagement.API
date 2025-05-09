using Dto.Model.Common;
using System;
using System.Collections.Generic;


namespace Dto.Model
{
    public class EmployeePerformance
    {
        public int? EmployeePerformanceId { get; set; }
        public int EmpID { get; set; }
        public int PerformanceAttributeId { get; set; }
        public string AttributeValue { get; set; }
        public string CompanyID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string RoleName { get; set; }

       


    }

    public class EmployeePerformanceList
    {
        public List<EmployeePerformance> Attribute { get; set; }
    }
    

    public class EmployeePerformanceModel:Response
    {
        public EmployeePerformance? SingleEmployeePerformanceList { get;set; }
    }
}

