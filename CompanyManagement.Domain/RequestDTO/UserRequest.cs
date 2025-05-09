using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Request
{
    public class UserRequest
	{


		public int UserID { get; set; }
		public int LoginUserID { get; set; }
		//public string UserGuid { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		//public DateTime CreatedOn { get; set; }
		public string CountryName { get; set; }
		public string StateName { get; set; }

		public int imageID { get; set; }
		public string image { get; set; }
		public int StateId { get; set; }
		public int CountryID { get; set; }
		public int PrimaryPhoneNo { get; set; }
		public int SecondaryPhoneNo { get; set; }

		public int Primaryphonenumber { get; set; }

		public int Secondaryphonenumber { get; set; }
		public int ProfileImgID { get; set; }
		public string ProfileImg { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }

		public string UserName { get; set; }
		//public string TypeName { get; set; }
		//public int UserTypeID { get; set; }

		//public bool IsActive { get; set; }
		//public bool IsDeleted { get; set; }
		//public DateTime UpdatedOn { get; set; }


		public int UpdatedBy { get; set; }

		public int CreatedBy { get; set; }
		public int AddressTypeID { get; set; }
		//public int PassKeyId { get; set; }
		//public string PassKey { get; set; }

		//public string SaltKey { get; set; }

		//public string SaltKeyIV { get; set; }
		//public int UserEmailId { get; set; }

		//public string EmailID { get; set; }

		//public bool IsPrimary { get; set; }

		//public int UserAddressId { get; set; }

		public string AddressLine1 { get; set; }

		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }

		public string ZipCode { get; set; }
		public string Country { get; set; }
		public List<CompanyModel> Company { get; set; }

		//public int CompanyID { get; set; }


		public string CompanyName { get; set; }
		public string CAddressLine1 { get; set; }

		public string CAddressLine2 { get; set; }
		public string CCity { get; set; }
		public string CState { get; set; }

		public string CZipCode { get; set; }
		public string CCountry { get; set; }

		public string GSTIN { get; set; }
		public string CIN { get; set; }

		public string BgImage { get; set; }
		public string ProfileImage { get; set; }

		public int Phonenumber { get; set; }
		public string EmailAddress { get; set; }
		public DateTime DOB { get; set; }
        //public string SaltKey { get; set; }
        //public string SaltKeyIV { get; set; }
        //public object PassKey { get; set; }
    }
	
	


	
}
