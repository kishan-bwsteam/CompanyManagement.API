using Dto.Model.Common;
using System.Collections.Generic;


namespace Dto.Model
{

    //------------------------------ Address Model ------------------------------
    public class AddressModel : Response
    {
        public int UserAddressId { get; set; }
        public int UserID { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
     
        public int CountryId { get; set; }
        public int StateId { get; set; }
     
       public int AddressTypeID { get; set; }
    }


    //------------------------------ Address Model  List-------------------
    public class AddressViewModel : Response
    {
        public List<AddressModel> AddressModelList { get; set; }
    }

    //-------------------------------- Single Address Model List------
    public class singleAddressViewModel : Response
    {
        public AddressModel SingleModelList { get; set; }
    }


    //-----------------------Country Dropdown Model---------------------

    public class CountryDropdownModel : Response
    {
        public int countryId { get; set; }
        public string CountryName { get; set; }
    }

    //-----------------------Country Dropdown Model List---------------------
    public class CountryViewModel : Response
    {
        public List<CountryDropdownModel> CountryList { get; set; }
    }


    //-------------------------State dropdown Model------------------------
    public class StateDropdownModel : Response
    {
        public int stateId { get; set; }
        public string StateName { get; set; }
    }
    //-------------------------State dropdown Model List------------------------
    public class StateViewModel : Response
    {
        public List<StateDropdownModel> StateList { get; set; }
    }
}
