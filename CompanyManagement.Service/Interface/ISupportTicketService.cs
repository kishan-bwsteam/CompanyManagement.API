using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
   public interface ISupportTicketService
    {
        Response SaveUpdate(SupportTicketModel model);
        //SupportStatusPriorityList GetStatusPriority();
        SupportFetchList GetAllTickets(string userID);

        SupportFetchList GetSingle(string ticketID);

        
    }
}
