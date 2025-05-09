using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datas.Abstract
{
    public interface IEmpProjectTimeRepository
    {
        Response saveUpdate(EmployeeProjectModel model);

        EmployeeProjectList GetAll(string data);
       EmployeeProjectList Getsingle(int data);
        Response Delete(int data);
    }
}
