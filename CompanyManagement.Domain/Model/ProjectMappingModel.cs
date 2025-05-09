

using System.Collections.Generic;

namespace Dto.Model.Common
{
   public class ProjectMappingModel 
    {
       public int ProjectMappingID { get; set; }
        public int UserID { get; set; }
        public string EmployeeName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int CompanyID { get; set; }
        public int EmpCode { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public bool Mapping { get; set; }

    }
    public class MultipleMappingView :Response
    {
        public  List<ProjectMappingModel> EmployeeMapppingList { get; set; }

    }
    public class SingleMappingView : Response
    {
        public ProjectMappingModel? SingleMappingList { get; set; }
    }
   
}
