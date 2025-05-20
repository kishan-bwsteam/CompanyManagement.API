using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Dto.Responses;
using Microsoft.Data.SqlClient;
using Microsoft.Exchange.WebServices.Data;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Service.Concrete
{
    public class EmpBankService : IEmpBankService
    {
        EncryptHelperModel obj = new EncryptHelperModel();

        private IEmpBankRepository _empBankRepository;
        public EmpBankService(IEmpBankRepository empBankRepository)
        {
            _empBankRepository = empBankRepository;
        }

        // -----------------------------Save And Update Bank Details------------------------ 
        public Response SaveUpdate(UserBankDetail model, int actionBy)
        {
            try
            {
                return _empBankRepository.SaveOrUpdate(model, actionBy);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

        //----------------------------Get all Bank Details by BankViewModels (List)-------------------

        public BankViewModels GetAll()
        {
            try
            {
                return _empBankRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserBankDetail GetByUserId(int UserId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "UserId", "=", UserId.ToString());

            var result = _empBankRepository.Get(filters, 1, 0);

            return result.FirstOrDefault();
        }
    }
}
