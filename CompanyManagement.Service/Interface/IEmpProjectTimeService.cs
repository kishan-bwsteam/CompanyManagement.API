using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IEmpProjectTimeService
    {
        public Response saveUpdate(EmployeeProjectModel model);
        public EmployeeProjectList GetAll(string data);
        public EmployeeProjectList Getsingle(int data);
        public Response Delete(int data);
    }
}
