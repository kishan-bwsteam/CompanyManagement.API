using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace CompanyManagement.Controllers
{
    [Route("api/EmployeePerformance/")]
    [ApiController]
    public class EmployeePerformanceController : Controller
    {
        private readonly IEmployeePerformanceService _employeePerformanceService;
        private readonly IConfiguration _configuration;
        public EmployeePerformanceController(IEmployeePerformanceService employeePerformanceService, IConfiguration configuration)
        {
            _employeePerformanceService = employeePerformanceService;
            _configuration = configuration;
        }

        [HttpPost]
        public Response SaveUpdate(EmployeePerformanceList employeePerformance)
        {
            
            try
            {
                return _employeePerformanceService.SaveUpdate(employeePerformance);
            }
            catch (System.Exception)
            {

                return null;
            }
        }
        [HttpGet ("Employee/{companyId}")]
        public List<EmployeePerformance> GetAll( int companyId)
         {
            try
            {
                var data = _employeePerformanceService.GetAll(companyId);
                return data;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EmployeePerformanceModel employeePerformance = _employeePerformanceService.GetById(id);
            if (employeePerformance == null)
            {
                return NotFound();
            }
            return Ok(employeePerformance);
        }
        [HttpDelete("{id}")]
        public Response DeleteById(int id)
        {
            Response employeePerformance=new Response();
            try
            {
                employeePerformance = _employeePerformanceService.EmployeePerformanceDelete(id);
            }
            catch (System.Exception)
            {

                throw;
            }
            return employeePerformance;
        }
    }
}
