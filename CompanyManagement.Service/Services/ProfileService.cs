
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model.Common;
using Dto.Models;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProfileService : IProfileService
    {
        
        private readonly IProfileRepository _profileRepository;

        #region Constructor
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        #endregion
        


        /*
        private readonly IProfileRepository _profileRepository;
        private readonly ILogger<ProfileService> logger;
        private readonly IProfileRepository ProfileRepository;
        private readonly ICurrentUserContext currentUserContext;
        public readonly IDatabaseContext dbcontext;
        ProfileRepository departmentRepository = new ProfileRepository(DatabaseContext.CreateInstance());

        #region Constructor
        public ProfileService(IDatabaseContext databaseContext, ILogger<ProfileService> logger, IProfileRepository profileRepository, ICurrentUserContext currentUserContext)
        {
            dbcontext = DatabaseContext.CreateInstance();
            _profileRepository = profileRepository;
            this.logger = logger;
            this.ProfileRepository = profileRepository;
            this.currentUserContext = currentUserContext;
        }
        */
  
        public async Task<ProfileListModel> GetAllProfiles(int companyId)
        {
            ProfileListModel profileListModel = new ProfileListModel();
            try
            {
                profileListModel =await _profileRepository.GetAllProfiles(companyId);

                return profileListModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
 
        public async Task<singleProfileResponseModel> GetSingleProfile(int? profileId)
        {
            singleProfileResponseModel singleProfileResponseModel = new singleProfileResponseModel();
            try
            {
                singleProfileResponseModel=await _profileRepository.GetSingleProfile(profileId);
                return singleProfileResponseModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
      
        public async Task<Response> DeleteProfileDetails(int? profileId)
        {
            Response response = new Response();
            try
            {
                response=await _profileRepository.DeleteProfileDetails(profileId);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> SaveupdateProfile(ProfileModel model)
        {
            Response response = new Response();
            try
            {
                response=await _profileRepository.SaveupdateProfile(model);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
