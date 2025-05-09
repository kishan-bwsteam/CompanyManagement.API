
using System;
using System.Collections.Generic;


namespace Dto.Model
{



    //---------------------------------------------------- Multi form Model ---------------------------------------------
  public  class MultiformModel
    {
        public ManageFranchise  ManageFranchise{ get; set; }
        public Credential? Credential { get; set; }
        public List<Companys> Companys { get; set; }
        public string? PassKey { get; set; }
        public string? SaltKey { get; set; }
        public string? SaltKeyIV { get; set; }
        


    }


    //-------------------------------------------------manage Franchise -----------------------------------------------------
    public class ManageFranchise
    {
        public int userid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int Country { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int ZipCode { get; set; }
    }

    //------------------------------------------------------- user Credetial model-------------------------------------------------------

    public class Credential
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
 
    }


    //-------------------------------------------------- Companies model---------------------------------------------------------


    public class Companys
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CAddress2 { get; set; }
        public string CAddress3 { get; set; }
        public string CCity { get; set; }
        public int CState { get; set; }
        public int CCountry { get; set; }
        public int CZipCode { get; set; }
        public string GSTIN { get; set; }
        public string CIN { get; set; }

        public string? CompanyGuid { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }






    }
    
}
