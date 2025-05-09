using Dto.Model;
using Dto.Model.Common;
using System.Data;

namespace Datas.Abstract
{
 public interface IEmpAddressRepository
    {

        //------------------------------- Save Update Address ---------------------------
        Response SaveOrUpdate(UserAddress education, int actionBy);


        //----------------------- Get All Address by AddressViewModel------------------------------
        AddressViewModel GetAddress();

        //----------------------------Get Single Address by UserAddressID-------------------------------
        singleAddressViewModel GetSingle(int userAddressId);

        IEnumerable<UserAddress> Get(DataTable filters, int limit, int startingRow);
        //----------------------------Delete Address by UserAddressID-------------------------------
        Response Delete(int userAddressID);


        ////----------------------- Get All Country by CountryViewModel------------------------------
        CountryViewModel GetAll();

        ////----------------------- Get All State by StateViewModel------------------------------
        StateViewModel GetAllState();
    }
}
