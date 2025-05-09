
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Models
{
    public class ProjectWeeklyReportListModel : Response
    {
        #region Properties
        public List<ProjectWeeklyReportModel>? ProjectWeeklyReportlst { get; set; }
        #endregion
    }
    public class ProjectWeeklyReportModel
    {
        #region Properties
        public int? ProjectWeeklyReportId { get; set; }
        public int? ProjectID { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? TotalHours { get; set; }
       
        public int? loginUserID { get; set; }
        public int? IsDeleted { get; set; }
        #endregion
    }
    public class singleProjectWeeklyReportResponseModel : Response
    {
        #region Properties
        public ProjectWeeklyReportModel? singleProjectWeeklyReport { get; set; }
        #endregion
    }
}
