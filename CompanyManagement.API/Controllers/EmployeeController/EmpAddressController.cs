using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using Service.Concrete;
using System;


namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/Address/")]
    [ApiController]
    public class EmpAddressController : ControllerBase
    {
        private readonly IEmpAddressService _iempAddressService;
        // private readonly IConfiguration _config;

        public EmpAddressController(IEmpAddressService _empAddressService, IConfiguration config)
        {
            _iempAddressService = _empAddressService;
            //  _config = config;
        }


        //------------------------------- Save Update Address ---------------------------

        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(UserAddress model)
        {

            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            var result = _iempAddressService.SaveUpdate(model, actionBy);
            return StatusCode(result.Status, result);
        }

        //----------------------- Get All Address by AddressViewModel------------------------------


        [HttpGet]
        // [Route("GetAddressDetails/")]
        public AddressViewModel GetAddress()
        {
            try
            {
                return _iempAddressService.GetAddress();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------------Get Single Address by UserAddressID-------------------------------
        [HttpGet("User/{UserId}")]


        public singleAddressViewModel GetSingle(int UserId)
        {
            try
            {
                return _iempAddressService.GetSingle(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //----------------------------Delete Address by UserAddressID-------------------------------

        [HttpDelete("{UserAddressID}")]
    
        public Response Delete(int UserAddressID)
        {
            try
            {
                return _iempAddressService.Delete(UserAddressID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        //----------------------- Get All Country by CountryViewModel------------------------------

        [HttpGet("Country")]
       
        public CountryViewModel GetAll()
        {
            try
            {
                return _iempAddressService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------- Get All State by StateViewModel------------------------------

        [HttpGet("State")]

        
        public StateViewModel GetAllState()
        {
            try
            {
                return _iempAddressService.GetAllState();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}