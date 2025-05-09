using CompanyManagement.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly ICountryStateService _countryStateService;
        public StatesController(ICountryStateService countryStateService)
        {
            _countryStateService = countryStateService;
        }

        [HttpGet("Country/{countryId}")]
        public IActionResult Get([FromRoute]int countryId)
        {
            var result = _countryStateService.GetStatesByCountryId(countryId);
            return Ok(result);
        }
    }
}
