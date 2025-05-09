using CompanyManagement.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Repository.Interface
{

    public interface IAddressTypeRepository
    {
        Task<IEnumerable<AddressType>> GetAllAsync();
        Task SaveOrUpdateAsync(AddressType addressType);
    }


}




