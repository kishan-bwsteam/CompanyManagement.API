using CompanyManagement.Domain.Model;
using CompanyManagement.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HolidayController : ControllerBase
    {

        private readonly IHolidayService _holidayService;
        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }
        [HttpPost]
        public IActionResult SaveUpdate(HolidayModel model)
        {
            var id = User.FindFirst("userID").Value;
            var UserId = Int32.Parse(id);
            var res = _holidayService.SaveUpdate(model, UserId);
            return Ok(res);
        }
        [HttpGet("{HolidayId}")]
        public IActionResult GetByHolidayId(int HolidayId)
        {
            var res = _holidayService.GetById(HolidayId);
            return Ok(res);
        }
        [HttpGet("company/{companyID}")]
        public IActionResult Get(int companyID, [FromQuery] int? limit, int? startingRow, string? search)
        {
            var res = _holidayService.GetAll(companyID, limit.GetValueOrDefault(), startingRow.GetValueOrDefault(0), search);
            return Ok(res);
        }
        [HttpGet("Employee")]
        [Authorize]
        public IActionResult Get([FromQuery] int year)
        {
            var id = User.FindFirst("userID").Value;
            var UserId = Int32.Parse(id);
            var res = _holidayService.GetByUserId(UserId,year);
            return Ok(res);
        }
        [HttpDelete("{holidayId}")]
        public IActionResult Delete(int holidayId)
        {
            var id = User.FindFirst("userID").Value;
            var ActionBy = Int32.Parse(id);
            var res = _holidayService.Delete(holidayId, ActionBy);
            return Ok(res);
        }

    }
}
