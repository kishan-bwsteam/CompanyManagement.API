using CompanyManagement.Domain.Model;
using Dapper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;


namespace Service.Concrete
{
  public  class CompanyService : ICompanyService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly ICompanyRepository _companyRepository;


        public CompanyService(ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
        }

        //---------------------------------Get All Company By UserID & CompanyID--------------------------------

        //public DropdownListModel Get(int userId, int companyID)
        //{
        //    try
        //    {
        //        return _companyRepository.Get(userId,companyID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        ////---------------------------------Get All Company By UserID--------------------------------

        //public DropdownListModel GetAll(int userId)
        //{
        //    try
        //    {
        //        return _companyRepository.GetAll(userId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public PaginatedResult<CompanyModel> Get(int UserId,int limit = 10, int startingRow = 0)
        {
            if (limit == 0)
            {
                limit = 10;
            }
            DataTable filters = null;
            if (UserId != null)
            {
                filters = new DataTable("filter_type");
                filters.Columns.Add("operator", typeof(string));
                filters.Columns.Add("col", typeof(string));
                filters.Columns.Add("condition", typeof(string));
                filters.Columns.Add("val", typeof(string));

                filters.Rows.Add("AND", "UserID", "=", UserId);
            }
            var result = _companyRepository.Get(filters,limit,startingRow);
            return result;
        }

        // ✅ Get a single company by ID
        public CompanyModel GetSingle(int companyId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "CompanyID", "=", companyId.ToString());

            var result =  _companyRepository.Get(filters, 1, 0);

            return result.Data.FirstOrDefault();
        }

        //---------------------------- Save Update Company -----------------------------
        public Response SaveUpdate(CompanyModel model)
        {
            try
            {
                return _companyRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //--------------------- Delete Company by Company Id----------------------
        public Response Delete(int companyID)
        {
            try
            {
                return _companyRepository.Delete(companyID);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }
    }
}