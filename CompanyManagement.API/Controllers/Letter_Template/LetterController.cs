using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.Letter_Template
{
    [Route("api/Letter/")]
    [ApiController]
    public class LetterController : ControllerBase
    {

		private readonly ILetterService _iletterService;
		private readonly IConfiguration _config;

		public LetterController(ILetterService _letterService, IConfiguration config)
		{
			_iletterService = _letterService;
			_config = config;
		}


		//-------------------------------------------------Save Update Letter Template ------------------------------ 


		[HttpPost]

		public Response SaveUpdate(LetterModel model)
		{
			try
			{
				return _iletterService.SaveUpdate(model);
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
		}

		//---------------------------------------------Get All Letter Template By LetterViewModel------------------

		[HttpGet("LetterID/{CompanyID}")]

		public LetterViewModel GetAll(int companyID)
		{
			try
			{
				return _iletterService.GetAll(companyID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//--------------------------------------------- Get  Single Template (List) by EmpID-----------------------

		[HttpGet("Employee/{letterID}")]

		public SingleLetterViewModel GetSingle(int letterID)
		{
			try
			{
				return _iletterService.GetSingle(letterID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//-------------------------------------------- Delete Template by EmpID----------------------------------


		[HttpDelete("{LetterID}")]

		public Response Delete(int letterID)
		{
			try
			{
				return _iletterService.Delete(letterID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
