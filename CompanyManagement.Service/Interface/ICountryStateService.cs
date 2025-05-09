using CompanyManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Interface
{
    public interface ICountryStateService
    {
        IEnumerable<CountryStateModel> GetStatesByCountryId(int countryId, int limit = 0, int startingRow = 0);
        IEnumerable<CountryStateModel> GetAllStates(int limit = 0, int startingRow = 0);
    }
}
