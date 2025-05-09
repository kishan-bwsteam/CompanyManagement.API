
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;

namespace CompanyManagement.Controllers.Company
{
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _icompanyService;
        public CompanyController(ICompanyService _companyService, IConfiguration configuration)
        {
            _icompanyService = _companyService;
          //  _config = configuration;
        }

        [Authorize]
        [HttpGet]
        //[Route("User/{userId}")]
        public IActionResult GetAll([FromQuery]int limit,int startingRow)
        {
            var id = User.FindFirst("userID").Value;

            var retObj = _icompanyService.Get(Int32.Parse(id),limit, startingRow);
            return Ok(retObj);
        }


        //---------------------------------Get All Company By UserID & UserID--------------------------------
        //[Authorize]
        [HttpGet("{companyID:int}")]
        public IActionResult Get(int companyID)
        {
            try
            {

                var result = _icompanyService.GetSingle(companyID);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Ideally log the exception here
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }




        [Authorize]
        [HttpPost]
        public Response SaveUpdate([FromBody] CompanyModel model)
        {
            try
            {
                var id = User.FindFirst("userID").Value;
                model.UserID = Int32.Parse(id);
                return _icompanyService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //--------------------- Delete Company by Company Id----------------------

        [HttpDelete ("{companyID}")]
       
        public Response Delete(int companyID)
        {
            try
            {
                return _icompanyService.Delete(companyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}