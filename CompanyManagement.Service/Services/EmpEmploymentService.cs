using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Responses;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


namespace Service.Concrete
{
  public  class EmpEmploymentService: IEmpEmploymentService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IEmpEmploymentRepository _iempEmploymentRepository;

       
        public EmpEmploymentService(IEmpEmploymentRepository _empEmploymentRepository) 
        {
            _iempEmploymentRepository = _empEmploymentRepository;
        }


        //--------------------------------------------- Save Update Employment ------------------------------------------------------------
        
        public EmploymentResponse SaveUpdate(EmploymentModel model)
        {
            try
            {
                return _iempEmploymentRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }


        //-------------------------------------- Get All Employement by AllEmploymentList----------------------------


        public AllEmploymentList GetAll()
        {
            try
            {
                return _iempEmploymentRepository.GetAll();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------------------------------------------------- Get Single Employment data by userID-----------------------------


        public SingleEmpModel GetSingle(int userID)
        {
            try
            {
                return _iempEmploymentRepository.GetSingle(userID);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }


        //----------------------------------------------------------- Delete Employment by UserID------------------------------------


        public EmploymentResponse Delete(int userID)
        {
            try
            {
                return _iempEmploymentRepository.Delete(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
