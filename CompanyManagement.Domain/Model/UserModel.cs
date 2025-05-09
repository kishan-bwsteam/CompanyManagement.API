using Dto.Model.Common;

using System.Collections.Generic;

namespace Dto.Model
{

    //----------------------new models---------------------------------

    public class AdminModel
    {
        public ManageFranchise ManageFranchise { get; set; }
        public Credential? Credential { get; set; }
        public List<Companys> Companys { get; set; }
        public string? PassKey { get; set; }
        public string? SaltKey { get; set; }
        public string? SaltKeyIV { get; set; } 
    }
    public class EmployeeModel: EmployeeDetail
    {
        public int? ActionBy { get; set; }
        public UserBasic UserBasic { get; set; }
        public UserPassKey? UserPassKey { get; set; }
        public IEnumerable<UserAddress> UserAddress { get; set; }
        public IEnumerable<UserEducation> UserEducation { get; set; }
        public UserBankDetail UserBankDetail { get; set; }
    }
    public class EmployeeDetail
    {
        public int? EmpId { get; set; }
        public int? UserID { get; set; }
        public string? EmpCode { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOH { get; set; }
        public int DepartmentID { get; set; }
        public int EmployeeStatusID { get; set; }
        public string BloodGroup { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
        public string EmailID { get; set; }
    }

    public class UserBasic
	{
        public int UserID { get; set; }
        public string? UserGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
        public int UserTypeID { get; set; }
        public int ParentUserID { get; set; }
        public bool isActive { get; set; }

    }
	public class UserPassKey
	{
        public int PassKeyId { get; set; }
        public int UserID { get; set; }
        public string PassKey { get; set; }
        public string SaltKey { get; set; }
        public string SaltKeyIV { get; set; }
    }

	public class UserAddress
	{
        public int UserAddressId { get; set; }
        public int UserID { get; set; }
        public int AddressTypeID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
    }
	public class UserEducation
	{
        public int EducationId { get; set; }
        public int UserID { get; set; }
        public string DegreeName { get; set; }
        public string InstName { get; set; }
        public DateTime PassingYear { get; set; }
        public decimal Percentage { get; set; }

    }
    public class UserBankDetail
    {
        public int BankDetailID { get; set; }
        public int UserID { get; set; }
        public string BankName { get; set; }
        public string IFSCCode{ get; set; }
        public string AccountNo { get; set; }
    }




    //----------------------Old models---------------------------------
    public  class UserModel :Response
    {

		
		//------------------------------------------ Communication Model----------------------------------------
		public class Communication
		{
			public string AddressLine1 { get; set; }
			public string AddressLine2 { get; set; }

			public string City { get; set; }


			public int CountryId { get; set; }

			public string CountryName { get; set; }

			public int stateId { get; set; }

			public string StateName { get; set; }

			public string ZipCode { get; set; }
		}


		//------------------------------------------ CountryDropdown Model List----------------------------------------
		public class CountryDropdown : Response
		{
			public List<Communication> dropdowncountry { get; set; }

		}

		//-----------------------------------StateDropdown Model List----------------------------------------
		public class StateDropdown : Response
		{
			public List<Communication> dropdownState { get; set; }
		}

	}
}
