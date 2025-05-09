using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Datas.Concrete
{
    public class EmergencyRepository :IEmergencyRepository
    {
        public readonly IDatabaseContext _idb_context;
        public EmergencyRepository(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }


        //-----------------------------------------------save Update Emergency Details---------------------------------------

        public Response SaveUpdate(EmergencyModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@EmergencyID", model.EmergencyID);
                parameters.Add("@UserID", model.UserID);


                parameters.Add("@PersonName", model.PersonName);
                parameters.Add("@PhoneNumber", model.PhoneNumber);
                parameters.Add("Relation", model.Relation);

             
                var result = _idb_context.Query<EmergencyModel>("SaveUpdateEmergency", parameters, null, CommandType.StoredProcedure);
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

        //--------------------------------- Get All Emergency Details by EmergencyModelView----------------------------------------
        public EmergencyModelView GetAll(int userID)
        {
            EmergencyModelView report = new EmergencyModelView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@UserID", userID);

                var _report = _idb_context.Query<EmergencyModel>("GetAllEmergancy", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.EmergencyModelList = _report;

                        if (report.EmergencyModelList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Emergency Details not found";
                        }
                    }
                }
                else
                {
                    report.EmergencyModelList = null;
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


        //----------------------------------------------Delete Emergency Details by emergency ID--------------------------------------------

        public Response Delete(int emergencyID)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmergencyID", emergencyID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<EmergencyModel>("DeleteEmergency", parameters, null, CommandType.StoredProcedure);
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
