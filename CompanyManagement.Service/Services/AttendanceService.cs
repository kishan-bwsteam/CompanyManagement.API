using Authentication.DataManager.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;

namespace Service.Concrete
{
    public class AttendanceService : IAttendanceService
    {

        private readonly IAttendanceRepository _iattendanceRepository;


        public AttendanceService(IAttendanceRepository _attendanceRepository)
        {
            _iattendanceRepository = _attendanceRepository;
        }



        //---------------------Save Update Attendance------------------------------- 

        public Response SaveUpdate(AttendanceModal model)
        {
            try
            {
                return _iattendanceRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //---------------------Get All Employee------------------------------- 
        public AttendanceViewModels GetAll(int companyID)
        {
            try
            {
                return _iattendanceRepository.GetAll(companyID);

      

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //---------------------Delete Attendance-------------------------------
        public Response Delete(int attendanceID)
        {
            try
            {
                return _iattendanceRepository.Delete(attendanceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //---------------------Get Single Employee Attendance By EmployeeID-------------------------------
        public SingleAttendanceViewModels GetSingle(int employeeID, int comapnyID)
        {
            try
            {
                return _iattendanceRepository.GetSingle(employeeID, comapnyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      










    }



}