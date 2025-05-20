using CompanyManagement.Domain.Model;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;


namespace Service.Concrete
{
    public class DocumentsService : IDocumentsService
    {
        EncryptHelperModel obj = new EncryptHelperModel();


        private readonly IDocumentsRepository _idocumentRepository;

        public DocumentsService(IDocumentsRepository _documentRepository)
        {
            _idocumentRepository = _documentRepository;
        }


        //------------------------------------------------- Save Update Documents------------------------

        public Response SaveUpdate(DocumentsModel model)
        {
            try
            {

                return _idocumentRepository.SaveUpdate(model);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DocumentViewModel GetAllDocument(int userID)
        //{
        //    DocumentViewModel response = new DocumentViewModel();
        //    try
        //    {

        //        response = _IDocumentRepository.GetAllDocument(userID);
        //        var i = 0;
        //        foreach(var item in response.DocumentModelList)
        //        {
        //            var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources//") + response.DocumentModelList[i].FileGroup;
        //            if (File.Exists(path))
        //            {

        //                response.DocumentModelList[i].FileGroup=path;
        //            }

        //            else
        //            {
        //                Console.WriteLine("{0} is not a valid file or directory.", path);
        //            }
        //            i++;
        //        }



        //        return response;


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        //---------------------------------------------- Get All Document by DocumentViewModel--------------------------------

        //public DocumentViewModel GetAll( int userID)
        //{
        //    try
        //    {
        //        return _idocumentRepository.GetAll(userID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //-------------------------------------------------- Delete Document by Document Id--------------------------------

        public Response Delete(int documentsID)
        {
            try
            {
                return _idocumentRepository.Delete(documentsID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //----------------------------------------------------Download Document by DocumentID---------------------------------------




        public DocumentViewModel GetAll(int userID)
        {
            DocumentViewModel response = new DocumentViewModel();
            try
            {

                response = _idocumentRepository.GetAll(userID);
                var i = 0;
                foreach (var item in response.DocumentModelList)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources//") + response.DocumentModelList[i].FileGroup;
                    if (File.Exists(path))
                    {

                        response.DocumentModelList[i].FileGroup = path;
                    }

                    else
                    {
                        Console.WriteLine("{0} is not a valid file or directory.", path);
                    }
                    i++;
                }



                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        }
}
