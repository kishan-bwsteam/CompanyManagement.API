using CompanyManagement.Domain.Model;
using CompanyManagement.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/country
        [HttpGet]
        public ActionResult<IEnumerable<CountryModel>> GetAllCountries()
        {
            try
            {
                var countries = _countryService.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving countries: {ex.Message}");
            }
        }

        // GET: api/country/5
        [HttpGet("{id}")]
        public ActionResult<CountryModel> GetCountryById(int id)
        {
            try
            {
                var country = _countryService.Get(id);
                if (country == null)
                    return NotFound($"Country with ID {id} not found.");

                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving country ID {id}: {ex.Message}");
            }
        }
    }
}
