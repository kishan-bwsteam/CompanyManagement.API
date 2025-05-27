using BussinessObject;
using CompanyManagement.Domain.Model;
using CompanyManagement.Domain.RequestDTO;
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
        IEnumerable<LeaveStaus> GetLeaveStatus();
        LeaveRequestResponse GetByLeaveId(int LeaveRequestId);
        // Interface
        PaginatedResult<LeaveRequestResponse> GetByCompanyId(int companyId, int limit, int startingRow, string search);
        PaginatedResult<LeaveRequestResponse> GetByAdminId(int adminId, int limit, int startingRow, string search);
        PaginatedResult<LeaveRequestResponse> GetByUserId(int userId, int limit, int startingRow, string search);

        Response UpdateStatus(ChangeLeaveStatusModel lModel, int actionBy);


        Response SaveUpdate(LeaveModel model);

        ReasonViewModel GetReason();


        Response Delete(int leaveRequestID);

    }
}
