using CompanyManagement.Domain.Model;
using Dto.Model.Common;
using System.Collections.Generic;
using System.Data;

namespace CompanyManagement.Service.Interface
{
    public interface IHolidayService
    {
        Response SaveUpdate(HolidayModel model, int actionBy);
        HolidayModel GetById(int holidayId);
        PaginatedResult<HolidayModel> GetAll(int companyId, int limit, int startingRow, string search = null);
        IEnumerable<HolidayModel> GetByUserId(int UserId, int Year);
        Response Delete(int HolidayID, int actionBy);

    }
}