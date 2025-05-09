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

namespace CompanyManagement.Controllers.Shift
{
    [Route("api/WeakOff")]
    [ApiController]
    public class WeekOffController : ControllerBase
    {
        private readonly IWeekOffService WeekOffService;
        private readonly IConfiguration _config;
        public WeekOffController(IWeekOffService _WeekOffService, IConfiguration configuration)
        {
            WeekOffService = _WeekOffService;
            _config = configuration;
        }

     /*   [HttpPost]
       
        public Response SaveUpdateWeakOfflDetail(WeakOffDetailModel model)
        {
            try
            {
                return WeekOffService.SaveUpdateWeakOfflDetail(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        [HttpPost]
       
        public Response SaveUpdateWeakOff(WeakOffModel model)
        {
            try
            {
                return WeekOffService.SaveUpdateWeakOff(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("CompanyID/{CompanyID}")]
       
        public WeakOffDetailViewModal GetAllWeakOffDetail(int CompanyID)
        {
            try
            {
                return WeekOffService.GetAllWeakOffDetail(CompanyID);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

       

        [HttpGet("WeakOffDetailID/{WeakOffDetailID}")]
       
        public WeakOffDetailViewModal GetSingleWeakOffDetail(int WeakOffDetailID)

        {
            try
            {
                return WeekOffService.GetSingleWeakOffDetail(WeakOffDetailID);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetSingleWeakOff/{WeakOffID}")]
        public WeakOffViewModal GetSingleWeakOff(int WeakOffID)
        {
            try
            {
                return WeekOffService.GetSingleWeakOff(WeakOffID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /*[HttpGet]
        [Route("DeleteWeakOff/{wkOffDetID}")]
        public Response DeleteWeakOff(int wkOffDetID)
        {
            try
            {
                return WeekOffService.DeleteWeakOff(wkOffDetID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/



        [HttpDelete("DeleteWeakOffDetail/{WeakOffDetailID}")]
        
        public Response DeleteWeakOffDetail(int WeakOffDetailID)
        {
            try
            {
                return WeekOffService.DeleteWeakOffDetail(WeakOffDetailID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
