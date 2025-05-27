
using CompanyManagement.Domain.RequestDTO;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers
{
    [Route("api/Leave/")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _ileaveService;
        private readonly IConfiguration _config;
        public LeaveController(ILeaveService _leaveService, IConfiguration configuration)
        {
            _ileaveService = _leaveService;
            _config = configuration;
        }

        //--------------------------------------------Save Update Leave-------------------------------------
        [HttpGet("{LeaveId}")]
        public IActionResult GetByLeaveId(int LeaveId)
        {
            var res = _ileaveService.GetByLeaveId(LeaveId);
            return Ok(res);
        }
        [HttpGet("Company/{CompanyId}")]
        public IActionResult GetByCompanyId(int CompanyId, [FromQuery] int? limit, [FromQuery] int? startingRow, [FromQuery] string? search)
        {
            var res = _ileaveService.GetByCompanyId(CompanyId, limit.GetValueOrDefault(10), startingRow.GetValueOrDefault(0), search);
            return Ok(res);
        }

        [HttpGet("Admin")]
        public IActionResult GetByAdminId([FromQuery] int? limit, [FromQuery] int? startingRow, [FromQuery] string? search)
        {
            var id = User.FindFirst("userID").Value;
            var AdminId = Int32.Parse(id);
            var res = _ileaveService.GetByAdminId(AdminId, limit.GetValueOrDefault(10), startingRow.GetValueOrDefault(0), search);
            return Ok(res);
        }

        [HttpGet("User")]
        public IActionResult GetByUserId([FromQuery] int? limit, [FromQuery] int? startingRow, [FromQuery] string? search)
        {
            var id = User.FindFirst("userID").Value;
            var UserId = Int32.Parse(id);
            var res = _ileaveService.GetByUserId(UserId, limit.GetValueOrDefault(10), startingRow.GetValueOrDefault(0), search);
            return Ok(res);
        }


        [HttpPost]
     
        public Response SaveUpdate(LeaveModel model)
        {
            try
            {
                return _ileaveService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPatch]
        public IActionResult UpdateStatus(ChangeLeaveStatusModel lModel)
        {
            var id = User.FindFirst("userID").Value;
            var UserId = Int32.Parse(id);
            var res = _ileaveService.UpdateStatus(lModel,UserId);
            return Ok(res);
        }
        [HttpGet("status")]
        public IActionResult GetLeaveStatus()
        {
            var res = _ileaveService.GetLeaveStatus();
            return Ok(res);
        }

        [HttpGet("GetReason/")]

        public ReasonViewModel GetReason()
        {
            try
            {
                return _ileaveService.GetReason();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //-------------------------------------------Get All Leave by LeaveViewModels--------------------------------------------------


        //   [HttpGet ("User/{userID}")]
        //   public LeaveViewModels GetAllUser(int userID)
        //   {
        //       try
        //       {
        //           return _ileaveService.GetAllUser(userID);
        //       }
        //       catch (Exception ex)
        //       {
        //           throw ex;
        //       }
        //   }




        //   //-------------------------------------------Get All Leave by LeaveViewModels--------------------------------------------------


        //   [HttpGet("Company/{CompanyID}")]
        //   public LeaveViewModels GetAll(int CompanyID)
        //   {
        //       try
        //       {
        //           return _ileaveService.GetAll(CompanyID);
        //       }
        //       catch (Exception ex)
        //       {
        //           throw ex;
        //       }
        //   }




        //   //---------------------------------------------Get Single Approve Leave model List by SingleApproveLeave-----------------------------------

        //   [HttpGet("GetSingle/{leaveRequestID}")]
        ////   [Route("GetSingleApproveLeave/{leaveRequestID}")]
        //   public SingleApproveLeave GetSingle(int leaveRequestID)
        //   {
        //       try
        //       {
        //           return _ileaveService.GetSingle(leaveRequestID);
        //       }
        //       catch (Exception ex)
        //       {
        //           throw ex;
        //       }
        //   }


        //------------------------------------------Update Approval Leave-------------------------------------------

        // [HttpPut]

        // public Response Update(int Accept, int leaveRequestID)
        // {
        //     try
        //     {
        //         return _ileaveService.Update(Accept, leaveRequestID);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }


        // //------------------------------------------ Get Status Dropdown by StatusViewModel-----------------------------


        // [HttpGet("GetStatus/")]

        // public StatusViewModel GetStatus()
        // {
        //     try
        //     {
        //         return _ileaveService.GetStatus();
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }

        // //------------------------------------------ Get Reason Dropdown by ReasonViewModel-----------------------------



        // //------------------------------------------ Get Approval  by ReasonViewModel-----------------------------

        // [HttpGet("GetApp/")]
        ////[Route("GetApp/")]

        // public ReasonViewModel GetApp()
        // {
        //     try
        //     {
        //         return _ileaveService.GetApp();
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }


        // //------------------------------------------ Get Attachment (upload file)  -----------------------------

        // [HttpGet("GetAtt/")]
        // //[Route("GetAtt/")]
        // public Response GetAtt(LeaveModel model)
        // {
        //     try
        //     {
        //         return _ileaveService.GetAtt(model);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }


        //-------------------------------------------- Delete Leave Request by leave Request ID------------------------------------------------------- 


        [HttpDelete("{leaveRequestID}")]
        public Response Delete(int leaveRequestID)
        {
            try
            {
                return _ileaveService.Delete(leaveRequestID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


}


