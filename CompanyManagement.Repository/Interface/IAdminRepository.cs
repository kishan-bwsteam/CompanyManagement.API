using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Repository.Interface
{
    public interface IAdminRepository
    {
        Response SaveUpdate(MultiformModel model, DataTable dt);

    }
}
