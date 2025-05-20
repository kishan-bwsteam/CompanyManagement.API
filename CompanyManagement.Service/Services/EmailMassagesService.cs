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
   public  class EmailMassagesService : IEmailMassagesService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IEmailMassagesRepository _iemailMassagesRepository;

        public EmailMassagesService(IEmailMassagesRepository _emailMassagesRepository)
        {
            _iemailMassagesRepository = _emailMassagesRepository;
        }



		//-------------------------------------------------Save Update Email message ------------------------------ 

		public Response SaveUpdate(EmailMassagesModel model)
        {
            try
            {
                return _iemailMassagesRepository.SaveUpdate(model);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

		//---------------------------------------- Get All Email message by EmailMessagesViewModel (List)---------------------

		public EmailMessagesViewModel GetAll(int UserID)
		{
			try
			{
				return _iemailMassagesRepository.GetAll(UserID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		public EmailMessagesViewModel GetAllCompanyMail(int CompanyID)
		{
			try
			{
				return _iemailMassagesRepository.GetAllCompanyMail(CompanyID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}




		//--------------------------------------------- Get  Single Message (List) by EmpID-----------------------
		public SingleEmailMassagesViewModel GetSingle(int empID)
		{
			try
			{
				return _iemailMassagesRepository.GetSingle(empID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		//-------------------------------------------- Delete Email Message by EmpID----------------------------------
		public Response Delete(int empID)
		{
			try
			{
				return _iemailMassagesRepository.Delete(empID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
