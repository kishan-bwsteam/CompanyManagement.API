using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/Emergency")]
    [ApiController]
    public class EmergencyController : ControllerBase
    {

        private readonly IEmergencyService _iemergencyService;
        private readonly IConfiguration _config;

        public EmergencyController(IEmergencyService _emergencyService, IConfiguration config)
        {
            _iemergencyService = _emergencyService;
            _config = config;
        }




        //-----------------------------------------------save Update Emergency Details---------------------------------------

        [HttpPost]
    

        public Response SaveUpdate(EmergencyModel model)
        {
            try 
            {
                return _iemergencyService.SaveUpdate(model);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        //--------------------------------- Get All Emergency Details by EmergencyModelView----------------------------------------

        [HttpGet ("{UserId}")]
     
        public EmergencyModelView GetAll(int userID)
        {
            try
            {
                return _iemergencyService.GetAll(userID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //----------------------------------------------Delete Emergency Details by emergency ID--------------------------------------------

        [HttpDelete("{EmergencyID}")]
        
        public Response Delete(int emergencyID)
        {
            try
            {
                return _iemergencyService.Delete(emergencyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
