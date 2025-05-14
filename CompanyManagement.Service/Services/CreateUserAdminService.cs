using Authentication.DataManager.Helper;
using AutoMapper;
using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Service.Concrete
{
    public class CreateUserAdminService : ICreateUserAdminService
    {
        EncryptHelperObj obj = new EncryptHelperObj();
        private readonly ICreateUserAdminRepository _icreateUserAdminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmpAddressRepository _addrRepository;
        private readonly IMapper _mapper;
        public CreateUserAdminService(ICreateUserAdminRepository _createUserAdminRepository, IUserRepository userRepository, IMapper mapper, IEmpAddressRepository empAddressRepository)

        {
            _userRepository = userRepository;
            _icreateUserAdminRepository = _createUserAdminRepository;
            _mapper = mapper;
            _addrRepository = empAddressRepository;
        }



        //----------------------------Save Update Admin User-------------------------------------



        public Response SaveUpdate(AdminUser model, int ActionBy)
        {
            try
            {
                model.userPassKey = new UserPassKey();
                obj = EncryptHelper.Get_EncryptedPassword(obj, "123456");
                model.userPassKey.PassKey = obj.Value;
                model.userPassKey.SaltKey = obj.SaltKey;
                model.userPassKey.SaltKeyIV = obj.SaltKeyIV;
                return _icreateUserAdminRepository.SaveUpdate(model, ActionBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //------------------------- Admin User by createViewUserAdminModel (list)------------------------ 
        public PaginatedResult<AdminUser> GetAdmins(int adminId, int limit, int startingRow)
        {
            if (limit == 0)
            {
                limit = 10;
            }
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "ParentUserID", "=", adminId.ToString());
            filters.Rows.Add("AND", "UserTypeID", "=", "3");
            var users = _userRepository.Get(filters, limit, startingRow);

            PaginatedResult<AdminUser> res = new PaginatedResult<AdminUser>();
            res.Data = _mapper.Map<IEnumerable<AdminUser>>(users.Data);
            res.limit = limit;
            res.startingRow = startingRow;
            res.TotalRecords = users.TotalRecords;
            return res;
        }
        public AdminUser GetAdmin(int adminId,int userId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "ParentUserID", "=", adminId.ToString());
            filters.Rows.Add("AND", "UserID", "=", userId.ToString());

            var res = _icreateUserAdminRepository.Get(filters, 1, 0).Data.FirstOrDefault();
            if (res == null) return null;
            filters.Clear();
            filters.Rows.Add("AND", "UserID", "=", res.UserID);

            res.Address = _addrRepository.Get(filters, 1, 0).FirstOrDefault();
            return res;
        }

        public createViewUserAdminModel GetAll()
        {
            try
            {
                return _icreateUserAdminRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //-------------------------------Single user Get by userID--------------------------------


        public singlecreateViewUserAdminModel GetSingle(int userID)
        {
            try
            {
                return _icreateUserAdminRepository.GetSingle(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //--------------------------------Delete User by UserID-------------------------------------------



        public Response Delete(int userID)
        {
            try
            {
                return _icreateUserAdminRepository.Delete(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
