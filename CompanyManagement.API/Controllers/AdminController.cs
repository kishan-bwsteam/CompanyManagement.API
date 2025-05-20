using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Helper;
using CompanyManagement.Service.Interface;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(AdminDetails model)
        {
            var id = User.FindFirst("userID").Value;
            var ActionBy = Int32.Parse(id);
            var res = _adminService.SaveUpdate(model, ActionBy);
            return Ok(res);
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAdminList([FromQuery] int? limit, int? startingRow, string? search)
        {
            var res = _adminService.GetAdminList(limit.GetValueOrDefault(10), startingRow.GetValueOrDefault(0),search);
            return Ok(res);
        }
        [HttpGet("{AdminId}")]
        public IActionResult GetAdminList(int AdminId)
        {
            var res = _adminService.GetAdmin(AdminId);
            return Ok(res);
        }
        [HttpDelete("{AdminId}")]
        public IActionResult Delete(int AdminId)
        {
            var res = _adminService.DeleteAdmin(AdminId);
            return Ok(res);
        }
    }
}
