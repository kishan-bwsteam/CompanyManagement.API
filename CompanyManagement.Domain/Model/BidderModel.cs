
using Dto.Model.Common;
using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public class BidderListModel : Response
    {
        #region Properties
        public List<BidderModel>? Bidderlst { get; set; }
        #endregion
    }
    public class BidderModel
    {
        #region Properties
        public int? BidderID { get; set; }
        public string? BidderName { get; set; }
        public int? IsActive { get; set; }
        public int? loginUserID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion
    }
    public class singleBidderResponseModel : Response
    {
        #region Properties
        public BidderModel? singleBidder { get; set; }
        #endregion
    }
}
