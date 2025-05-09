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
    public class DocumentsRepository : IDocumentsRepository
    {

        public readonly IDatabaseContext _idb_context;
        public DocumentsRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }



        //------------------------------------------------- Save Update Documents------------------------



        public Response SaveUpdate(DocumentsModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@DocumentsID", model.DocumentsID);
                parameters.Add("@FileName", model.FileName);
                parameters.Add("@FileType", model.FileType);
                parameters.Add("@FileGroup", model.FileGroup);
                parameters.Add("@UserID", model.UserID);
             
                var result = _idb_context.Query<DocumentsModel>("Document", parameters, null, CommandType.StoredProcedure);
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

        //---------------------------------------------- Get All Document by DocumentViewModel--------------------------------
        public DocumentViewModel GetAll(int userID)
        {
            DocumentViewModel report = new DocumentViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@UserID", userID);

                var _report = _idb_context.Query<DocumentsModel>("GetAllDocument", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.DocumentModelList = _report;

                        if (report.DocumentModelList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Document not found";
                        }
                    }
                }
                else
                {
                    report.DocumentModelList = null;
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


        //-------------------------------------------------- Delete Document by Document Id--------------------------------


        public Response Delete(int documentsID)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DocumentsID", documentsID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<DocumentsModel>("DeleteDocuments", parameters, null, CommandType.StoredProcedure);
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


        //----------------------------------------------------Download Document by DocumentID---------------------------------------
        public DownloadViewModel Download(int documentsID)
        {
            DownloadViewModel response = new DownloadViewModel();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DocumentsID", documentsID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<DownloadDocument>("DownloadDocuments", parameters, null, CommandType.StoredProcedure);
                if (result != null)
                {
                    response.Status = parameters.Get<int>("@Status");
                    response.Message = parameters.Get<string>("@Message");
                    if (response.Status == 200)
                    {
                        response.DownloadList = result.FirstOrDefault();
                        if (response.DownloadList == null)
                        {
                            response.Status = (int)ErrorStatus.Error;
                            response.Message = "Dept Details not found";
                        }
                    }
                    else
                    {
                        //response.DownloadList = null;
                    }
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
