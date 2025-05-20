using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using NReco.PdfGenerator;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


namespace Service.Concrete
{
   public  class WagesService :IWagesService
    {

        EncryptHelperModel obj = new EncryptHelperModel();

        private readonly IWagesRepository _iWagesRepository;

        public WagesService(IWagesRepository _wagesRepository)
        {
            _iWagesRepository = _wagesRepository;
        }

        //-----------------------------------Save Update Wages------------------------------
        public Response SaveUpdate(WagesModel model)
        {
            try
            {
                return _iWagesRepository.SaveUpdate(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-----------------------------------Get All Wages------------------------------

        public WagesModelView Get()
        {
            try
            {
                return _iWagesRepository.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-----------------------------------Delete Wages by wagesID----------------------------------

        public Response Delete(int wagesID)
        {
            try
            {
                return _iWagesRepository.Delete(wagesID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            public MultiWagesModelView GetStructureSalary(string Box)
            {
                try
                {
                    return _iWagesRepository.GetStructureSalary(Box);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }




    //    public MultiWagesModelView GetUserStructure(int UserID)
    //    {
    //        MultiWagesModelView response = new MultiWagesModelView();
    //        Response message = new Response();

    //        response = _iWagesRepository.GetUserStructure(UserID);
    //        //string template = response.multiStructureList.Body;
    //        var htmlToPdf = new HtmlToPdfConverter();

    //  //      string htmlContent = "<html><body><h1>Salary Structure </h1><br> <p>" + template + "</p></body></html>";

    //        string outputPath = "C:/Users/BWS-Developer/Downloads/" + UserID + "_JoningLetter.pdf";

    //        htmlToPdf.GeneratePdf( null, outputPath);
    //        message.Message = outputPath;
    //        message.Message = message.Message.Replace("/", "..");
    //        return (MultiWagesModelView)message;
    //    }



    }






}
