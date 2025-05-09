using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
   public class EmployeeProjectModel
    {

        public int EmployeeProjectTimeId { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TotalHours { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
        public int CompanyID { get; set; }
   
}
    public class EmployeeProjectList:Response
    { 
        public List<EmployeeProjectModel> EmpProjectListModel { get; set; }
    }
    }
