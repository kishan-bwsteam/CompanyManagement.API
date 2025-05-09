using CompanyManagement.Domain.Model;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Services
{
    public class CountryService:ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public CountryModel Get(int countryId)
        {
            try
            {
                // Create filter DataTable to filter by CountryId
                var filters = new DataTable("filter_type");
                filters.Columns.Add("operator", typeof(string));
                filters.Columns.Add("col", typeof(string));
                filters.Columns.Add("condition", typeof(string));
                filters.Columns.Add("val", typeof(string));

                // Add filter for CountryId (using AND as first operator)
                filters.Rows.Add("AND", "CountryId", "=", countryId.ToString());
                var result = _countryRepository.Get(filters, 1, 0).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                // You might want to add logging here
                throw new Exception($"Error getting country ID {countryId}: {ex.Message}", ex);
            }
        }

        public IEnumerable<CountryModel> GetAll(int limit = 0, int startingRow = 0)
        {
            try
            {
                if (limit <= 0)
                {
                    limit = int.MaxValue;
                }

                return _countryRepository.Get(null, limit, startingRow);
            }
            catch (Exception ex)
            {
                // You might want to add logging here
                throw new Exception($"Error getting all states: {ex.Message}", ex);
            }
        }
    }
}
