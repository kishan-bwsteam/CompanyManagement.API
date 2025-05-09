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
    public class BidderRepository : IBidderRepository
    {
        public readonly IDatabaseContext dbcontext;
        #region Constructor
        public BidderRepository(IDatabaseContext databaseContext)
        {
            dbcontext = databaseContext;
        }
        #endregion

        public async Task<BidderListModel> GetAllBidders()
        {
            BidderListModel bidderListModel = new BidderListModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var _result = dbcontext.Query<BidderModel>("getBidder", parameters, null, CommandType.StoredProcedure).ToList();
                if (_result != null)
                {
                    bidderListModel.Status = parameters.Get<int>("@Status");
                    bidderListModel.Message = parameters.Get<string>("@Message");
                    bidderListModel.Bidderlst = _result;
                }
            }
            catch (Exception ex)
            {
                bidderListModel.Message = ex.Message;
            }
            return bidderListModel;
        }
   
        public async Task<singleBidderResponseModel> GetSingleBidder(int? bidderId)
        {
            singleBidderResponseModel bidder = new singleBidderResponseModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@BidderID", bidderId);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var _result = dbcontext.Query<BidderModel>("getSingleBidder", parameters, null, CommandType.StoredProcedure);
                if (_result != null)
                {
                    bidder.singleBidder = _result.FirstOrDefault();
                    bidder.Status = parameters.Get<int>("@Status");
                    bidder.Message = parameters.Get<string>("@Message");
                }
            }
            catch (Exception ex)
            {
                bidder.Message = ex.Message;
            }
            return bidder;
        }

        public async Task<Response> DeleteBidderDetails(int? bidderId)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@BidderID", bidderId);

                var _result = dbcontext.Query<string>("deleteBidder", parameters, null, CommandType.StoredProcedure);
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

        public async Task<Response> SaveupdateBidder(BidderModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@BidderID", model.BidderID);
                parameters.Add("@BidderName", model.BidderName);
                parameters.Add("@IsActive", model.IsActive);
                parameters.Add("@loginUserID", model.loginUserID);

                var _result = dbcontext.Query<string>("saveUpdateBidder", parameters, null, CommandType.StoredProcedure);
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
