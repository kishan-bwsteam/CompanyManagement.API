using CompanyManagement.Domain.Model;
using Dto.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Repository.Interface
{
    public interface ICountryStateRepository
    {
        IEnumerable<CountryStateModel> Get(DataTable filters, int limit, int startingRow);

    }
}
