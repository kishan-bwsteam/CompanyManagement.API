using CompanyManagement.Services.Service.Abstract;

using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using static Dto.Model.UserModel;

namespace CompanyManagement.Controllers
{
	[Route("api/User/")]
	[ApiController]
	public class UserController : ControllerBase
	{ 
		private readonly IUserService _userService;
		private readonly IConfiguration _config;


        public UserController(IUserService _userService, IConfiguration config)
        {
            this._userService = _userService;
            _config = config;
        }


        //--------------------------------------------------------- Save Update user-------------------------------------


        [HttpPost]
        [Authorize]
        public IActionResult SaveUpdate(UserBasic model)
        {

            var id = User.FindFirst("userID").Value;
            var actionBy = Int32.Parse(id);
            var result = _userService.SaveUpdate(model, actionBy);
            return StatusCode(result.Status, result);
        }

        //--------------------------------------------Get User Type------------------------------------------------
        [HttpGet("GetUserType")]
	
		public List<IDictionary<string, object>> GetUserType()                                   
	    {
			try
			{
				return _userService.GetUserType();
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		//--------------------------------------------Get Address Type--------------------------------------------

		[HttpGet("GetAddressType")]
		
		public IActionResult GetAddress()
		{
			try
			{
				return Ok(_userService.GetAddressType());
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		//--------------------------------------------------------Get All User Data by userViewModel (List)-----------------

		[HttpGet]
		
		public userViewModels Get()
		{
			try
			{
				return _userService.Get();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}


		//----------------------------------------- Get Single User by UserID-------------------------------------------------------


		[HttpGet("User/{userID}")]

		public singleUserResponseModel GetSingle(int userID)
		     {
			try
			{
				return _userService.GetSingle(userID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}


		//--------------------------------------- Delete User Details-------------------------------------------------------


		[HttpDelete("User/{userId}")]

		public Response Delete(int userId)
		{
			try
			{
				return _userService.Delete(userId);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

	

		//------------------------------------------ Delete Company by Company ID------------------------------------------------

		[HttpDelete("Company/{companyID}")]
		
		public Response DeleteCompany(int companyID)
		{
			try
			{
				return _userService.DeleteCompany(companyID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
