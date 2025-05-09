using Authentication.DataManager.Helper;
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
   public  class SalaryService: ISalaryService 
    {
        EncryptHelperObj obj = new EncryptHelperObj();

        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public Response SaveUpdateSalary(SalaryModel model)
        {
            try
            {
                return _salaryRepository.SaveUpdateSalary(model);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

        public SalaryViewModel GetAllSalary()
        {
           try
            {
                return _salaryRepository.GetAllSalary();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public SingleSalaryModel GetSingleSalary(int SalaryComponentId)
        {
            try
            {
                return _salaryRepository.GetSingleSalary(SalaryComponentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Response DeleteSalary(int salaryComponentId)
        {
            try
            {
                return _salaryRepository.DeleteSalary(salaryComponentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SalaryNameViewModel GetSalaryName(string data)
        {
            try
            {
                return _salaryRepository.GetSalaryName(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetSalaryComponentTypeView GetSalaryComponentType(int companyid)
        {
            try
            {
                return _salaryRepository.GetSalaryComponentType(companyid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Response UpdateSalVal(SalaryStructureModel nameModel)
        {
            Response response = new Response();
            try
            {
                foreach (var items in nameModel.salaryname)
                {
                    response = _salaryRepository.UpdateSalVal(items,nameModel.SalaryStructure, nameModel.StructureId);
                }
             
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Response UpdateFeildName(UpdateFeildName nameModel)
        {
            try
            {
                return _salaryRepository.UpdateFeildName(nameModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Response SaveUpdateSalaryStructure(CompanySalaryStructureModel model)
        {
            try
            {
                return _salaryRepository.SaveUpdateSalaryStructure(model);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

        public Response DeleteSalaryStructure(int salaryComponentId)
        {
            try
            {
                return _salaryRepository.DeleteSalaryStructure(salaryComponentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompanySalaryStructreView GetAllSalaryStructure(int companyId)
        {
            try
            {
                return _salaryRepository.GetAllSalaryStructure(companyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompanySalaryStructureModel GetSingleSalaryStructure(int structureId)
        {
            try
            {
                return _salaryRepository.GetSingleSalaryStructure(structureId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
