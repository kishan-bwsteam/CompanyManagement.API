using Dto.Model;
using Dto.Model.Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


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

		public Response SaveUpdate(CreateUserAdminModel model)
		{
			try
			{

				return _icreateUserAdminservice.SaveUpdate(model);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//------------------------- Admin User by createViewUserAdminModel (list)------------------------ 


		[HttpGet]
		public createViewUserAdminModel GetAll()
		{
			try
			{
				return _icreateUserAdminservice.GetAll();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//-------------------------------Single user Get by userID--------------------------------


		[HttpGet("User/{UserID}")]
		//[Route("GetSingleUserData/{UserID}")]
		public singlecreateViewUserAdminModel GetSingle(int userID)
		{
			try
			{
				return _icreateUserAdminservice.GetSingle(userID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
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
