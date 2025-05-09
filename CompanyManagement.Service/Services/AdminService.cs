using Authentication.DataManager.Helper;
using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Data.Datas.Concrete;
using CompanyManagement.Domain.Model;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Service.Interface;
using CompanyManagement.Services.Service.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Service.Services
{
    public class AdminService:IAdminService
    {
        EncryptHelperObj obj = new EncryptHelperObj();

        private readonly IAdminRepository _adminRepository;
        private readonly IUserService _userService;
        public AdminService(IAdminRepository adminRepository, IUserService userService)
        {
            _adminRepository = adminRepository;
            _userService = userService;
        }


        //--------------------------------------------------------- Save Update user-------------------------------------

        public Response SaveUpdate(MultiformModel model)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CompanyID", typeof(int));
                dt.Columns.Add("CompanyGuid", typeof(string));
                dt.Columns.Add("CompanyName", typeof(string));
                dt.Columns.Add("IsDeleted", typeof(bool));
                dt.Columns.Add("CreatedOn", typeof(DateTime));
                dt.Columns.Add("CreatedBy", typeof(int));
                dt.Columns.Add("UpdatedOn", typeof(DateTime));
                dt.Columns.Add("UpdatedBy", typeof(int));
                dt.Columns.Add("GSTIN", typeof(string));
                dt.Columns.Add("CIN", typeof(string));
                dt.Columns.Add("AddressLine1", typeof(string));
                dt.Columns.Add("AddressLine2", typeof(string));
                dt.Columns.Add("City", typeof(string));
                dt.Columns.Add("StateId", typeof(int));
                dt.Columns.Add("ZipCode", typeof(int));
                dt.Columns.Add("CountryID", typeof(int));


                if (model.Companys.Count > 0)
                {

                    foreach (var item in model.Companys)
                    {
                        DataRow dr = dt.NewRow();
                        dr["CompanyID"] = item.CompanyID;
                        dr["CompanyGuid"] = item.CompanyGuid ?? (object)DBNull.Value;
                        dr["CompanyName"] = item.CompanyName;
                        //dr["FranchiseID"] = item.FranchiseID ?? (object)DBNull.Value;
                        dr["IsDeleted"] = item.IsDeleted;
                        dr["CreatedOn"] = DateTime.Now;
                        dr["CreatedBy"] = item.CreatedBy;
                        dr["UpdatedOn"] = DateTime.Now;
                        dr["UpdatedBy"] = item.CreatedBy;
                        dr["GSTIN"] = item.GSTIN;
                        dr["CIN"] = item.CIN;
                        dr["AddressLine1"] = item.CAddress2;
                        dr["AddressLine2"] = item.CAddress3;
                        dr["City"] = item.CCity;
                        dr["StateId"] = item.CState;
                        dr["ZipCode"] = item.CZipCode;
                        dr["CountryID"] = item.CCountry;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }
                // Giving statically for temporary
                model.Credential = new Credential()
                {
                    UserName = "",
                    password = "123456",
                    confirmPassword = "123456",
                };
                //return _userRepository.saveUpTransaction(dt);
                obj = EncryptHelper.Get_EncryptedPassword(obj, model.Credential.password);
                model.PassKey = obj.Value;
                model.SaltKey = obj.SaltKey;
                model.SaltKeyIV = obj.SaltKeyIV;


                return _adminRepository.SaveUpdate(model, dt);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public PaginatedResult<UserBasic> GetAdminList( int limit = 10, int startingRow = 0)
        {
            var res = _userService.GetByUserTypeId(2,limit,startingRow);
            return res;
        }
    }
}
