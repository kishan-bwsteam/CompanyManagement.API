using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
   public  class CalLeaveModel
    {
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public int TotalLeavs { get; set; }
        public int PresentDay { get; set; }

    }

    public class CalLeaveViewModel : Response
    {
        public List<CalLeaveModel> CalLeaveList { get; set; }
    }

    //-------------------------------- Single Address Model List------
    public class singleCalLeaveViewModel : Response
    {
        public CalLeaveModel SingleModelList { get; set; }
    }

    public class RequestLeave : Response
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int EmployeeID { get; set; }
    }
}
