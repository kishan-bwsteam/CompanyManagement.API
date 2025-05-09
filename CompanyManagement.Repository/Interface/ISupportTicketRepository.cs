using Dto.Model;
using Dto.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datas.Abstract
{
   public interface ISupportTicketRepository
    {
        Response SaveUpdate(SupportTicketModel model, DataTable dt);
        //SupportStatusPriorityList GetStatusPriority();
        SupportFetchList GetAllTickets(string userID);
        SupportFetchList GetSingle(string ticketID);

       
    }
}
