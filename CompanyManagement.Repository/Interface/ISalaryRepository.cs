using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datas.Abstract
{
 public   interface ISalaryRepository
    {
        Response SaveUpdateSalary(SalaryModel model);

        SalaryViewModel GetAllSalary();

        SingleSalaryModel GetSingleSalary(int salaryComponentId);

        Response DeleteSalary(int salaryComponentId);
        SalaryNameViewModel GetSalaryName(string data);
        GetSalaryComponentTypeView GetSalaryComponentType(int companyid);
        Response UpdateSalVal(SalaryNameModel nameModel,string structureName,int StructureId);
        Response UpdateFeildName(UpdateFeildName nameModel);

        Response SaveUpdateSalaryStructure(CompanySalaryStructureModel model);

        Response DeleteSalaryStructure(int SalaryComponentId);

        CompanySalaryStructreView GetAllSalaryStructure(int companyId);

        CompanySalaryStructureModel GetSingleSalaryStructure(int structureId);
    }
}
