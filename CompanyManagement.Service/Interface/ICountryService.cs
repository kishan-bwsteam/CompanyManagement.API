using CompanyManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Interface
{
    public interface ICountryService
    {
        CountryModel Get(int countryId);
        IEnumerable<CountryModel> GetAll(int limit = 0, int startingRow = 0);
    }
}
