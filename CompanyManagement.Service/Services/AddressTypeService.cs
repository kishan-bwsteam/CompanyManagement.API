using CompanyManagement.Domain.Model.Common;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Services
{
    public class AddressTypeService : IAddressTypeService
    {
        private readonly IAddressTypeRepository _repository;

        public AddressTypeService(IAddressTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AddressType>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task SaveOrUpdateAsync(AddressType addressType) => await _repository.SaveOrUpdateAsync(addressType);
    }

}
