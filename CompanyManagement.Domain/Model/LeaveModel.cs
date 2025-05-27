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

    public class LeaveRequestResponse
    {
        // Company Info
        public int CompanyID { get; set; }
        public string CompanyGuid { get; set; }
        public string CompanyName { get; set; }

        // Employee Info
        public string EmpCode { get; set; }
        public string UserName { get; set; }
        public string EmpFullName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int EmployeeStatusID { get; set; }
        public string StatusName { get; set; }

        // Leave Request Info
        public int LeaveRequestID { get; set; }
        public int LeaveStatusId { get; set; }
        public string LeaveStatusName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int LeaveReasonId { get; set; }
        public string ReasonName { get; set; }

        // Leave Detail
        public DateTime LeaveDate { get; set; }
        public string AttachmentName { get; set; }
    }
    public class LeaveStaus
    {
        public int LeaveStatusId { get; set; }
        public string StatusName { get; set; }
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
