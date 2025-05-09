using Authentication.DataManager.Helper;
using Datas.Abstract;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;


namespace Service.Concrete
{
    public class CompanyShiftSettingService : ICompanyShiftSettingService
    {
        EncryptHelperObj obj = new EncryptHelperObj();
       

        private readonly ICompanyShiftSettingRepository _icompanyShiftSettingRepository;


        public CompanyShiftSettingService(ICompanyShiftSettingRepository _companyShiftSettingRepository)
        {
            _icompanyShiftSettingRepository = _companyShiftSettingRepository;
        }

        //--------------------------------Save Update Company Shift------------------------------------

        public Response SaveUpdate(ShiftSettingModel model)
        {
            try
            {
                return _icompanyShiftSettingRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------Get All Company Shift By CompanyID----------------------------------
        public ShiftSettingViewModel Get(int companyID)
        {
            try
            {
                return _icompanyShiftSettingRepository.Get(companyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //-----------------------------------Delete Shift by Shift ID-------------------------------------
        public Response Delete(int shiftID)

  

        {
            try
            {
                return _icompanyShiftSettingRepository.Delete(shiftID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SingleShiftSettingModel GetSingle(int CompanyId,int ShiftID)
        {
            try
            {
                return _icompanyShiftSettingRepository.GetSingle(CompanyId,ShiftID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
 }
