using CompanyManagement.Domain.Model.Common;
using CompanyManagement.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        private readonly IAddressTypeService _service;

        public AddressTypeController(IAddressTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _service.GetAllAsync();
            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdate(AddressType addressType)
        {
            await _service.SaveOrUpdateAsync(addressType);
            return Ok(new { message = "Saved successfully" });
        }
    }
}
