using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{
    public class SalaryModel
    {
        public int SalaryComponentId { get; set; }
        public string Name { get; set; } 
        public string IncomeType { get; set; }
        public int CompanyId { get; set; }
        public string ComponentValue { get; set; } 
        public string IncomeHead { get; set; }
        public string ComponentType { get; set; }
        public int CreatedBy { get; set; }
        public string DisplayOrder { get; set; }
        public string TokenName { get; set; }
    }


    public class SalaryStructureModel: Response
    {
        public string SalaryStructure { get; set; }
        public int StructureId { get; set; }
        public int CompanyId { get; set; }
        public List<SalaryNameModel> salaryname { get; set; }
    }
    public class SalaryViewModel : Response
    {
        public List<SalaryModel> SalaryViewModelList { get; set; }
    }
    public class SingleSalaryModel : Response
    { 
     public SalaryModel SSModel { get; set; }
    }

    public class SalaryNameModel
    {
        public string SalaryName { get; set; }
        public int IncomeTypeId { get; set; }
        public string ComponentValue { get; set; }
        public int SalaryComponentID { get; set; }
        public long CompSalCompoDetID { get; set; }
        public int CompanySalaryComponentID { get; set; }
        public int ComponentTypeId { get; set; }
        public string TypeName { get; set; }
        public int CompanyId { get; set; }
        public string DisplayName { get; set; }
        public bool Status { get; set; }
        public string Formula { get; set; }
    }
    public class SalaryNameViewModel:Response
    {
        public List<SalaryNameModel> salaryname { get; set; }
    }


    public class GetSalaryComponentType
    {
        public string TypeName { get; set; }
        public int ComponentTypeId { get; set; }
    }
    public class GetSalaryComponentTypeView : Response
    {
        public List<GetSalaryComponentType> SalaryComponentTypes { get; set; }
        
    }

    public class UpdateFeildName
    {
        public int SalaryComponentID { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int UpdatedBy { get; set; }
    }

    public class GetSalaryStructure
    {
        public int CompanySalrayComponentId { get; set; }

        public int CompanyId { get; set; }

        public string SalaryStructureName { get; set; }
    }


}

    

