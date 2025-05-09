using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas.Abstract
{
    public interface IEmployeePerformanceRepository
    {
        Response SaveUpdate(EmployeePerformanceList model, DataTable AttributeData);
        List<EmployeePerformance> GetAll( int EmpID);
        EmployeePerformanceModel GetById(int id);
        Response EmployeePerformanceDelete(int id);
        //Response SaveUpdate(EmployeePerformance employeePerformance, DataTable attributeList);
    }
}
