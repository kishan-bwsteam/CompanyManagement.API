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
    public class PlatformService : IPlatformService
    {
        /*
        private readonly IPlatformRepository _platformRepository;
        private readonly ILogger<PlatformService> logger;
        private readonly IPlatformRepository PlatformRepository;
        private readonly ICurrentUserContext currentUserContext;
        public readonly IDatabaseContext dbcontext;
        PlatformRepository platformRepository = new PlatformRepository(DatabaseContext.CreateInstance());
        #region Constructor
        public PlatformService(IDatabaseContext databaseContext, ILogger<PlatformService> logger, IPlatformRepository platformRepository, ICurrentUserContext currentUserContext)
        {
            dbcontext = DatabaseContext.CreateInstance();
            _platformRepository = platformRepository;
            this.logger = logger;
            this.PlatformRepository = platformRepository;
            this.currentUserContext = currentUserContext;
        }
        */
        private readonly IPlatformRepository _platformRepository;
        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }
        // private readonly IPlatformRepository _platformRepository;
        // PlatformRepository platformRepository = new PlatformRepository(DatabaseContext.CreateInstance());
        /*
        #region Constructor
        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }
        #endregion
        */
        public async Task<PlatformListModel> GetAllPlatforms(int companyId)
        {
            PlatformListModel platformListModel = new PlatformListModel();
            try
            {
                platformListModel =await _platformRepository.GetAllPlatforms(companyId);

                return platformListModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
        public async Task<singlePlatformResponseModel> GetSinglePlatform(int? platformId)
        {
            singlePlatformResponseModel singlePlatformResponseModel = new singlePlatformResponseModel();
            try
            {
                singlePlatformResponseModel=await  _platformRepository.GetSinglePlatform(platformId);
                return singlePlatformResponseModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
        public async Task<Response> DeletePlatformDetails(int? platformId)
        {
            Response response = new Response();
            try
            {
                response=await _platformRepository.DeletePlatformDetails(platformId);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
      
        public async Task<Response> SaveupdatePlatform(PlatformModel model)
        {
            Response response = new Response();
            try
            {
                response=await  _platformRepository.SaveupdatePlatform(model);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
