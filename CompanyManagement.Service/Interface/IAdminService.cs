using CompanyManagement.Domain.Model;
using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Interface
{
    public interface IAdminService
    {
        Response SaveUpdate(AdminDetails model,int ActionBy);
        PaginatedResult<AdminDetails> GetAdminList(int limit = 10, int startingRow = 0, string? search = null);
        AdminDetails GetAdmin(int AdminId);
        Response DeleteAdmin(int AdminId);
    }
}
