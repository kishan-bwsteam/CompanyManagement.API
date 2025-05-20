
using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Data.Datas.Concrete;
using CompanyManagement.Domain.Model;
using CompanyManagement.Domain.Model.Common;
using CompanyManagement.Service.Helper;
using CompanyManagement.Services.Service.Abstract;

using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace CompanyManagement.Services.Service.Concrete
{
    public class UserService : IUserService
    {
        EncryptHelperModel obj = new EncryptHelperModel();
         
        private readonly IUserRepository _iuserRepository;

        public UserService(IUserRepository _userRepository, IDatabaseContext _db_context) 
        {
            _iuserRepository = _userRepository;

        }


        //--------------------------------------------------------- Save Update user-------------------------------------
        public Response SaveUpdate(UserBasic model, int actionBy)
        {
            try
            {
                return _iuserRepository.SaveOrUpdate(model, actionBy);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }



        //--------------------------------------- Delete User Details-------------------------------------------------------
        public Response Delete(int userId)

        {
            try
            {
                return _iuserRepository.Delete(userId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public Response Upload(int profileid, string path, string msg)

        {
            return _iuserRepository.Upload(profileid, path, msg);

        }



        public Response DeleteCompany(int companyID)
        {
            try
            {
                return _iuserRepository.DeleteCompany(companyID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public UserBasic GetByUserId(int UserId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "UserId", "=", UserId.ToString());

            var result = _iuserRepository.Get(filters, 1, 0);

            return result.Data.FirstOrDefault();
        }


        public PaginatedResult<UserBasic> GetByUserTypeId(int UserTypeId,int limit = 10, int startingRow = 0)

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

            filters.Rows.Add("AND", "UserTypeId", "=", UserTypeId.ToString());

            var result = _iuserRepository.Get(filters, limit, startingRow);

            return result;
        }
    }
}
