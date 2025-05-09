using Dto.Model.Common;
using System;
using System.Collections.Generic;


namespace Dto.Model
{

    //----------------------------Create User Admin model-----------------------------------

   public class CreateUserAdminModel :Response
    {
        public int UserID{ get; set; }
        public string UserGuid { get; set; }
        public int LoginUserID { get; set; }
        public int UserTypeID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public long PhoneNo { get; set; }
        public int CompanyID { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public DateTime DOB { get; set; }
        public int PassKeyId { get; set; }
        public string PassKey { get; set; }
        public string SaltKey { get; set; }
        public string SaltKeyIV { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int State { get; set; }
        
    }

    //----------------------Create User Admin model List---------------------------
       public class createViewUserAdminModel : Response 
    {
        public List<CreateUserAdminModel> CreateUserAllModelList { get; set; }
    }

    //----------------------Create User Admin Single model List---------------------------

    public class singlecreateViewUserAdminModel : Response
    {
        public List<CreateUserAdminModel> CreateUserSingleList { get; set; }
    }
}
