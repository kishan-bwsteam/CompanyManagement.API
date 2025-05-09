
using System.Collections.Generic;

namespace Dto.Responses
{

		public class LoginResponse 
		{
			public string UserName { get; set; }
			public int UserID { get; set; }
            public int UserTypeID { get; set; }
            public string PassKey { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SaltKey { get; set; }
			public string SaltKeyIV { get; set; }
			public string FullName { get; set; }
			public string UserTypeName { get; set; }
	
		    public int Status { get; set; }
		    public string Message { get; set; }

		    public string Password { get; set; }
    }
    //public class loginviewresponse
    //{
    //    public List<LoginResponse> loginResponses { get; set; }
    //    public int status { get; set; }
    //    public string Message { get; set; }

    //}
}

