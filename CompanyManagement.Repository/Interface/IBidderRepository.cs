using Dto.Model.Common;
using Dto.Models;

using System.Threading.Tasks;

namespace Datas.Abstract
{
    public interface IBidderRepository
    {
        Task<BidderListModel> GetAllBidders();
        Task<singleBidderResponseModel> GetSingleBidder(int? bidderId);
        Task<Response> DeleteBidderDetails(int? bidderId);
        Task<Response> SaveupdateBidder(BidderModel model);
    }
}
