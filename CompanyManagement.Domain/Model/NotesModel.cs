using Dto.Model.Common;

using System.Collections.Generic;


namespace Dto.Model
{

    //--------------------------------------------- Notes Model------------------------------

    public class NotesModel :Response
    {
        public int NotesID { get; set; }
        public int UserID { get; set; }
        public string Notes { get; set; }
    }


    //--------------------------------------------- Notes Model List------------------------------

    public class NotesModelView : Response
    {
        public List<NotesModel> NotesModelList { get; set; }
    }
}
