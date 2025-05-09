using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Interface
{
    public interface IEmployeeService
    {
        Response Create(EmployeeModel emp);
        EmployeeModel Get(int id);
    }
}
