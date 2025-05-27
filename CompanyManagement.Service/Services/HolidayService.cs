using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Domain.Model;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Interface;
using Datas.Abstract;
using Dto.Model.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Services
{
    public class HolidayService:IHolidayService
    {
        private readonly IHolidayRepsitory _holidayRepsitory;
        private readonly IEmployeeRepository _employeeRepository;

        public HolidayService(IHolidayRepsitory holidayRepsitory, IEmployeeRepository employeeRepository)
        {
            this._holidayRepsitory = holidayRepsitory;
            _employeeRepository = employeeRepository;
        }
        // Save or Update holiday
        public Response SaveUpdate(HolidayModel model, int actionBy)
        {
            var res = _holidayRepsitory.SaveOrUpdate(model, actionBy);
            return res;
        }
        private DataTable CreateBaseFilter(string column, string value)
        {
            var filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", column, "=", value);

            return filters;
        }

        private void AddSearchFilters(DataTable filters, string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                filters.Rows.Add("OR", "HolidayName", "LIKE", $"%{search}%");
            }
        }

        // Get holiday by ID
        public HolidayModel GetById(int holidayId)
        {
            DataTable filters = CreateBaseFilter("HolidayID", holidayId.ToString());
            var res = _holidayRepsitory.Get(filters, 1, 0).Data.FirstOrDefault();
            return res;
        }

        // Get all holidays or filtered
        public PaginatedResult<HolidayModel> GetAll(int companyId, int limit, int startingRow, string search = null)
        {
            DataTable filters = CreateBaseFilter("CompanyID", companyId.ToString());
            if (!string.IsNullOrWhiteSpace(search))
            {
                AddSearchFilters(filters, search);
            }

            return _holidayRepsitory.Get(filters, limit, startingRow);
        }
        public IEnumerable<HolidayModel> GetByUserId(int UserId,int Year)
        {
            DataTable filters = CreateBaseFilter("UserID", UserId.ToString());
            var emp = _employeeRepository.Get(filters, 1, 0).FirstOrDefault();
            if (emp == null) return null;
            filters = CreateBaseFilter("CompanyID", emp.CompanyId.ToString());
            filters.Rows.Add("AND", "Year", "=", Year.ToString());
            var res = _holidayRepsitory.Get(filters, 0, 0);
            return res.Data;
        }
        public Response Delete(int HolidayID, int actionBy)
        {
            var res = _holidayRepsitory.Delete(HolidayID, actionBy);
            return res;
        }
    }
}
