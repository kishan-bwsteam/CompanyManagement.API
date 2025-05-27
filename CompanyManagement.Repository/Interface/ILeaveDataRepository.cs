
using CompanyManagement.Domain.Model;
using Dto.Model;
using Dto.Model.Common;
using System.Data;


namespace Datas.Abstract
{
    public interface ILeaveDataRepository
    {

        //--------------------------------------------Save Update Leave-------------------------------------

        PaginatedResult<LeaveRequestResponse> Get(DataTable filters, int limit, int startingRow);
        IEnumerable<LeaveStaus> GetLeaveStaus();
        Response SaveUpdate(LeaveModel model);

        Response UpdateStatus(int statusId, int leaveId, int actionBy);


        //-------------------------------------------Get All Leave by UserID------------------------------------------
        LeaveViewModels GetAllUser(int userID);


        //-------------------------------------------Get All Leave by LeaveViewModels--------------------------------------------------
        LeaveViewModels GetAll(int CompanyID);

        //------------------------------------------Update Approval Leave-------------------------------------------
        Response Update(int Accept, int leaveRequestID);

        //------------------------------------------ Get Status Dropdown by StatusViewModel-----------------------------
        StatusViewModel GetStatus( );

        //------------------------------------------ Get Reason Dropdown by ReasonViewModel-----------------------------

        ReasonViewModel GetReason();


        //------------------------------------------ Get Approval  by ReasonViewModel-----------------------------
        ReasonViewModel GetApp();



        //------------------------------------------ Get Attachment (upload file)  -----------------------------
        Response GetAtt(LeaveModel model);


        //---------------------------------------------Get Single Approve Leave model List by SingleApproveLeave-----------------------------------
        SingleApproveLeave GetSingle(int leaveRequestID);

        //-------------------------------------------- Delete Leave Request by leave Request ID------------------------------------------------------- 

        Response Delete(int leaveRequestID);

    }
}
