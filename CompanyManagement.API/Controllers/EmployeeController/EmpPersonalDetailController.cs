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

namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/EmpPersonalDetail/")]
    [ApiController]
    public class EmpPersonalDetailController : ControllerBase
    {
        private readonly IEmpPersonalDetailService _ipersonaldetailservice;
        private readonly IConfiguration _config;
        public EmpPersonalDetailController(IEmpPersonalDetailService _personaldetailservice, IConfiguration config)
        {
            _ipersonaldetailservice = _personaldetailservice;
            _config = config;
        }



		//---------------------------------------------- Save Update Details--------------------------------------------

		[HttpPost]

		public Response SaveUpdate( EmpPersonalDetailModel model)
		{
			try
			{

				return _ipersonaldetailservice.SaveUpdate(model);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//---------------------------------------------- Get All Details --------------------------------------------


		[HttpGet]

		public EmpPersonalDetailViewModels Get()
		{
			try
			{
				return _ipersonaldetailservice.Get();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//---------------------------------------- Delete User Details By UserID----------------------

		[HttpDelete]

		public Response Delete(int userID)
		{
			try
			{
				return _ipersonaldetailservice.Delete(userID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//--------------------------------------------------- Get Single Details by SinglePersonalDetailResponseModel-------------------------------

		[HttpGet("User/{UserID}")]
		
		public SinglePersonalDetailResponseModel GetSingle(int UserID)
		{
			try
			{
				return _ipersonaldetailservice.GetSingle(UserID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//--------------------------------------------------- Get All Department by DepartmentViewModel-------------------------------

		
		[HttpGet("Department/")]
	
		public DepartmentViewModel GetDepartment()
        {
			try
			{
				return _ipersonaldetailservice.GetDepartment();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//---------------------------------------------------- Get All Position by PositionViewModel---------------------

		[HttpGet("Position/")]

		public PositionViewModel GetPosition()
        {
			try
			{
				return _ipersonaldetailservice.GetPosition();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
