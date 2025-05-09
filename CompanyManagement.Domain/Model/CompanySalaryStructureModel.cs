

using System.Collections.Generic;
using Dto.Model.Common;


namespace Dto.Model
{
   public class CompanySalaryStructureModel :Response
    {
        public int CompanySalrayComponentId { get; set; }
        public int CompanyId { get; set; }
        public string SalaryStructureName { get; set; }
        public int CreatedBy { get; set; }

    }

    public class CompanySalaryStructreView :Response
    {
        public  List<CompanySalaryStructureModel> CompanyStructureList {get;set;}
       
    }
    public class SingleCompanySalaryStructureView :Response
    {
        public CompanySalaryStructureModel SingleModelList { get; set; }
    }
}