using Dto.Model.Common;
using System;
using System.Collections.Generic;


namespace Dto.Model
{

//---------------------------------------Wages Model ---------------------------------
   public class WagesModel:Response
    {

        public DateTime Startdate { get; set; }
        public int WagesType { get; set; }
        public string FileAttachment { get; set; }
        public long UserID { get; set; }
        public int WagesID { get; set; }
        public int Wages { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int CompanySalrayComponentId { get; set; }
        public int CompanyID { get; set; }
        public int GrossSalary { get; set; }
        public int TotalDeductions { get; set; }
        public int CTCDeducation { get; set; }
        public int WagesDetailsID { get; set; }
      
  
 





    }


    public class WagesStructureModel:Response
    {
        public int GrossSalary { get; set; }
        public int TotalDeductions { get; set; }
        public int CTCDeducation { get; set; }
        public int NetSalary { get; set; }
        public int CTC { get; set; }
        public string Calculate_value { get; set; }
        public string DisplayName { get; set; }
        public int Yearly { get; set; }
        public int UserID { get; set; }
        public int ComponentTypeId { get; set; }
        public int CompanySalaryComponentDetailID { get; set; }
        public int IncomeTypeId { get; set; }
      
    }


    //---------------------------------------Wages Model List---------------------------------
    public class WagesModelView :Response
    {
        public List<WagesModel> WagesModelList { get; set; }
    }


    public class MultiWagesModelView : Response
    {
        public List<WagesStructureModel> multiStructureList { get; set; }
    }

    public class SingleWagesModelView:Response
    {
        public WagesStructureModel SingleStructureList { get; set; }
    }
}
