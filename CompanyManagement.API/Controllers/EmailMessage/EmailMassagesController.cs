using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.EmailMessage
{
	[Route("api/EmailMassages/")]
	[ApiController]
	public class EmailMassagesController : ControllerBase
	{

		private readonly IEmailMassagesService _iemailMassagesService;
		private readonly IConfiguration _config;

		public EmailMassagesController(IEmailMassagesService _emailMassagesService, IConfiguration config)
		{
			_iemailMassagesService = _emailMassagesService;
			_config = config;
		}


		//-------------------------------------------------Save Update Email message ------------------------------ 


		[HttpPost]

		public Response SaveUpdate(EmailMassagesModel model)
		{
			try
			{
				return _iemailMassagesService.SaveUpdate(model);
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
		}

		//---------------------------------------------Get All Email Message By EmailMessagesViewModel------------------

		[HttpGet ("{UserID}")]

		public EmailMessagesViewModel GetAll(int UserID)
		{
			try
			{
				return _iemailMassagesService.GetAll(UserID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}



		//---------------------------------------------Get All Email Message By EmailMessagesViewModel------------------

		[HttpGet("Company/{CompanyID}")]

		public EmailMessagesViewModel GetAllCompanyMail(int CompanyID)
		{
			try
			{
				return _iemailMassagesService.GetAllCompanyMail(CompanyID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//--------------------------------------------- Get  Single Message (List) by EmpID-----------------------

		[HttpGet("Employee/{EmpID}")]

		public SingleEmailMassagesViewModel GetSingle(int empID)
		{
			try
			{
				return _iemailMassagesService.GetSingle(empID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//-------------------------------------------- Delete Email Message by EmpID----------------------------------


		[HttpDelete("{EmpID}")]
		
		public Response Delete(int empID)
		{
			try
			{
				return _iemailMassagesService.Delete(empID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		
	}
}

