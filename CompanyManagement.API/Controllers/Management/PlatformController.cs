using Dto.Model.Common;
using Dto.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Abstract;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/PlatformController")]
    [ApiController]
    public class PlatformController : Controller
    {
        private readonly IPlatformService platformService;
        // private readonly IConfiguration _config;

        #region Constructor
        //public PlatformController(IPlatformService _platformService, IConfiguration configuration)
        public PlatformController(IPlatformService _platformService)
        {
            platformService = _platformService;
            //_config = configuration;
        }

        

        #endregion

        #region Action Methods
        [HttpGet("Company/{companyId}")]
        public async Task<PlatformListModel> GetAllPlatforms(int companyId)
        {
            PlatformListModel platformListModel = new PlatformListModel();
            try
            {
                platformListModel =await platformService.GetAllPlatforms(companyId);
            }
            catch (Exception ex)
            {
                platformListModel.Status = 500;
                platformListModel.Message = ex.Message.ToString();
            }
            return platformListModel;
        }

        [HttpGet("single/{platformId}")]
        public async Task<singlePlatformResponseModel> GetSinglePlatform(int? platformId)
        {
            singlePlatformResponseModel platform = new singlePlatformResponseModel();
            try
            {
                platform= await platformService.GetSinglePlatform(platformId);
            }
            catch (Exception ex)
            {
                platform.Status = 500;
                platform.Message = ex.Message.ToString();
            }
            return platform;
        }

        [HttpDelete("delete/{platformId}")]
        public async Task<Response> DeletePlatformDetails(int? platformId)
        {
            Response response = new Response();
            try
            {
                response= await platformService.DeletePlatformDetails(platformId);
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message.ToString();
            }
            return response;
        }
        [HttpPost]
        public async Task<Response> SaveupdatePlatform(PlatformModel model)
        {
            Response response = new Response();
            try
            {
                response= await platformService.SaveupdatePlatform(model);
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message.ToString();
            }
            return response;
        }
        #endregion
    }
}
