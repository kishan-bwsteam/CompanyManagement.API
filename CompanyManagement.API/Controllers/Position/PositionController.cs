using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.Position
{
    [Route("api/Position/")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _ipositionService;
        private readonly IConfiguration _config;

        public PositionController(IPositionService _positionService, IConfiguration configuration)
        {
            _ipositionService = _positionService;
            _config = configuration;
        }



        //-----------------------------------------------------save update position---------------------------  

        [HttpPost]
      
        public PositionResponse Saveupdate(PositionModel model)
        {
            try
            {
                return _ipositionService.Saveupdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //----------------------------------------Get All Postion by positionViewModels (List)----------------------------


        [HttpGet("{companyID}")]
   
        public positionViewModels Get(int companyID)
        {
            try
            {
                return _ipositionService.Get(companyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------------------------Get Single Position by RoleID----------------

        [HttpGet("Role/{RoleId}")]
       
        public SinglePositionResponseModel GetSingle(int roleID)
        {
            try
            {
                return _ipositionService.GetSingle(roleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //----------------------------------------------Get Single Position by RoleID----------------------------------
        [HttpDelete ("{roleID}")]
  
        public PositionResponse Delete(int roleId)
        {
            try
            {
                return _ipositionService.Delete(roleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   

    }
}
