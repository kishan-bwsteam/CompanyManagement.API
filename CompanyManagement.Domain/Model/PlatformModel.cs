
using Dto.Model.Common;
using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public class PlatformListModel : Response
    {
        #region Properties
        public List<PlatformModel>? Platformlst { get; set; }
        #endregion
    }
    public class PlatformModel
    {
        #region Properties
        public int? PlatformId { get; set; }
        public string? PlatformName { get; set; }
        public int? LoginUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public int? CompanyId { get; set; }
        #endregion
    }

    public class singlePlatformResponseModel : Response
    {
        #region Properties
        public PlatformModel? singlePlatform { get; set; }
        #endregion
    }
}
