using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/Notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        private readonly INotesService _inotesService;
        private readonly IConfiguration _config;

        public NotesController(INotesService _notesService, IConfiguration config)
        {
            _inotesService = _notesService;
            _config = config;
        }



        //--------------------------------------------save update Notes-------------------------------
        [HttpPost]
       
        public Response SaveUpdate(NotesModel model)
        {
            try
            {
                return _inotesService.SaveUpdate(model);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }



        //----------------------------- Get All Notes by NotesModelView------------------

        [HttpGet]
       
        public NotesModelView Get()
        {
            try
            {
                return _inotesService.Get();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        //----------------------------------------- Delete Notes by NotesID-------------------------------- 


        [HttpDelete("{NotesID}")]
       
        public Response Delete(int notesID)
        {
            try
            {
                return _inotesService.Delete(notesID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
