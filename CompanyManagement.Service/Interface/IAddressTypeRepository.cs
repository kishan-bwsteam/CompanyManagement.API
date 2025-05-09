using CompanyManagement.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Interface
{
    public interface IAddressTypeService
    {
        Task<IEnumerable<AddressType>> GetAllAsync();
        Task SaveOrUpdateAsync(AddressType addressType);
    }

}
