using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service.Concrete
{
    public  class EmpEducationService: IEmpEducationService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IEmpEducationRepository _iempEducationRepository;
        public EmpEducationService(IEmpEducationRepository _empEducationRepository)
        {
            _iempEducationRepository = _empEducationRepository;
        }


        //------------------------------------------------ Save Update Education-----------------------------------------  

        public Response SaveUpdate(EducationModel model,int actionBy)
        {
            try
            {
                return _iempEducationRepository.SaveOrUpdate(model, actionBy);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

        //-------------------------------------- Get All Education Details by EducationViewModels --------------------------

        public EducationViewModels GetAll()
        {
            try
            {
                return _iempEducationRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //----------------------------------------- Get Single Education List by UserID----------------------------------------- 
        public singleEducationModel GetSingle(int userID)
        {
            try
            {
                return _iempEducationRepository.GetSingle(userID);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

        //--------------------------------------------- Delete Education List by UserID---------------------------------------------------

        public EducationResponse Delete(int userID)
        {
            try
            {
                return _iempEducationRepository.Delete(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public IEnumerable<UserEducation> GetByUserId(int UserId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "UserId", "=", UserId.ToString());

            var result = _iempEducationRepository.Get(filters, 10, 0);

            return result;
        }
    }
}
