using CompanyManagement.Domain.Model;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Interface;
using Dto.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace CompanyManagement.Service.Services
{
    public class CountryStateService: ICountryStateService
    {
        private readonly ICountryStateRepository _countryStateRepository;

        public CountryStateService(ICountryStateRepository countryStateRepository)
        {
            _countryStateRepository = countryStateRepository;
        }

        public IEnumerable<CountryStateModel> GetStatesByCountryId(int countryId, int limit = 0, int startingRow = 0)
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

                // If limit is 0, return all records (you may need to adjust this based on your requirements)
                if (limit <= 0)
                {
                    limit = int.MaxValue; // Return all records
                }

                return _countryStateRepository.Get(filters, limit, startingRow);
            }
            catch (Exception ex)
            {
                // You might want to add logging here
                throw new Exception($"Error getting states for country ID {countryId}: {ex.Message}", ex);
            }
        }

        public IEnumerable<CountryStateModel> GetAllStates(int limit = 0, int startingRow = 0)
        {
            try
            {
                // Create empty filter table
                var filters = new DataTable("filter_type");
                filters.Columns.Add("operator", typeof(string));
                filters.Columns.Add("col", typeof(string));
                filters.Columns.Add("condition", typeof(string));
                filters.Columns.Add("val", typeof(string));

                // If limit is 0, return all records
                if (limit <= 0)
                {
                    limit = int.MaxValue;
                }

                return _countryStateRepository.Get(filters, limit, startingRow);
            }
            catch (Exception ex)
            {
                // You might want to add logging here
                throw new Exception($"Error getting all states: {ex.Message}", ex);
            }
        }
    }
}