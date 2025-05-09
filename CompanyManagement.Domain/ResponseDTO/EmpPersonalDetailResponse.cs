using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Responses
{
 public  class EmpPersonalDetailResponse
    {
		public int UserID { get; set; }
		public int LoginUserID { get; set; }
		public string UserGuid { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public DateTime CreatedOn { get; set; }
		public string CountryName { get; set; }
		public string StateName { get; set; }
		public string image { get; set; }
		public int StateId { get; set; }
		public int Primaryphonenumber { get; set; }
		public int Secondaryphonenumber { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string BgImage { get; set; }
		public string ProfileImage { get; set; }
		public int Phonenumber { get; set; }
		public string EmailAddress { get; set; }
		public DateTime DOB { get; set; }
	}
}
