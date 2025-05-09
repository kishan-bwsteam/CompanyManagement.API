
using CompanyManagement.Domain.RequestDTO;
using Dto.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System;


namespace CompanyManagement.Controllers.Common_Controller
{
    [Route("api/Common/")]
    [ApiController]
    public class CommonController : ControllerBase
    {


        private readonly ICommonService _icommonService;
        private readonly IConfiguration _iconfig;

        public CommonController(ICommonService _commonService, IConfiguration _config)
        {
            _icommonService = _commonService;
            _iconfig = _config;
        }



        //-------------------------------------------Get Country Dropdown-------------------------------------------------------


        [HttpGet("Country")]

        public CountryDropdown GetCountry()
        {
            try
            {
                return _icommonService.GetCountry();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //------------------------------------------- Get State Dropdown -------------------------------------------------------
        [HttpGet("State")]
       
        public StateDropdown GetState()
        {
            try
            {
                return _icommonService.GetState();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("uploadfile")]
        public async Task<IActionResult> Upload([FromForm] FileUploadDto model)
        {
            var file = model.File;

            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"{Request.Scheme}://{Request.Host}/upload/{fileName}";

            return Ok(new
            {
                FileName = fileName,
                Url = fileUrl,
                Status = "Uploaded successfully"
            });
        }

    }
}
