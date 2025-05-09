using Dto.Model;
using Dto.Model.Common;


namespace Service.Abstract
{
  public  interface IDocumentsService
    {


        //------------------------------------------------- Save Update Documents------------------------
        Response SaveUpdate(DocumentsModel model);

        //---------------------------------------------- Get All Document by DocumentViewModel--------------------------------
        DocumentViewModel GetAll(int userID);

        //-------------------------------------------------- Delete Document by Document Id--------------------------------
        Response Delete(int documentsID);

        //----------------------------------------------------Download Document by DocumentID---------------------------------------
        
     //   DownloadViewModel Download(int documentsID);
     

    }
}
