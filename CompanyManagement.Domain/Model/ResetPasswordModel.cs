using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{

    //----------------------------------------Rest Password Model------------------------------------------------------------

  public   class ResetPasswordModel :Response
    {
       public int UserTypeID { get; set; }
       public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string EmailPdf { get; set; }
        public string UserGuid { get; set; }
        public string newPassword { get; set; } 
        public string confirmNewPassword { get; set; }

    }

    //----------------------------------------Rest Password Single Model (List)------------------------------------------------------------
    public class GetSingleData : Response
    {   public ResetPasswordModel ModelReset { get; set; }
    }


    //------------------------------------------------Change Password Model-------------------------------------------------------------

    public class ChangePasswordModel : Response
    {
        public string UserGuid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PassKey { get; set; }
        public string SaltKey { get; set; }
        public string SaltKeyIV { get; set; }
    }
}
