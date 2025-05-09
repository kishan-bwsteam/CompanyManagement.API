using System;
using System.Collections.Generic;
using System.Text;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;

namespace Dto.Model
{
   public class SupportTicketModel :Response
    {
        public int SupportTicketID { get; set; }
        public int SupportTicketDetailId { get; set; }

        public string SupportTicketGuid { get; set; }

        public int FranchiseId { get; set; }

        public string TicketSubject { get; set; }

        public int TicketStatusId { get; set; }

        public int TicketPriorityID { get; set; }

        public string TicketDetail { get; set; }

        public int CreatedBy { get; set; }

        public List<string> Files { get; set; }
    }
    public class SupportTicketAttechment
    {
        public string fileName { get; set; }
    }
    public class SupportTicketStatus
    {
        public int TicketStatusId { get; set; }
        public string StatusName { get; set; }
    }

    public class SupportTicketPriority
    {
        public int TicketPriorityID { get; set; }
        public string PriorityName { get; set; }
    }

    public class SupportStatusPriorityList 
    {
        public List<SupportTicketPriority> TicketPriorityList = new List<SupportTicketPriority>();
        public List<SupportTicketStatus> SupportStatusList = new List<SupportTicketStatus>();

    }


    public class TicketLIST
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public int TicketID { get; set; }

        public string TicketGUID { get; set; }

        public DateTime ReplyOn { get; set; }

        public string TicketSubject { get; set; }

        public int TicketStatusID { get; set; }
        public string TicketStatusName { get; set; }

        //public string ReplyBy { get; set; }
        public int TicketPriorityID { get; set; }

        public string PriorityName { get; set; }

        //public int SupportTicketDetailId { get; set; }
        //public string TicketDetail { get; set; }

         }
    public class TicketAttachmentList
    {
        public int SupportTicketAttacmentID { get; set; }
        public string AttachmentName { get; set; }
        public string SupportTicketDetailId { get; set; }

    }

    public class SupportFetchList:Response
    {
        public List<TicketLIST> FetchTicketList { get; set; }
        public List<TicketAttachmentList>? fatchTicketAttachmentList { get; set; }

    }
    

}
               
 