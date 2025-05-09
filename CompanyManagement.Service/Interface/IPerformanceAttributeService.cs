using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IPerformanceAttributeService
    {
        Response SaveUpdate(PerformanceAttribute performanceAttribute);
        List<PerformanceAttribute> GetAll(int CompanyID);
        PerformanceAttributeModel GetById(int id);
        Response PerformanceAttributeDelete(int id);
        DataTypeView GetData();

    }
}
