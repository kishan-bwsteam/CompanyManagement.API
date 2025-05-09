using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class PerformanceAttributeService : IPerformanceAttributeService
    {
        private readonly IPerformanceAttributeRepository _repository;
        public PerformanceAttributeService(IPerformanceAttributeRepository repository)
        {
            _repository = repository;
        }
        public List<PerformanceAttribute> GetAll( int CompanyID)
        {
            try
            {
                return _repository.GetAll(CompanyID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PerformanceAttributeModel GetById(int id)
        {
            try
            {
                PerformanceAttributeModel performanceAttribute = _repository.GetById(id);
                return performanceAttribute;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Response PerformanceAttributeDelete(int id)
        {
            try
            {
                return _repository.PerformanceAttributeDelete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Response SaveUpdate(PerformanceAttribute performanceAttribute)
        {
            try
            {
                return _repository.SaveUpdate(performanceAttribute);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTypeView GetData()
        {
            try
            {
                
                return _repository.GetData();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
