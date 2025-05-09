using Dto.Model.Common;
using System;
using System.Collections.Generic;


namespace Dto.Model
{

    //----------------------------------Company Model -----------------------------------------
    public class CompanyModel 
    {

        public int CompanyId { get; set; }
        public int LoginUserID { get; set; }
        public int UserID { get; set; }
        public string CompanyGuid { get; set; }
        public int? FranchiseID { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        //public string Address2 { get; set; }
        //public string Address3 { get; set; }
        //public int State1 { get; set; }
        //public int Country1 { get; set; }

        public string City { get; set; }
        public int StateId { get; set; }
        public string? State { get; set; }
        public int CountryId { get; set; }
        public string? Country { get; set; }
        public int ZipCode { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }
        //public int CreatedBy { get; set; }
        //public int UpdatedBy { get; set; }
        public string GSTIN { get; set; }
        public string CIN { get; set; }
        //public string SaltKey { get; set; }
        //public string SaltKeyIV { get; set; }
        //public string PassKey { get; set; }
        //public string Password { get; set; }
        //public bool IsDeleted { get; set; }
        //public int Status { get; set; }
        //public string Message { get; set; }
    }

    //-------------------------------------------Company Model List--------------------------------
    public class companyViewModels 
    {
        public List<CompanyModel> companyViewModel { get; set; }
    }


    //---------------------------------------- Single Model List------------------------------
    public class singleCompanyResponseModel
    {
        public CompanyModel SCDModel { get; set; }
    }

    //-------------------------------------Dropdown Company List--------------------------

    public class DropdownCompanyListModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Adrress { get; set; }
        public string State { get; set; }
        public string Countery { get; set; }
        public List<DropdownCompanyListModel> DropdownListCompany { get; set; }
    }


    //----------------------------Bind With Status & Message With Company List---------------------
    public class DropdownListModel
    {
        public List<DropdownCompanyListModel> Dropdowncompanylist { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }


    //--------------------------------User Comapny List Model-------------------------

    public class UserCompanyListModel : Response
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

    //-------------------------------User Company Model List-------------------------- 
    public class DropdownListModels : Response
    {
        public List<UserCompanyListModel> companylist { get; set; }
    }

}

