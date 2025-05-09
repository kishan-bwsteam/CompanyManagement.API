using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model
{

    //------------------------------------------------------------Email Message Model----------------------------------------------------

    public class EmailMassagesModel :Response
    {
        public int EmailMessageID { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string TempleteName { get; set; }
        public string Body { get; set; }
        public string MailSubject { get; set; }
        public int IsDeleted { get; set; }
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedOn{ get; set; }
        public int CreatedOn { get; set; }

     
    }


    //----------------------------------------------------- Email Message Model List-------------------------------------------------------



    public class EmailMessagesViewModel : Response
    {
        public List<EmailMassagesModel> EmailMassagesModelList { get; set; }
    }


    //---------------------------------------------------Single Model List------------------------------------------------------


    public class SingleEmailMassagesViewModel : Response
    {
        public EmailMassagesModel SingleModelList { get; set; }
    }
}

