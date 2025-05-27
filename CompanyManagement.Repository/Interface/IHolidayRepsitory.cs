using CompanyManagement.Domain.Model;
using Dto.Model;
using Dto.Model.Common;
using System.Data;

namespace CompanyManagement.Repository.Interface
{
    public interface IHolidayRepsitory
    {
        Response SaveOrUpdate(HolidayModel model, int actionBy);
        PaginatedResult<HolidayModel> Get(DataTable filters, int limit, int startingRow);
        Response Delete(int HolidayID, int actionBy);

    }
}