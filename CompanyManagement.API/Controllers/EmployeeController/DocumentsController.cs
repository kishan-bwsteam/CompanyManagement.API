using Dto.Model;
using Dto.Model.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Service.Abstract;
using System;

using System.IO;

using System.Linq;
using System.Threading.Tasks;

using System.Net;

namespace CompanyManagement.Controllers.EmployeeController
{
    [Route("api/Documents/")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService _idocumentsService;
        private readonly IConfiguration _config;
        private IWebHostEnvironment _hostingEnvironment;
        public static string uplodedPath{get;set;}

        public DocumentsController(IDocumentsService _documentsService, IConfiguration config, IWebHostEnvironment environment)
        {
            _idocumentsService = _documentsService;
            _config = config;
            _hostingEnvironment = environment;
        }


        //-------------------------------------------- Save Update Document ----------------------------------------------------

        [HttpPost]
       // [Route("SaveUpdate/")]
        public Response SaveUpdate(DocumentsModel model)
        
        {
            try
            {
                model.FileGroup = uplodedPath;
                return _idocumentsService.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //-------------------------------------------- Get All Document by DocumentViewModel(List)-----------------------------------------------------------------

        [HttpGet("{UserID}")]
       // [Route("GetAllDocument/")]
        public DocumentViewModel GetAll(int userID)
        {
            try
            {
                return _idocumentsService.GetAll(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //------------------------------------------------ Delete Document by Document ID--------------------------------------------------------------------------

        [HttpDelete]
    
        public Response Delete(int documentsID)
        {
            try
            {
                return _idocumentsService.Delete(documentsID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------------------------------- Download Document by Document ID-------------------------------------------------------------------------


      //  [HttpGet]
      ////  [Route("DownloadDocument/{DocumentsID}")]
      //  public string Download(int documentsID)

      //         {
      //      DocumentViewModel new1 = _idocumentsService.GetAll();
      //      var list = new1.DocumentModelList.Where( x=> x.DocumentsID == documentsID).ToList();
      //      var path = list[0].FileGroup.ToString();
      //      var Document = path.Split("Resources\\");
      //      Document[0] = Document[0] + "Resources";
          
      //      try
      //      {
               

      //          using (var client = new WebClient())
      //          {
      //              client.DownloadFile(Document[0], Document[1]);
      //          }
      //          return ("file has uploded");
      //      }
      //      catch (Exception ex)
      //      {
                
      //          throw ex;
      //          return ("file has uploded");
      //      }
      //  }


        //----------------------------------------------------------- Upload File  -----------------------------------------------------

        [HttpPost]
        [Route("uploadFiles/")]
        public async Task<IActionResult> UploadFile(IFormFile uploadFiles)
        {
            if (uploadFiles == null || uploadFiles.Length == 0)
                return BadRequest("Please select a file to upload.");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", uploadFiles.FileName);
            uplodedPath = uploadFiles.FileName;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await uploadFiles.CopyToAsync(stream);
            }

            return Ok("file has uploded");
        }

 



         
    }


   
    
}
