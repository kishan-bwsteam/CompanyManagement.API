using Dto.Model.Common;
using Dto.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BidderController : Controller
    {
        private readonly IBidderService bidderService;
        //private readonly IConfiguration _config;

        #region Constructor
        //public BidderController(IBidderService _bidderService, IConfiguration configuration)
        public BidderController(IBidderService _bidderService)
        {
            bidderService = _bidderService;
           // _config = configuration;
        }
        #endregion

        #region Action Methods
        [HttpGet]
        public async Task<BidderListModel> GetAllBidders()
        {
            BidderListModel bidderListModel = new BidderListModel();
            try
            {
                bidderListModel =await bidderService.GetAllBidders();
            }
            catch (Exception ex)
            {
                bidderListModel.Status = 500;
                bidderListModel.Message = ex.Message.ToString();
            }
            return bidderListModel;
        }

        [HttpGet]
        public async Task<singleBidderResponseModel> GetSingleBidder(int? bidderId)
        {
            singleBidderResponseModel bidder = new singleBidderResponseModel();
            try
            {
                bidder= await bidderService.GetSingleBidder(bidderId);               
            }
            catch (Exception ex)
            {
                bidder.Status =500;
                bidder.Message =ex.Message.ToString();
            }
            return bidder;
        }

        [HttpGet]
        public async Task<Response> DeleteBidderDetails(int? bidderId)
        {
            Response response = new Response();
            try
            {
                response=await  bidderService.DeleteBidderDetails(bidderId);
            }
            catch (Exception ex)
            {
                response.Status = 500;
                response.Message = ex.Message.ToString();
            }
            return response;
        }

        [HttpPost]
        public async Task<Response> SaveupdateBidder(BidderModel model)
        {
            Response response = new Response();
            try
            {
                response= await bidderService.SaveupdateBidder(model);
            }
            catch (Exception ex)
            {
                response.Status=500;
                response.Message=ex.Message.ToString();
            }
            return response;
        }
        #endregion
    }
}
