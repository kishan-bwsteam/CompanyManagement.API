
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.Attendance
{
    [Route("api/Attendance")]
    [ApiController]
    public class AttendanceControllers : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IConfiguration _config;
        public AttendanceControllers(IAttendanceService _iattendanceService, IConfiguration configuration)
        {
            _attendanceService = _iattendanceService;
            _config = configuration;
        }

        //------------------- Save  and Update Attendance------------------------ 

        [HttpPost]
        public Response SaveUpdate(AttendanceModal model)

        {
            try
            {
                return _attendanceService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------- Delete Attendance------------------------ 

        [HttpDelete]

        public Response Delete(int attendanceID)
        {
            try
            {
                return _attendanceService.Delete(attendanceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //----------------------------- Get All Attendance------------------------ 
        [HttpGet("company/{companyID}")]
      
        public AttendanceViewModels GetAll(int companyID)
        {
            try
            {
                return _attendanceService.GetAll(companyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //----------------------------- Get Single Attendance------------------------


        [HttpGet ("company/{companyID}/employee/{employeeID}")]

        public SingleAttendanceViewModels GetSingle(int companyID,int employeeID)
        {
            try
            {
                return _attendanceService.GetSingle(employeeID, companyID);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
       

    }
}