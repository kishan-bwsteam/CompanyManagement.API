using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Mvc;
using NReco.PdfGenerator;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.JoiningLetter
{
    [Route("api/JoiningLetter")]
    [ApiController]
    public class JoiningLetterController : Controller
    {
        public readonly IJoiningLetterService ijoiningLetterService;
        public JoiningLetterController(IJoiningLetterService _joiningLetterService)
        {
            ijoiningLetterService = _joiningLetterService;
        }

        //-------------------------------------SaveUpdate-------------------------------------------------------------



        //[HttpPost]
        //    public JoiningLetterController saveUpdate(JoiningLetterModel model)
        //    {
        //    return null;
        //    }



        //-----------------------------------------Create/Gerenate---------------------------------------------------------
        [HttpPost]
        public Response Gerenate(JoiningLetterModel model)
        {

      
    
            return ijoiningLetterService.GenerateLetter(model);
        }


    }
    }
