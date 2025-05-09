
using Dto.Model.Common;
using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public class ProfileListModel : Response
    {
        #region Properties
        public List<ProfileModel>? Profilelst { get; set; }
        #endregion
    }
    public class ProfileModel
    {
        #region Properties
        public int? ProfileId { get; set; }
        public string? ProfileName { get; set; }
        public int? PlatformId { get; set; }
        public bool? IsActive { get; set; }
        public int? loginUserId { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion
    }
    public class singleProfileResponseModel : Response
    {
        #region Properties
        public ProfileModel? singleProfile { get; set; }
        #endregion
    }
}
