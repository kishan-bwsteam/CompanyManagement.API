using Authentication.DataManager.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Service.Concrete
{
 public   class EmployeeDetailService: IEmployeeDetailService
    {
        EncryptHelperObj obj = new EncryptHelperObj();

        private readonly IEmployeeDetailRepository _iemployeeDetailRepository;

        public EmployeeDetailService(IEmployeeDetailRepository _employeeDetailRepository)
        {
            _iemployeeDetailRepository = _employeeDetailRepository;
        }

        public Response SaveUpdate(EmployeeDetail emp, int ActionBy)
        {
            try
            {
                return _iemployeeDetailRepository.SaveOrUpdate(emp, ActionBy);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }


        //------------------------------------------------------ Get Employee Deatils by Company Id---------------------------------------------------------

        public EmployeeDetailViewModels Get(int companyId)
        {
            try
            {
                return _iemployeeDetailRepository.Get(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //------------------------------------------------------------------Delete Employee by userID -------------------------
        public Response Delete(int userID)
        {
            try
            {
                return _iemployeeDetailRepository.Delete(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
