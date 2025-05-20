using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


namespace Service.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        EncryptHelperModel obj = new EncryptHelperModel();
        private readonly IDepartmentRepository _idepartmentRepository;

        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            this._idepartmentRepository = _departmentRepository;
        }




        //----------------------------------------------Save Upadate Department------------------------------- 

        public Response Saveupdate(DepartmentModel model)
        {
            try
            {
                return _idepartmentRepository.Saveupdate(model);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //---------------------------------------------------Get All Department by DepartmentViewModels (List)------------------------

        public DepartmentViewModels GetAll(int companyID)
        {
            try
            {
                return _idepartmentRepository.GetAll(companyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //------------------------------------------------- Get Single Department By Department ID------------------------- 

        public SingleDepartmentModel GetSingle(int departmentId)
        {
            try
            {
                return _idepartmentRepository.GetSingle(departmentId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //-------------------------------------------- Delete Department By Department ID---------------------------------

        public Response Delete(int departmentId)
        {
            try
            {
                return _idepartmentRepository.Delete(departmentId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
