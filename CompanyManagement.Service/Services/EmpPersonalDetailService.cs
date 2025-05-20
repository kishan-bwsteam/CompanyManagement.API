using CompanyManagement.Domain.Model;
using CompanyManagement.Service.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
    public class EmpPersonalDetailService : IEmpPersonalDetailService
    {
        EncryptHelperModel obj = new EncryptHelperModel();
        private readonly IEmpPersonalDetailRepository _iempPersonalDetailRepository;

        public EmpPersonalDetailService(IEmpPersonalDetailRepository _empPersonalDetailRepository) 
        {
            _iempPersonalDetailRepository = _empPersonalDetailRepository;
        }


        //---------------------------------------- Save Update Personal Details------------------------------------------

        public Response SaveUpdate(EmpPersonalDetailModel model)

        {
            obj = EncryptHelper.Get_EncryptedPassword(obj, model.Password);
            model.PassKey = obj.Value;
            model.SaltKey = obj.SaltKey;
            model.SaltKeyIV = obj.SaltKeyIV;
            try
            {
                return _iempPersonalDetailRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //--------------------------------------- Get All Personal Detail by EmpPersonalDetailViewModels----------------------------

        public EmpPersonalDetailViewModels Get()
        {
            try
            {
                return _iempPersonalDetailRepository.Get();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //-------------------------------------- Get Single Details by  SinglePersonalDetailResponseModel------------------

        public SinglePersonalDetailResponseModel GetSingle(int userID)

        {
            SinglePersonalDetailResponseModel response = new SinglePersonalDetailResponseModel();
            EncryptHelperModel _Obj = new EncryptHelperModel();
            try
            {
                response = _iempPersonalDetailRepository.GetSingle(userID);
            
            }
            catch (Exception ex)
            {
                return null;
            }
            return response;
        }


        //---------------------------------------- Delete User Details By UserID----------------------

        public Response Delete(int userID)

        {
            try
            {
                return _iempPersonalDetailRepository.Delete(userID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        //--------------------------------------------------- Get All Department by DepartmentViewModel-------------------------------


        public DepartmentViewModel GetDepartment()
        {
            try
            {
                return _iempPersonalDetailRepository.GetDepartment();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //---------------------------------------------------- Get All Position by PositionViewModel---------------------

        public PositionViewModel GetPosition()
        {
            try
            {
                return _iempPersonalDetailRepository.GetPosition();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
