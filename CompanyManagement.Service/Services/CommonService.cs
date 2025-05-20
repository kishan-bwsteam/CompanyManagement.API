using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


namespace Service.Concrete
{
   public class CommonService : ICommonService
    {
        EncryptHelperModel obj = new EncryptHelperModel();


        private readonly ICommonRepository _commonRepository;
        //-------------------------------------------Get Country Dropdown-------------------------------------------------------

        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }
        public CountryDropdown GetCountry()
        {
            try
            {
                return _commonRepository.GetCountry();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //------------------------------------------- Get State Dropdown -------------------------------------------------------

        public StateDropdown GetState()
        {
            try
            {
                return _commonRepository.GetState();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
