using Dto.Model.Common;
using Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Service.Abstract
{
    public interface IEmployeePerformanceService
    {
        Response SaveUpdate(EmployeePerformanceList model);
        List<EmployeePerformance> GetAll( int EmpID);
        EmployeePerformanceModel GetById(int id);
        Response EmployeePerformanceDelete(int id);
    }
}
