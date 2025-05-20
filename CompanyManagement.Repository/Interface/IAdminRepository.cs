using CompanyManagement.Domain.Model;
using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace CompanyManagement.Repository.Interface
{
    public interface IAdminRepository
    {
        Response SaveUpdate(AdminDetails model, DataTable dt, int ActionBy, EncryptHelperModel credentials);

        PaginatedResult<AdminDetails> Get(DataTable filters, int limit, int startingRow);
    }
}
