using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;


namespace CompanyManagement.Controllers.CreateAdminUser
{
    [Route("api/CreateUser/")]
    [ApiController]
    public class CreateUserAdminController : ControllerBase
    {

        private readonly ICreateUserAdminService _icreateUserAdminservice;
        private readonly IConfiguration _config;
        public CreateUserAdminController(ICreateUserAdminService _createUserAdminservice, IConfiguration config)
        {
            _icreateUserAdminservice = _createUserAdminservice;
            _config = config;
        }



        //----------------------------Save Update Admin User-------------------------------------

        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(AdminUser model)
        {
            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            var res = _icreateUserAdminservice.SaveUpdate(model, actionBy);
            return Ok(res);
        }


        //------------------------- Admin User by createViewUserAdminModel (list)------------------------ 


        [HttpGet]
        [Authorize]
        public IActionResult GetAdminUsers(int? limit,int? startingRow)
        {
            var id = User.FindFirst("userID").Value;
            var adminId = Int32.Parse(id);
            var res = _icreateUserAdminservice.GetAdmins(adminId,limit.GetValueOrDefault(10),startingRow.GetValueOrDefault());
            return Ok(res);
        }


        //-------------------------------Single user Get by userID--------------------------------


        [HttpGet("User/{UserID}")]
        [Authorize]

        public IActionResult GetSingle(int userID)
        {
            var id = User.FindFirst("userID").Value;
            var adminId = Int32.Parse(id);
            var res = _icreateUserAdminservice.GetAdmin(adminId,userID);
            return Ok(res);
        }


        //--------------------------------Delete User by UserID-------------------------------------------

        [HttpDelete("{UserID}")]

        public Response Delete(int userID)
        {
            try
            {
                return _icreateUserAdminservice.Delete(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
