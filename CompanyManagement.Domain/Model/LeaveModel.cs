using Dto.Model.Common;
using System.Collections.Generic;


namespace Dto.Model
{

    //------------------------------------------------Leave model----------------------------------------------------
    public class LeaveModel
    {
        public int LeaveRequestID { get; set; }
        public int UserID { get; set; }
        public string StatusName { get; set; }
        public string ReasonName { get; set; }

        public string AttachmentName { get; set; }

        public string LeavePersonName { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public int IsDeleted { get; set; }
        public int LeaveStatusID { get; set; }
        public int LeaveReasonId { get; set; }
        public int LeaveRequestAttachmentID { get; set; }
    }

    //---------------------------------------------------------Leave Model List---------------------------------------

    public class LeaveViewModels : Response
    {
        public List<LeaveModel> leaveViewModel { get; set; }
    }

    //-------------------------------------------------------------Single Leave Model List-----------------------------------

    public class SingleLeaveResponseModel : Response
    {
        public LeaveModel SLeaveModel { get; set; }
    }


    //------------------------------- Single Approval Model List----------------------------------------------------

    public class SingleApproveLeave : Response
    {
        public LeaveModel SALeave { get; set; }
    }


    // ----------------------------------------------------------Leave Status Model-------------------------------------------------
    public class DropdownLeaveStatusModel : Response
    {
        public int LeaveStatusId { get; set; }
        public string StatusName { get; set; }
    }

    //---------------------------------------------------------Leave status Model List---------------------------------
    public class StatusViewModel : Response
    {
        public List<DropdownLeaveStatusModel> Statuslist { get; set; }
    }


    //------------------------------------------------------- Leave Reason Model----------------------------------------------
    public class DropdownLeaveReasonModel : Response
    {
        public int LeaveReasonId { get; set; }
        public string ReasonName { get; set; }
    }

    //------------------------------------------------------- Leave Reason Model List----------------------------------------------
    public class ReasonViewModel : Response
    {
        public List<DropdownLeaveReasonModel> Reasonlist { get; set; }
    }


   
}
