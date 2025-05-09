using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.SupportTicket
{
    [Route("api/SupportTicketController")]
    [ApiController]
    public class SupportTicketController : Controller
    { 
        private readonly ISupportTicketService _isupportTicketService;
    public SupportTicketController(ISupportTicketService supportTicketService)
    {
            _isupportTicketService = supportTicketService;
       
    }

        //--------------------------------Save Update Tickets-------------------
         [HttpPost]
        public Response SaveUpdate(SupportTicketModel model)

        {
            try
            {
                return _isupportTicketService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //----------------------------- Get single------------------------ 
        [HttpGet("GetSingle/{ticketID}")]

        public SupportFetchList GetSingle(string ticketID)
        {
            try
            {
                return _isupportTicketService.GetSingle(ticketID);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //----------------------------- Get All Tickets------------------------ 
        [HttpGet("{data}")]

        public SupportFetchList GetAll(string data)
        {
            try
            {

                return _isupportTicketService.GetAllTickets(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //------------------------------------------------------------------------------FileUpload
        [HttpPost("FileUpload")]

        public async Task<IActionResult> FileUpload(List<IFormFile> uploadFiles)
        {
            List<string> _return_list = new List<string>();
           
            if (uploadFiles.Count > 0)
            {
                for (int i = 0; i < uploadFiles.Count; i++)
                {
                    var postedFile = uploadFiles[i].FileName;
                    string FileName = uploadFiles[i].FileName;

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", uploadFiles[i].FileName);
                  
                   
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFiles[i].CopyToAsync(stream);
                    }

                    _return_list.Add(FileName);
                }
            }
            return Ok(_return_list);
        }

       
       

    }
}
