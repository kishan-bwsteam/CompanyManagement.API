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
    public class PlatformRepository : IPlatformRepository
    {
        public readonly IDatabaseContext dbcontext;
        public PlatformRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }
        /*
        public readonly IDatabaseContext dbcontext;
        private readonly ILogger<PlatformRepository> logger;
        private readonly IDbHelper dbhelper;
        private IDatabaseContext databaseContext;
        #region Constructor
        public PlatformRepository(IDatabaseContext databaseContext, ILogger<PlatformRepository> logger, IDbHelper dbhelper)
        {


            this.logger = logger;
            this.dbhelper = dbhelper;
            dbcontext = databaseContext;
            IDatabaseContext _dbcontext123 = DatabaseContext.CreateInstance();

            this.dbcontext = _dbcontext123;
        }

        public PlatformRepository(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        #endregion
        */
        /*
        public readonly IDatabaseContext dbcontext;
        #region Constructor
        public PlatformRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
            IDatabaseContext _dbcontext123 = DatabaseContext.CreateInstance();
            this.dbcontext = _dbcontext123;
        }
        #endregion
        */

        public async Task<PlatformListModel> GetAllPlatforms(int companyId)
        {
            PlatformListModel platformListModel = new PlatformListModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanyId",companyId);
                var _result = dbcontext.Query<PlatformModel>("getPlatform", parameters, null, CommandType.StoredProcedure).ToList();
                if (_result != null)
                {
                    platformListModel.Status = parameters.Get<int>("@Status");
                    platformListModel.Message = parameters.Get<string>("@Message");
                    platformListModel.Platformlst = _result;

                }
            }
            catch (Exception ex)
            {
                platformListModel.Message = ex.Message;
            }
            return platformListModel;
        }
     
        public async Task<singlePlatformResponseModel> GetSinglePlatform(int? platformId)
        {
            singlePlatformResponseModel platform = new singlePlatformResponseModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@PlatformId", platformId);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                var _result = dbcontext.Query<PlatformModel>("getSinglePlatform", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    platform.singlePlatform = _result.FirstOrDefault();
                    platform.Status = parameters.Get<int>("@Status");
                    platform.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                platform.Message = ex.Message;
            }
            return platform;
        }

        public async Task<Response> DeletePlatformDetails(int? platformId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@PlatformID", platformId);

                var _result = dbcontext.Query<string>("deletePlatform", parameters, null, CommandType.StoredProcedure);
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

        public async Task<Response> SaveupdatePlatform(PlatformModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@PlatformId", model.PlatformId);//
                parameters.Add("@PlatformName", model.PlatformName);
                parameters.Add("@loginUserID", model.LoginUserId);
                parameters.Add("@CompanyId", model.CompanyId);
                var _result = dbcontext.Query<string>("saveUpdatePlatform", parameters, null, CommandType.StoredProcedure);
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
