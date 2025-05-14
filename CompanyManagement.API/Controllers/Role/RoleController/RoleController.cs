using BussinessObject;
using Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers
{
    [Route("api/Role/")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _iroleService;
        private readonly IConfiguration _iconfig;
        public RoleController(IRoleService roleService, IConfiguration configuration)
        {
            _iroleService = roleService;
            _iconfig = configuration;
        }




        //----------------------------------- Save Update Role --------------------------
        [HttpPost]
        [Authorize]

        public IActionResult SaveUpdate([FromBody] RoleModel model)
        {

            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            var res = _iroleService.SaveUpdate(model,actionBy);
            return Ok(res);
        }



        //----------------------------------- Get All  Role Data by roleViewModels ---------------------

        [HttpGet("userID/{userID}")]
        //[Route("GetAllRoleData/")]
        public roleViewModels Get(int userID)
        {
            try
            {
                return _iroleService.Get(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //-----------------------------------Get Single Role by RoleID--------------------------------

        [HttpGet("RoleId/{roleID}")]
        //[Route("GetSingleRole/{RoleId}")]
        public SingleRoleResponseModel GetSingle(int roleID)
        {
            try
            {
                return _iroleService.GetSingle(roleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //-------------------------------------Delete by RoleID-----------------------------------

        [HttpDelete("{roleID}")]


        public RoleResponse Delete(int roleID)
        {
            try
            {
                return _iroleService.Delete(roleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
