using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class EmpProjectTimeService: IEmpProjectTimeService
    {
        private readonly IEmpProjectTimeRepository _iEmployeeProjectTimeRepository;

       public EmpProjectTimeService(IEmpProjectTimeRepository iEmployeeProjectTimeRepository)
        {
            _iEmployeeProjectTimeRepository = iEmployeeProjectTimeRepository;
        }


        //----------------------------------------------------------------------saveUpdate
        public Response saveUpdate(EmployeeProjectModel model)
        {
            try
            {
                return _iEmployeeProjectTimeRepository.saveUpdate(model);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //----------------------------------------------------------------------saveUpdate
        public EmployeeProjectList GetAll(string data)
        {
            try
            {
                return _iEmployeeProjectTimeRepository.GetAll(data);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //----------------------------------------------------------------------Getsingle
        public EmployeeProjectList Getsingle(int data)
        {
            try
            {
                return _iEmployeeProjectTimeRepository.Getsingle(data);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        //----------------------------------------------------------------------Delete
        public Response Delete(int data)
        {
            try
            {
                return _iEmployeeProjectTimeRepository.Delete(data);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
