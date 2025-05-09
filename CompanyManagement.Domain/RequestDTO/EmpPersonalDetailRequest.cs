using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Request
{
 public   class EmpPersonalDetailRequest
    {

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public int Primaryphonenumber { get; set; }
		public int Secondaryphonenumber { get; set; }

	}
}
