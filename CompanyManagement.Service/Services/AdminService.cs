
using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Data.Datas.Concrete;
using CompanyManagement.Domain.Model;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Helper;
using CompanyManagement.Service.Interface;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using System;
using System.Data;
using System.Linq;

namespace CompanyManagement.Service.Services
{
    public class AdminService : IAdminService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepo;
        public AdminService(IAdminRepository adminRepository,
            ICompanyRepository companyRepository,
            IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _companyRepo = companyRepository;
        }


        //--------------------------------------------------------- Save Update user-------------------------------------

        public Response SaveUpdate(AdminDetails model, int ActionBy)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CompanyID", typeof(int));
                dt.Columns.Add("CompanyGuid", typeof(string));
                dt.Columns.Add("CompanyName", typeof(string));
                dt.Columns.Add("GSTIN", typeof(string));
                dt.Columns.Add("CIN", typeof(string));
                dt.Columns.Add("AddressLine1", typeof(string));
                dt.Columns.Add("AddressLine2", typeof(string));
                dt.Columns.Add("City", typeof(string));
                dt.Columns.Add("StateId", typeof(int));
                dt.Columns.Add("ZipCode", typeof(int));
                dt.Columns.Add("CountryID", typeof(int));


                if (model.CompanyList.Count() > 0)
                {

                    foreach (var item in model.CompanyList)
                    {
                        DataRow dr = dt.NewRow();
                        dr["CompanyID"] = item.CompanyId;
                        dr["CompanyGuid"] = item.CompanyGuid ?? (object)DBNull.Value;
                        dr["CompanyName"] = item.CompanyName;
                        //dr["FranchiseID"] = item.FranchiseID ?? (object)DBNull.Value;
                        dr["GSTIN"] = item.GSTIN;
                        dr["CIN"] = item.CIN;
                        dr["AddressLine1"] = item.AddressLine1;
                        dr["AddressLine2"] = item.AddressLine2;
                        dr["City"] = item.City;
                        dr["StateId"] = item.StateId;
                        dr["ZipCode"] = item.ZipCode;
                        dr["CountryID"] = item.CountryId;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }
                obj = EncryptHelper.Get_EncryptedPassword(obj, "123456");



                return _adminRepository.SaveUpdate(model, dt, ActionBy,obj);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public PaginatedResult<AdminDetails> GetAdminList(int limit = 10, int startingRow = 0, string? search = null)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));
            if (search != null)
            {
                filters.Rows.Add("AND", "FirstName", "Like", $"%{search}%");
                filters.Rows.Add("OR", "LastName", "Like", $"%{search}%");
                filters.Rows.Add("OR", "MiddleName", "Like", $"%{search}%");
                filters.Rows.Add("OR", "UserName", "Like", $"%{search}%");
            }
            var res = _adminRepository.Get(filters, limit, startingRow);
            return res;
        }
        public AdminDetails GetAdmin(int AdminId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "UserId", "=", AdminId);
            var response = new AdminDetails();
            response = _adminRepository.Get(filters, 1, 0).Data.FirstOrDefault();
            response.CompanyList = _companyRepo.Get(filters, 100, 0).Data;
            return response;
        }

        public Response DeleteAdmin(int AdminId)
        {
            var res = _userRepository.Delete(AdminId);
            return res;
        }
    }
}
