using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.Management
{
    [Route("api/EmpProjectTimeController")]
    [ApiController]
    public class EmpProjectTimeController : Controller
    {
        public readonly IEmpProjectTimeService iEmpProjectTimeService;
        public EmpProjectTimeController(IEmpProjectTimeService _iEmpProjectTimeService)
        {
            iEmpProjectTimeService = _iEmpProjectTimeService;
        }

        //-------------------------------------SaveUpdate-------------------------------------------------------------



        [HttpPost]
          public Response saveUpdate(EmployeeProjectModel model)
           {
            try
            {
                return iEmpProjectTimeService.saveUpdate(model);
            }
            catch
            {
                return null;
            }
           
           }



        //-----------------------------------------Get---------------------------------------------------------


        [HttpGet("GetAll/{data}")]
        public EmployeeProjectList GetAll(String data)
        {
            
            try
            {
                return iEmpProjectTimeService.GetAll(data);
            }
            catch
            {
                return null;
            }
           
        }
        //-----------------------------------------Getsingle---------------------------------------------------------


        [HttpGet("Getsingle/{data}")]
        public EmployeeProjectList Getsingle(int data)
        {
            try
            {
                return iEmpProjectTimeService.Getsingle(data);
            }
            catch
            {
                return null;
            }
            
        }

        //-----------------------------------------Delete---------------------------------------------------------


        [HttpDelete("Delete/{data}")]
        public Response Delete(int data)
        {
            try
            {
                return iEmpProjectTimeService.Delete(data);
            }
            catch
            {
                return null;
            }
           
        }




    }
}
