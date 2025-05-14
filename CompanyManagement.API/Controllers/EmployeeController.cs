using CompanyManagement.Service.Interface;
using Dto.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System.Collections.Generic;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _empService;
        private readonly IEmployeeDetailService _empDetailService;
        public EmployeeController(IEmployeeService employeeService, IEmployeeDetailService employeeDetailService)
        {
            _empService = employeeService;
            _empDetailService = employeeDetailService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(EmployeeModel emp)
        {
            
            var id = User.FindFirst("userID").Value;
            emp.ActionBy = Int32.Parse(id);
            //emp.UserBasic.ParentUserID = Int32.Parse(id);
            var retObj = _empService.Create(emp);
            return Ok(retObj);
        }
        [HttpPatch]
        [Authorize]
        public IActionResult Update(EmployeeDetail emp)
        {
            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            //emp.UserBasic.ParentUserID = Int32.Parse(id);
            var retObj = _empDetailService.SaveUpdate(emp, actionBy);
            return Ok(retObj);
        }


        [HttpGet]
        public IActionResult Get([FromQuery]int? UserId,int? EmpId)
        {
            if (UserId == null && EmpId == null) return NotFound();
            EmployeeDetail emp;
            if (EmpId != null)
            {
                emp = _empService.GetByEmpId(EmpId.GetValueOrDefault());
            }
            else
            {
                emp = _empService.GetByUserId(UserId.GetValueOrDefault());
            }
            return Ok(emp);
        }
        [HttpDelete("{EmpId}")]
        [Authorize]
        public IActionResult Delete(int EmpId)
        {
            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            var result = _empService.Delete(EmpId, actionBy);
            return Ok(result);
        }
    }
}
