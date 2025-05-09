using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.Department
{
    [Route("api/Department/")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _idepartmentService;
         //private readonly IConfiguration _config;
        public DepartmentController(IDepartmentService _departmentService, IConfiguration config)
        {
            _idepartmentService = _departmentService;
         //   _config = config;
        }



        //----------------------------------------------Save Upadate Department------------------------------- 


        [HttpPost]
       
        public Response Saveupdate(DepartmentModel model)
        {
            try
            {
                return _idepartmentService.Saveupdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //---------------------------------------------------Get All Department by DepartmentViewModels (List)------------------------
        [HttpGet ("{companyID}")]
     
        public DepartmentViewModels GetAll(int companyID)
        {
            try
            {
                return _idepartmentService.GetAll(companyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //------------------------------------------------- Get Single Department By Department ID------------------------- 



        [HttpGet("Department/{departmentId}")]
       
        public SingleDepartmentModel GetSingle(int departmentId)
        {
            try
            {
                return _idepartmentService.GetSingle(departmentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-------------------------------------------- Delete Department By Department ID---------------------------------

        [HttpDelete("{DepartmentId}")]
     
        public Response Delete(int departmentId)
        {
            try
            {
                return _idepartmentService.Delete(departmentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
