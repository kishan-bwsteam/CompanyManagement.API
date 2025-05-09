using BussinessObject;
using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface ILeaveService
    {
        //--------------------------------------------Save Update Leave-------------------------------------


        Response SaveUpdate(LeaveModel model);



        //-------------------------------------------Get All Leave by userid--------------------------------------------
       LeaveViewModels GetAllUser(int userID);



        //-------------------------------------------Get All Leave by LeaveViewModels--------------------------------------------------
        LeaveViewModels GetAll(int companyID);

        //------------------------------------------Update Approval Leave-------------------------------------------
        Response Update(int Accept, int leaveRequestID);

        //------------------------------------------ Get Status Dropdown by StatusViewModel-----------------------------
        StatusViewModel GetStatus();

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
