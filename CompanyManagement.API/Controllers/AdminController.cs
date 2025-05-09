using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Interface;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public Response SaveUpdate(MultiformModel model)
        {
            try
            {
                return _adminService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAdminList([FromQuery] int limit, int startingRow)
        {
            var res = _adminService.GetAdminList(limit, startingRow);
            return Ok(res);
        }

    }
}
