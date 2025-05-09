using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using NReco.PdfGenerator;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concrete
{
   public class JoiningLetterService :IJoiningLetterService
    {

        private readonly IJoiningLetterRepository _iletterRepository;


        public JoiningLetterService(IJoiningLetterRepository _letterRepository)
        {
            _iletterRepository = _letterRepository;
        }
        public Response GenerateLetter(JoiningLetterModel model)
        {
            SingleLetterViewModel response = new SingleLetterViewModel();
            Response message = new Response();

            response = _iletterRepository.GetSingleLetterByTemplate("somvir", model.CompanyID);

            string template = response.SingleModelList.Body;

            template = template.Replace("[Name]", model.FirstName + " " + model.LastName);
            template = template.Replace("[MM/DD/YYYY]", DateTime.Today.ToString());
            template = template.Replace("[company name]", "BWS");
            template = template.Replace("[position]", model.Position);
            template = template.Replace("[sal]", model.Salary.ToString());
            var htmlToPdf = new HtmlToPdfConverter();

            string htmlContent = "<html><body><h1>Joning Letter</h1><br> <p>"+template+"</p></body></html>";
           
            string outputPath = "C:/Users/BWS-Developer/Downloads/" + model.FirstName + "_JoningLetter.pdf";

            htmlToPdf.GeneratePdf(htmlContent, null, outputPath);
            message.Message = outputPath;
            message.Message = message.Message.Replace("/", "..");
            return message;
        }
    }
}
