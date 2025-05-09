using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Responses
{
   public class RoleResponse
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }
        public int RoleLevel { get; set; }
        public string Abberivation { get; set; }



        public int userID { get; set; }
        public int companyID { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
