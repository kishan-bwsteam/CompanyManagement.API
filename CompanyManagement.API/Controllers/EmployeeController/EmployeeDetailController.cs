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
    [Route("api/EmployeeDetail/")]
    [ApiController]
    public class EmployeeDetailController : ControllerBase
    {
        private readonly IEmployeeDetailService _iemployeeDetailService;
        private readonly IConfiguration _config;
        public EmployeeDetailController(IEmployeeDetailService _employeeDetailService, IConfiguration config)
        {
            _iemployeeDetailService = _employeeDetailService;
            _config = config;
        }



        //------------------------------------------------------ Get Employee Deatils by Company Id---------------------------------------------------------

        [HttpGet("Company/{companyId}")]
        
        public EmployeeDetailViewModels Get(int companyId)
        {
            try
            {
                return _iemployeeDetailService.Get(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //------------------------------------------------------------------Delete Employee by userID -------------------------

        [HttpDelete]
        public Response Delete(int userID)
        {
            try
            {
                return _iemployeeDetailService.Delete(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
