using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/Wages/")]
    [ApiController]
    public class WagesController : ControllerBase
    {
        
            private readonly IWagesService _iwagesService;
            private readonly IConfiguration _iconfig;

            public WagesController(IWagesService _wagesService, IConfiguration _config)
            {
                _iwagesService = _wagesService;
                _iconfig = _config;
            }


        //-----------------------------Save Update Wages---------------------------------------
        [HttpPost]
       
        public Response SaveUpdate(WagesModel model)
        {
            try
            {
                return _iwagesService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------------------Get All Wages----------------------------------------
        [HttpGet]
    
        public WagesModelView Get()
        {
            try
            {
                return _iwagesService.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //--------------------------------Delete Wages By WagesID-------------------------

        [HttpDelete ("{wagesID}")]
       
        public Response Delete(int wagesID)
        {
            try
            {
                return _iwagesService.Delete(wagesID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("Structure/{Box}")]

        public MultiWagesModelView GetStructureSalary(string Box)
        {
            try
            {
                return _iwagesService.GetStructureSalary(Box);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //[HttpGet("UserStructure/{UserID}")]

        //public MultiWagesModelView GetUserStructure(int UserID)
        //{
        //    try
        //    {
        //        return _iwagesService.GetUserStructure(UserID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
