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
    [Route("api/ProfileController")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        
        private readonly IProfileService profileService;
        //private readonly IConfiguration _config;

        #region Constructor
        //public ProfileController(IProfileService _profileService, IConfiguration configuration)
        public ProfileController(IProfileService _profileService)
        {
            profileService = _profileService;
           // _config = configuration;
        }
        #endregion

        #region Action Methods
        [HttpGet ("Company/{companyId}")]
        public async Task<ProfileListModel> GetAllProfiles(int companyId)
        {
            ProfileListModel profileListModel = new ProfileListModel();
            try
            {
                profileListModel =await profileService.GetAllProfiles(companyId);
            }
            catch (Exception ex)
            {
                profileListModel.Status = 500;
                profileListModel.Message = ex.Message.ToString();
            }
            return profileListModel;
        }

        [HttpGet("single/{profileId}")]
        public async Task<singleProfileResponseModel> GetSingleProfile(int? profileId)
        {
            singleProfileResponseModel profile = new singleProfileResponseModel();
            try
            {
                profile= await profileService.GetSingleProfile(profileId);
            }
            catch (Exception ex)
            {
                profile.Status = 500;
                profile.Message = ex.Message.ToString();
            }
            return profile;
        }

        [HttpDelete("delete/{profileId}")]
        public async Task<Response> DeleteProfileDetails(int? profileId)
        {
            Response response = new Response();
            try
            {
                response= await profileService.DeleteProfileDetails(profileId);
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message.ToString();
            }
            return response;
        }


        [HttpPost]
        public async Task<Response> SaveupdateProfile(ProfileModel model)
        {
            Response response = new Response();
            try
            {
                response= await profileService.SaveupdateProfile(model);
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
