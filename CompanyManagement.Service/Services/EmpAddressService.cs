using Authentication.DataManager.Helper;
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

namespace Service.Concrete
{
    public class EmpAddressService : IEmpAddressService
    {
        EncryptHelperObj obj = new EncryptHelperObj();
        private readonly IEmpAddressRepository _iempAddressRepository;

        public EmpAddressService(IEmpAddressRepository empAddressRepository)
        {
            _iempAddressRepository = empAddressRepository;
        }



        //------------------------------- Save Update Address ---------------------------


        public Response SaveUpdate(UserAddress model, int actionBy)
        {
            try
            {
                return _iempAddressRepository.SaveOrUpdate(model, actionBy);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }



        //----------------------- Get All Address by AddressViewModel------------------------------

        public AddressViewModel GetAddress()

        {
            try
            {
                return _iempAddressRepository.GetAddress();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        //----------------------------Get Single Address by UserAddressID-------------------------------

        public singleAddressViewModel GetSingle(int userAddressId)

        {
            try
            {
                return _iempAddressRepository.GetSingle(userAddressId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------Delete Address by UserAddressID-------------------------------


        public Response Delete(int userAddressID)

        {
            try
            {
                return _iempAddressRepository.Delete(userAddressID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        ////----------------------- Get All Country by CountryViewModel------------------------------
        public CountryViewModel GetAll()
        {
            try
            {
                return _iempAddressRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        ////----------------------- Get All State by StateViewModel------------------------------

        public StateViewModel GetAllState()

        {
            try
            {
                return _iempAddressRepository.GetAllState();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<UserAddress> GetByUserId(int UserId)
        {
            DataTable filters = new DataTable("filter_type");
            filters.Columns.Add("operator", typeof(string));
            filters.Columns.Add("col", typeof(string));
            filters.Columns.Add("condition", typeof(string));
            filters.Columns.Add("val", typeof(string));

            filters.Rows.Add("AND", "UserId", "=", UserId.ToString());

            var result = _iempAddressRepository.Get(filters, 10, 0);

            return result;
        }
    }
}


