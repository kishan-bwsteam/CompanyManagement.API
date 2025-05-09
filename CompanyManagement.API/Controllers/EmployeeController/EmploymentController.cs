using Dto.Model;
using Dto.Responses;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/Employment/")]
    [ApiController]
    public class EmploymentController : ControllerBase
    {
        private readonly IEmpEmploymentService _iempEmploymentService;
        private readonly IConfiguration _config;

        public EmploymentController(IEmpEmploymentService _empEmploymentService, IConfiguration config)
        {
            _iempEmploymentService = _empEmploymentService;
            _config = config;
        }



        //--------------------------------------------- Save Update Employment ------------------------------------------------------------

        [HttpPost]
  
        public EmploymentResponse SaveUpdate( EmploymentModel model)
        {
            try
            {
                return _iempEmploymentService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-------------------------------------- Get All Employement by AllEmploymentList----------------------------



        [HttpGet]
    
        public AllEmploymentList GetAll()
        {
            try
            {
                return _iempEmploymentService.GetAll();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-------------------------------------------------- Get Single Employment data by userID-----------------------------


        [HttpGet("User/{UserID}")]

    
        public SingleEmpModel GetSingle(int userId)
        {
            try
            {
                return _iempEmploymentService.GetSingle(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------------------------------------- Delete Employment by UserID------------------------------------



        [HttpDelete("{UserID}")]
        
        public EmploymentResponse Delete(int userID)
        {
            try
            {
                return _iempEmploymentService.Delete (userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
