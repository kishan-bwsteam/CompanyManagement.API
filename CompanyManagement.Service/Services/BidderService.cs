
using Dto.Models;

using System;
using SqlDapper.Concrete;


using System.Threading.Tasks;
using Dto.Model.Common;
using Service.Abstract;
using Datas.Abstract;
using Datas.Concrete;

namespace Service.Concrete
{
    public class BidderService : IBidderService
    {
        private readonly IBidderRepository _bidderRepository;

        #region Constructor
        public BidderService(IBidderRepository  bidderRepository)
        {
            _bidderRepository = bidderRepository;
        }
        #endregion

        public async Task<BidderListModel> GetAllBidders()
        {
            BidderListModel bidderListModel = new BidderListModel();
            try
            {
                bidderListModel = await _bidderRepository.GetAllBidders();

                return bidderListModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<singleBidderResponseModel> GetSingleBidder(int? bidderId)
        {
            singleBidderResponseModel singleBidderResponseModel = new singleBidderResponseModel();
            try
            {
                singleBidderResponseModel=await _bidderRepository.GetSingleBidder(bidderId);
                return singleBidderResponseModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> DeleteBidderDetails(int? bidderId)
        {
            Response response = new Response();
            try
            {
                response=await _bidderRepository.DeleteBidderDetails(bidderId);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> SaveupdateBidder(BidderModel model)
        {
            Response response = new Response();
            try
            {
                response=await _bidderRepository.SaveupdateBidder(model);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
