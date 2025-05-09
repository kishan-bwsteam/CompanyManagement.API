using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Auth.Validation;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;

namespace CompanyManagement.Controllers
{
    [Route("api/PerformanceAttribute")]
    [ApiController]
    public class PerformanceAttributeController : Controller
    {
        private readonly IPerformanceAttributeService  _performanceAttributeService;
        private readonly IConfiguration _configuration;
        public PerformanceAttributeController(IPerformanceAttributeService performanceAttributeService, IConfiguration configuration)
        {
            _performanceAttributeService = performanceAttributeService;
            _configuration = configuration;
        }
        [HttpPost]
        public Response SaveUpdate(PerformanceAttribute performanceAttribute)
        {
            try
            {
                return _performanceAttributeService.SaveUpdate(performanceAttribute);
            }
            catch (System.Exception)
            {

                return null;
            }
        }
        [HttpGet ("Company/{CompanyID}")]
        public List<PerformanceAttribute> GetAll(int CompanyID)
        {
            try
            {
                var data = _performanceAttributeService.GetAll(CompanyID);
                return data;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            PerformanceAttributeModel performanceAttribute=_performanceAttributeService.GetById(id);
            if(performanceAttribute==null)
            {
                return NotFound();
            }
            return Ok(performanceAttribute);
        }
        [HttpDelete("{id}")]
        public Response DeleteById(int id)
        {
            Response performanceAttribute=new Response();
            try
            {
                performanceAttribute = _performanceAttributeService.PerformanceAttributeDelete(id);
            }
            catch (System.Exception)
            {

                throw;
            }
            return performanceAttribute;
        }


        [HttpGet("Data")]
        public DataTypeView GetData()
        {
            try
            {

                return _performanceAttributeService.GetData();
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
    }

