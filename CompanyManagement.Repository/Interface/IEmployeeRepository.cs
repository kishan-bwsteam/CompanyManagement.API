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
    public interface IEmployeeRepository
    {
        Response SaveEmployee(EmployeeModel emp);

        IEnumerable<EmployeeModel> Get(DataTable filters, int limit, int startingRow);
    }
}
