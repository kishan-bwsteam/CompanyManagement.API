using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
    public class NotesRepository : INotesRepository
    {
        public readonly IDatabaseContext _idb_context;
        public NotesRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }


        //-------------------------------------------------save update Notes------------------------------

        public Response SaveUpdate(NotesModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@NotesID", model.NotesID);
                parameters.Add("@UserID", model.UserID);


                parameters.Add("@Notes", model.Notes);


                var result = _idb_context.Query<EmergencyModel>("SaveUpdateNotes", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("Status");
                    response.Message = parameters.Get<string>("Message");
                }

            }

            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;

            }
            catch (DataException ex)
            {

                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        //----------------------------- Get All Notes by NotesModelView------------------

        public NotesModelView Get()
        {
            NotesModelView report = new NotesModelView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                var _report = _idb_context.Query<NotesModel>("GetAllNotes", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.NotesModelList = _report;

                        if (report.NotesModelList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Notes Details not found";
                        }
                    }
                }
                else
                {
                    report.NotesModelList = null;
                }
            }
            catch (SqlException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (DataException ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            catch (Exception ex)
            {
                report.Status = (int)ErrorStatus.Exception;
                report.Message = ex.Message;
            }
            return report;

        }


        //----------------------------------------- Delete Notes by NotesID-------------------------------- 

        public Response Delete(int notesID)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NotesID", notesID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<NotesModel>("", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                }
            }
            catch (SqlException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (DataException ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.Status = (int)ErrorStatus.Exception;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}
