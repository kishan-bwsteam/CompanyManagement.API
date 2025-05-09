using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.Attendance
{
    [Route("api/AttendanceRegister")]
    [ApiController]
    
    public class AttendanceRegisterController : ControllerBase
    {
        private readonly IAttendanceRegisterService attendanceRegisterService;

        public AttendanceRegisterController(IAttendanceRegisterService _AttendanceRegesterService)
        {
            attendanceRegisterService = _AttendanceRegesterService;
           
        }

       [HttpGet("companyID/{companyID}")]
       
        public AttendanceViewModels GetAll(int companyID)
        {
            try
            {
                return attendanceRegisterService.GetAll(companyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }



 
}
