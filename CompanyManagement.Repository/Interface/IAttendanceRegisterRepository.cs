

using Dto.Model.Common;

namespace Datas.Abstract
{
   public interface IAttendanceRegisterRepository
    {
        AttendanceViewModels GetAll(int companyID);

        GernateSalaryViewModels GernateSalary(int companyID, int date, int year);
    }
}
