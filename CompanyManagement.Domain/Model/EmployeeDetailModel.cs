using Dto.Model.Common;
using System.Collections.Generic;

namespace Dto.Model
{

    //-----------------------------------------------------Employee Details Model-----------------------------------

    public class EmployeeDetailModel
    {

        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public long UserID { get; set; }
        public long CreatedBy { get; set; }
        public int CompanyID { get; set; }
        public string Email { get; set; }
        public long EmployeeID { get; set; }
        public string RoleName { get; set; }
        public int DepartmentID { get; set; }
        
    }


    //--------------------------------------------Employee Details Model List----------------------------------


    public class EmployeeDetailViewModels : Response
    { 
    public List<EmployeeDetailModel> EmployeeDetailList { get; set; }
    }
      
}
