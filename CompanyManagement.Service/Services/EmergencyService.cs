using CompanyManagement.Domain.Model;
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
    public class EmergencyService : IEmergencyService
    {

        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IEmergencyRepository _iemergencyRepository;

        public EmergencyService(IEmergencyRepository _emargencyRepository)
        {
            _iemergencyRepository = _emargencyRepository;
        }



        //-----------------------------------------------save Update Emergency Details---------------------------------------

        public Response SaveUpdate(EmergencyModel model)
        {
            try
            {
                return _iemergencyRepository.SaveUpdate(model);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //--------------------------------- Get All Emergency Details by EmergencyModelView----------------------------------------

        public EmergencyModelView GetAll(int userID)
        {
            try
            {
                return _iemergencyRepository.GetAll(userID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //----------------------------------------------Delete Emergency Details by emergency ID--------------------------------------------


        public Response Delete(int emergencyID)
        {
            try
            {
                return _iemergencyRepository.Delete(emergencyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
