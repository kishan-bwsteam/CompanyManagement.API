using Dto.Model.Common;
using Dto.Models;

using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IBidderService
    {
        Task<BidderListModel> GetAllBidders();
        Task<singleBidderResponseModel> GetSingleBidder(int? bidderId);
        Task<Response> DeleteBidderDetails(int? bidderId);
        Task<Response> SaveupdateBidder(BidderModel model);
    }
}
