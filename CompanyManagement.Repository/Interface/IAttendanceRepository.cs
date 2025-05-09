using Dto.Model.Common;
using System.Collections.Generic;

namespace Datas.Abstract
{
    public interface IAttendanceRepository
    {


        //---------------------Save Update Attendance------------------------------- 
        Response SaveUpdate(AttendanceModal model);

        //---------------------Get All Employee------------------------------- 
        AttendanceViewModels GetAll( int companyID);


        //---------------------Delete Attendance-------------------------------

        Response Delete(int attendanceID);


        //---------------------Get Single Employee Attendance By EmployeeID-------------------------------
        SingleAttendanceViewModels GetSingle(int employeeID, int comapnyID);



        



      

    }

}
