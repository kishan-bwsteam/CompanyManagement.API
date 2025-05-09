using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IAttendanceRegisterService
    {
        AttendanceViewModels GetAll(int companyID);

        Response GernateSalary(int companyID, int date,int year);
    }
}
