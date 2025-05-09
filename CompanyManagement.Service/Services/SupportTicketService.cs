using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Service.Concrete
{
    public class SupportTicketService: ISupportTicketService
    {

    

        private readonly ISupportTicketRepository _isupportTicketRepository;


        public SupportTicketService(ISupportTicketRepository supportTicketRepository)
        {
            this._isupportTicketRepository = supportTicketRepository;
        }

        public Response SaveUpdate(SupportTicketModel model )
        {

            try
            {
                DataTable dt = new DataTable();
                int i=0;
                if (model.Files!=null)
                {

                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("FileName", typeof(string));


                    if (model.Files.Count > 0)
                    {

                        foreach (var item in model.Files)
                        {
                            DataRow dr = dt.NewRow();
                            dr["ID"] = i;
                            dr["FileName"] = item;

                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                            i++;
                        }
                    }
                }
                else
                {
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("FileName", typeof(string));
                    DataRow dr = dt.NewRow();
                    dr["ID"] = 0;
                    dr["FileName"] = "Null";

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
                    return _isupportTicketRepository.SaveUpdate(model,dt);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

      /*  public SupportStatusPriorityList GetStatusPriority()
        {
            try
            {

                // return _isupportTicketRepository.GetStatusPriority();
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }*/
        public SupportFetchList GetAllTickets(string userID)
        {
            try
            {


                return _isupportTicketRepository.GetAllTickets(userID);
               
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public SupportFetchList GetSingle(string ticketID)
        {
            try
            {

                
                SupportFetchList response = new SupportFetchList();

                response = _isupportTicketRepository.GetSingle(ticketID);
                var i = 0;
                if (response.fatchTicketAttachmentList != null  )
                {
                    foreach (var item in response.fatchTicketAttachmentList)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\") + response.fatchTicketAttachmentList[i].AttachmentName;
                        if (File.Exists(path))
                        {

                            response.fatchTicketAttachmentList[i].AttachmentName = path;
                        }

                        else
                        {
                            Console.WriteLine("{0} is not a valid file or directory.", path);
                        }
                        i++;
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

      
    }
}
