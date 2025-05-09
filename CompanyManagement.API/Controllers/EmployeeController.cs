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


        [HttpGet("{UserId}")]
        public IActionResult Get(int UserId)
        {
            var emp = _empService.Get(UserId);
            return Ok(emp);
        }
    }
}
