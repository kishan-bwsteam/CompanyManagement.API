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
    public class LetterService : ILetterService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly ILetterRepository _iletterRepository;


        public LetterService(ILetterRepository _letterRepository)
        {
            _iletterRepository = _letterRepository;
        }

        //-------------------------------------------------Save Update Letter Template ------------------------------ 

        public Response SaveUpdate(LetterModel model)
        {
            try
            {
                return _iletterRepository.SaveUpdate(model);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //---------------------------------------------Get All Letter Template By LetterViewModel------------------
        public LetterViewModel GetAll(int companyID)
        {
            try
            {
                return _iletterRepository.GetAll(companyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //--------------------------------------------- Get  Single Template (List) by EmpID-----------------------

     

        public SingleLetterViewModel GetSingle(int letterID)
        {
            try
            {
                return _iletterRepository.GetSingle(letterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-------------------------------------------- Delete Template by EmpID----------------------------------

        public Response Delete(int letterID)
        {
            try
            {
                return _iletterRepository.Delete(letterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
