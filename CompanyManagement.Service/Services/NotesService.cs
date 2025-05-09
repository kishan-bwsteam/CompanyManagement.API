using Authentication.DataManager.Helper;
using Datas.Abstract;
using Datas.Concrete;
using Dto.Model;
using Dto.Model.Common;
using Service.Abstract;
using SqlDapper.Concrete;
using System;


namespace Service.Concrete
{
   public class NotesService :INotesService
    {
        

            EncryptHelperObj obj = new EncryptHelperObj();

            private readonly INotesRepository _inotesRepository;

            public NotesService(INotesRepository _notesRepository)
            {
                _inotesRepository = _notesRepository;
            }


        //--------------------------------------------save update Notes-------------------------------


        public Response SaveUpdate(NotesModel model)
            {
                try
                {
                    return _inotesRepository.SaveUpdate(model);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }


        //----------------------------- Get All Notes by NotesModelView------------------

        public NotesModelView Get()
            {
                try
                {
                    return _inotesRepository.Get();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }


        //----------------------------------------- Delete Notes by NotesID-------------------------------- 

        public Response Delete(int notesID)
            {
                try
                {
                    return _inotesRepository.Delete(notesID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
}
