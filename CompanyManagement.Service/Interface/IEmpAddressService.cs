using Dto.Model;
using Dto.Model.Common;
using System.Collections;
using System.Collections.Generic;


namespace Service.Abstract
{
    public interface IEmpAddressService
    {
        //------------------------------- Save Update Address ---------------------------
        Response SaveUpdate(UserAddress model, int actionBy);


        //----------------------- Get All Address by AddressViewModel------------------------------
        AddressViewModel GetAddress();

        //----------------------------Get Single Address by UserAddressID-------------------------------
        singleAddressViewModel GetSingle(int userAddressId);



        //----------------------------Delete Address by UserAddressID-------------------------------
        Response Delete(int userAddressID);


        ////----------------------- Get All Country by CountryViewModel------------------------------
        CountryViewModel GetAll();

        ////----------------------- Get All State by StateViewModel------------------------------
        StateViewModel GetAllState();
        IEnumerable<UserAddress> GetByUserId(int UserId);
    }
}
