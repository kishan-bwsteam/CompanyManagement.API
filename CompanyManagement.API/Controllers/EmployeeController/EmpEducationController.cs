using Dto.Model;
using Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/Education/")]
    [ApiController]
    public class EmpEducationController : ControllerBase
    {
        private readonly IEmpEducationService _iempEducationService;
        private readonly IConfiguration _config;

        public EmpEducationController(IEmpEducationService _empEducationService, IConfiguration config)
        {
            _iempEducationService = _empEducationService;
            _config = config;
        }

        //-------------------------------------------------- Save And Education Details ------------------------------------------


        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(EducationModel model)
        {

            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            var result = _iempEducationService.SaveUpdate(model, actionBy);
            return StatusCode(result.Status, result);
        }

        //-------------------------------------- Get All Education Details by EducationViewModels --------------------------

        [HttpGet]

        public EducationViewModels GetAll()
        {
            try
            {
                return _iempEducationService.GetAll();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------------------- Get Single Education List by UserID----------------------------------------- 

        [HttpGet("User/{UserID}")]


        public singleEducationModel GetSingle(int UserId)
        {
            try
            {
                return _iempEducationService.GetSingle(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //--------------------------------------------- Delete Education List by UserID---------------------------------------------------


        [HttpDelete("{UserID}")]

        public EducationResponse Delete(int UserID)
        {
            try
            {
                return _iempEducationService.Delete(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
