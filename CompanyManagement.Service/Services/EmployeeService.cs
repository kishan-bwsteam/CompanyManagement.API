using Authentication.DataManager.Helper;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Interface;
using CompanyManagement.Services.Service.Abstract;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.Exchange.WebServices.Data;
using Service.Abstract;
using SqlDapper.Abstract;
using System.Data;
using System.Linq;

namespace CompanyManagement.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EncryptHelperObj obj = new EncryptHelperObj();

        public readonly IDatabaseContext _idb_context;
        private readonly IEmployeeRepository _empRepo;
        public readonly IEmpAddressService _empAddressService;
        private readonly IEmpBankService _empBankService;
        private readonly IUserService _userService;
        private readonly IEmpEducationService _empEducationService;

        public EmployeeService(IDatabaseContext _db_context,
            IEmpAddressService empAddressService,
            IEmpBankService empBankService,
            IEmpEducationService empEducationService,
            IUserService userService,
            IEmployeeRepository employeeRepo)
        {
            _idb_context = _db_context;
            _empRepo = employeeRepo;
            _empAddressService = empAddressService;
            _empBankService = empBankService;
            _userService = userService;
            _empEducationService = empEducationService;
        }
        public Response Create(EmployeeModel emp)
        {
            try
            {
                emp.UserPassKey = new UserPassKey();
                obj = EncryptHelper.Get_EncryptedPassword(obj, "123456");
                emp.UserPassKey.PassKey = obj.Value;
                emp.UserPassKey.SaltKey = obj.SaltKey;
                emp.UserPassKey.SaltKeyIV = obj.SaltKeyIV;
                return _empRepo.SaveEmployee(emp);
            }
            catch
            {
                return new Response() { Status = 400, Message = "Somthing went wrong!!" };
            }
        }
        public EmployeeModel GetByEmpId(int id)
        {
            DataTable filters = null;
            filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "EmpId", "=", id);
            EmployeeModel emp = _empRepo.Get(filters,1,0).FirstOrDefault();
            if (emp == null) return null;
            emp.UserBasic = _userService.GetByUserId(emp.UserID.GetValueOrDefault());
            emp.UserEducation = _empEducationService.GetByUserId(emp.UserID.GetValueOrDefault());
            emp.UserAddress = _empAddressService.GetByUserId(emp.UserID.GetValueOrDefault());
            emp.UserBankDetail = _empBankService.GetByUserId(emp.UserID.GetValueOrDefault());
            return emp;
        }
        public EmployeeModel GetByUserId(int id)
        {
            DataTable filters = null;
            filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "UserId", "=", id);
            EmployeeModel emp = _empRepo.Get(filters, 1, 0).FirstOrDefault();
            if (emp == null) return null;
            emp.UserBasic = _userService.GetByUserId(emp.UserID.GetValueOrDefault());
            emp.UserEducation = _empEducationService.GetByUserId(emp.UserID.GetValueOrDefault());
            emp.UserAddress = _empAddressService.GetByUserId(emp.UserID.GetValueOrDefault());
            emp.UserBankDetail = _empBankService.GetByUserId(emp.UserID.GetValueOrDefault());
            return emp;
        }

        public Response Delete(int EmpId, int ActionBy)
        {
            var result = _empRepo.Delete(EmpId, ActionBy);
            return result;
        }

    }
}
