using Dto.Model;
using Dto.Model.Common;

namespace Datas.Abstract
{
    public interface IDocumentsRepository
    {


        //------------------------------------------------- Save Update Documents------------------------
        Response SaveUpdate(DocumentsModel model);

        //---------------------------------------------- Get All Document by DocumentViewModel--------------------------------
        DocumentViewModel GetAll(int userID);

        //-------------------------------------------------- Delete Document by Document Id--------------------------------
        Response Delete(int documentsID);

        //----------------------------------------------------Download Document by DocumentID---------------------------------------
        //Response Download(int documentsID);
       // DownloadViewModel Download(int documentsID);
      
    }
}
