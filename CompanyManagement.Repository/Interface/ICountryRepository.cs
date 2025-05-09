using CompanyManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Repository.Interface
{
    public interface ICountryRepository
    {
        IEnumerable<CountryModel> Get(DataTable filters, int limit, int startingRow);
    }
}
