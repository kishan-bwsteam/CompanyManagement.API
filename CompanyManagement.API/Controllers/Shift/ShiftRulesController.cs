using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.Shift
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftRulesController : ControllerBase
    {
        private readonly IShiftRulesService _ishiftRulesService;
        public ShiftRulesController(IShiftRulesService _shiftRulesService)
        {

            _ishiftRulesService = _shiftRulesService;
        }

        //---------------------------- Save And Update Shift---------------------------- 

        [HttpPost]
        
        public Response SaveUpdate(ShiftRulesModel shiftRulesModel)
        {
            try
            {
                return _ishiftRulesService.SaveUpdate(shiftRulesModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //---------------------------- Get All Shift Rule shiftRuleId---------------------------- 

        [HttpGet("GetRule/{shiftRuleId}")]
        public ShiftRulesModel GetSingle(int shiftRuleId)
        {
            try
            {
                return _ishiftRulesService.GetSingle(shiftRuleId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //-------------------------- Delete Shift By shiftRuleId-----------------

        [HttpDelete("Deleteshift/{shiftRuleId}")]
        public Response Delete(int shiftRuleId)
        {
            try
            {
                return _ishiftRulesService.Delete(shiftRuleId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //--------------------------- Get All Shift By AllShiftRulesModel-----------------

        [HttpGet]
        public AllShiftRulesModel GetAll()
        {
            try
            {
                return _ishiftRulesService.GetAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
