
using Dto.Model.Common;
using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public class ProjectListModel : Response
    {
        #region Properties
        public List<ProjectModel> Projectlst { get; set; }
        #endregion
    }
    public class ProjectModel
    {

        #region Properties
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ProfileId { get; set; }
        public string ClientName { get; set; }
        public DateTime StartingDate { get; set; }
        public int ProjectTypeId { get; set; }
        public int DepartmentId { get; set; }
        public int NumberOfHours { get; set; }//
        public decimal HourlyRate { get; set; }//
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int BidderId { get; set; }
        public string Skills { get; set; }
        public int loginUserId { get; set; }
        public int IsDeleted { get; set; }
     //
        public int ProjectStatusId { get; set; }
        public DateTime? DueDate { get; set; }
        public string FeedBackRecieved { get; set; }
        public int RatingReceived { get; set; }
        public string Notes { get; set; }
        public int CompanyId { get; set; }
        public int Amount { get; set; }
        public int SalaryTypeId { get; set; }
        public int ProjectAmountId { get; set; }

        #endregion
    }

    public class singleProjectResponseModel : Response
    {
        #region Properties
        public ProjectModel singleProject { get; set; }
        #endregion
    }

    #region ProjectType enum
    public enum ProjectType
    {
        Hourly = 1,
        Fixed=2,
        Weekly = 3
    }
    #endregion

    #region Status enum
    public enum Status
    {
        Active = 1,
        Close = 2,
        Pause = 3
    }

    public class BidderList
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string EmpName { get; set; }
    }

    public class BidderViewModel : Response
    {
        public List<BidderList> bidderLists { get; set; }
    }
    #endregion
}
