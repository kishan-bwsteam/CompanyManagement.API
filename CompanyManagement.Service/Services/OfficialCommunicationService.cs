
using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Responses;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


namespace Service.Concrete
{
 public    class OfficialCommunicationService : IOfficialCommunicationService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IOfficialCommunicationRepository _iofficialCommunicationRepository;

        public OfficialCommunicationService(IOfficialCommunicationRepository _officialCommunicationRepository)
        {
            _iofficialCommunicationRepository = _officialCommunicationRepository;
        }


        //--------------------------------------------Save Upadte Offical information----------------------


        //public OfficalCommResponse SaveUpdate(OfficalCommModel model)
        //{
        //    try
        //    {
        //        return _iofficialCommunicationRepository.SaveUpdate(model);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        ////------------------------------------------- Get All offical Communication by OfficalViewModel--------------
        //public OfficalViewModel Get()
        //{
        //    try
        //    {
        //        return _iofficialCommunicationRepository.Get();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //------------------------------------------- Get SaveUpdate Other-----------------------------------------
        public OfficalCommResponse SaveUpdate(OfficialOtherModel model)
        {
            try
            {
                return _iofficialCommunicationRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------------------------Get AllOthers Details by   OfficalOtherModelList-----------------------------------------

        public OfficalOtherModelList Get()
        {
            try
            {
                return _iofficialCommunicationRepository.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-----------------------------------------------------Delete Offical Details by OfficalID--------------------------------
        public OfficalCommResponse Delete(int OfficalID)
        {
            try
            {
                return _iofficialCommunicationRepository.Delete(OfficalID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
