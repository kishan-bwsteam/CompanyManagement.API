using Dto.Model;
using Dto.Model.Common;

namespace Datas.Abstract
{
    public interface INotesRepository
    {
        //-------------------------------------------------save update Notes------------------------------
        Response SaveUpdate(NotesModel model);

        //----------------------------- Get All Notes by NotesModelView------------------
        NotesModelView Get();

        //----------------------------------------- Delete Notes by NotesID-------------------------------- 

        Response Delete(int notesID);
    }
}
