using Dto.Model.Common;
 
using System.Collections.Generic;


namespace Dto.Model
{


    //------------------------------------------------ Documents Model-------------------------------------


  public  class DocumentsModel :Response
    {
        public int UserID { get; set; }
        public int DocumentsID { get; set; }

        public int FileType { get; set; }
        public string FileName { get; set; }
        public string FileGroup { get; set; }
  

    }


    //------------------------------ Documents Model List------------------------------ 


    public class DocumentViewModel:Response
    {
        public List<DocumentsModel> DocumentModelList { get; set; }
    }



    public class DownloadDocument:Response
    {
        public string FileGroup { get; set; }
    }

    public class DownloadViewModel : Response
    {
        public DownloadDocument DownloadList { get; set; }
    }
}


//---------------------------------------- File Attachment Model ------------------------


public class UploadingResult
{
    public string filepath { get; set; }
    public int Status { get; set; }
    public string Message { get; set; }
}

