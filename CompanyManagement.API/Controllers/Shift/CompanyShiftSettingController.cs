using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;

namespace CompanyManagement.Controllers.Shift
{
  [Route("api/ShiftSetting")]
  [ApiController]
    public class CompanyShiftSettingController : ControllerBase
    {
        private readonly ICompanyShiftSettingService _icompanyShiftSettingService;
        private readonly IConfiguration _config;
        public CompanyShiftSettingController(ICompanyShiftSettingService _companyShiftSettingService, IConfiguration _configuration)
        {
            _icompanyShiftSettingService = _companyShiftSettingService;
            _config = _configuration;
        }

        //--------------------------------Save Update Company Shift------------------------------------
        [HttpPost]
        public Response SaveUpdate(ShiftSettingModel model)

        {
            try
            {
                return _icompanyShiftSettingService.SaveUpdate(model); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------Get All Company Shift By CompanyID----------------------------------


        [HttpGet("companyID/{companyID}")]

        public ShiftSettingViewModel Get(int companyID)
        {
            try
            {
                return _icompanyShiftSettingService.Get(companyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


  

        
   

        [HttpGet("companyID/{companyID}/ShiftID/{ShiftID}")]
        public SingleShiftSettingModel GetSingle(int companyID ,int ShiftID)
        {
            try
            {
                return _icompanyShiftSettingService.GetSingle(companyID,ShiftID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //-----------------------------------Delete Shift by Shift ID-------------------------------------

        [HttpDelete("ShiftID/{ShiftID}")]

        public Response Delete(int shiftID)
        {
            try
            {
                return _icompanyShiftSettingService.Delete(shiftID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
