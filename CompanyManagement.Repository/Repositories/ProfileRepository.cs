using CompanyManagement.Datas.Concrete;
using Dapper;

using Datas.Abstract;
using Dto.Model.Common;
using Dto.Models;

using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Datas.Concrete
{
    public class ProfileRepository : IProfileRepository
    {
        
        public readonly IDatabaseContext dbcontext;
        #region Constructor
        public ProfileRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }
        #endregion
        

        /*
        public readonly IDatabaseContext dbcontext;
        private readonly ILogger<ProfileRepository> logger;
        private readonly IDbHelper dbhelper;
        private IDatabaseContext databaseContext;
        #region Constructor
        public ProfileRepository(IDatabaseContext databaseContext, ILogger<ProfileRepository> logger, IDbHelper dbhelper)
        {


            this.logger = logger;
            this.dbhelper = dbhelper;
            dbcontext = databaseContext;
            IDatabaseContext _dbcontext123 = DatabaseContext.CreateInstance();

            this.dbcontext = _dbcontext123;
        }

        public ProfileRepository(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        #endregion
        */
        public async Task<ProfileListModel> GetAllProfiles(int companyId)
        {
            ProfileListModel profileListModel = new ProfileListModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
            
                    parameters.Add("@CompanyId", companyId);
                var _result = dbcontext.Query<ProfileModel>("getProfile", parameters, null, CommandType.StoredProcedure).ToList();
                if (_result != null)
                {
                    profileListModel.Status = parameters.Get<int>("@Status");
                    profileListModel.Message = parameters.Get<string>("@Message");
                    profileListModel.Profilelst = _result;
                }
            }
            catch (Exception ex)
            {
                profileListModel.Message = ex.Message;
            }
            return profileListModel;
        }


        public async Task<singleProfileResponseModel> GetSingleProfile(int? profileId)
        {
            singleProfileResponseModel profile = new singleProfileResponseModel();

            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProfileId", profileId);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _result = dbcontext.Query<ProfileModel>("getSingleProfile", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    profile.singleProfile = _result.FirstOrDefault();
                    profile.Status = parameters.Get<int>("@Status");
                    profile.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                profile.Message = ex.Message;
            }
            return profile;
        }

  
        public async Task<Response> DeleteProfileDetails(int? profileId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProfileId", profileId);

                var _result = dbcontext.Query<string>("deleteProfile", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

 
        public async Task<Response> SaveupdateProfile(ProfileModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ProfileId", model.ProfileId);
                parameters.Add("@ProfileName", model.ProfileName);
                parameters.Add("@PlatformId", model.PlatformId);
                parameters.Add("@IsActive", model.IsActive);
                parameters.Add("@loginUserID", model.loginUserId);
                parameters.Add("@CompanyId", model.CompanyId);

                var _result = dbcontext.Query<string>("saveUpdateProfile", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
