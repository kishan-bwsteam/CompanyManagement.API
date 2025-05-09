using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.salary
{
    [Route("api/SalaryStructure/")]
    [ApiController]
    public class SalaryStructureController : Controller
    {
        private readonly ISalaryService _salaryService;

        public SalaryStructureController(ISalaryService salaryService)
        {
            
            _salaryService = salaryService;
           
        }
//------------------------------------------------------------------------save
        [HttpPost]
 
        public Response SaveUpdateSalary(CompanySalaryStructureModel model)
        {
            try
            {
                return _salaryService.SaveUpdateSalaryStructure(model);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

//------------------------------------------------------------------------delete
        [HttpDelete("DeleteSalary/{SalaryComponentId}")]
      
        public Response DeleteSalary(int SalaryComponentId)
        {
            try
            {
                return _salaryService.DeleteSalaryStructure(SalaryComponentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
//-------------------------------------------------------------------------getAll
        [HttpGet("GetAll/{companyId}")]
       
        public CompanySalaryStructreView GetAllSalary(int companyId)
        {
            try
            {
                return  _salaryService.GetAllSalaryStructure(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //-------------------------------------------------------------------------getSingle
        [HttpGet("GetSingle/{structureId}")]

        public CompanySalaryStructureModel GetSingleSalary(int structureId)
        {
            try
            {
                return _salaryService.GetSingleSalaryStructure(structureId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
