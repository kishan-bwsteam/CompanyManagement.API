using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;

using Dto.Model.Common;
using Dto.Responses;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System;

using System.Data;
using Microsoft.Data.SqlClient;



namespace Datas.Concrete
{
    public class OfficialCommunicationRepository : IOfficialCommunicationRepository
    {
        public readonly IDatabaseContext _idb_context;
        public OfficialCommunicationRepository(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }


        //--------------------------------------------Save Upadte Offical information----------------------

    //    public OfficalCommResponse SaveUpdate(OfficalCommModel model)
    //    {
    //        OfficalCommResponse response = new OfficalCommResponse();
    //        try
    //        {
    //            DynamicParameters parameters = CommonRepository.GetLogParameters();
    //            parameters.Add("@OfficialId", model.OfficialId);
    //            parameters.Add("@EmpCode", model.EmpCode);
    //            parameters.Add("@DateOfJoining", model.DOH);
    //            parameters.Add("@EmailId", model.EmailId);
    //            parameters.Add("@PhoneNo", model.PhoneNo);
    //            parameters.Add("@TypeName", model.Name);
    //            parameters.Add("@TypeValue", model.Value);
    //            parameters.Add("@UserID", model.UserID);
    //            parameters.Add("@CreatedBy", model.CreatedBy);
    //            parameters.Add("@UpdatedBy", model.UpdatedBy);
    //            var result = _idb_context.Query<OfficalCommModel>("SaveUpdate_EmpOfficialcommunication", parameters, null, CommandType.StoredProcedure);
    //            if (result != null)
    //            {
    //                response.Status = parameters.Get<int>("Status");
    //                response.Message = parameters.Get<string>("Message");
    //            }

    //        }

    //        catch (SqlException ex)
    //        {
    //            response.Status = (int)ErrorStatus.Exception;
    //            response.Message = ex.Message;

    //        }
    //        catch (DataException ex)
    //        {

    //            response.Status = (int)ErrorStatus.Exception;
    //            response.Message = ex.Message;

    //        }

    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }

    //        return response;
    //    }


    //    //------------------------------------------- Get All offical Communication by OfficalViewModel--------------

    //    public OfficalViewModel Get()
    //    {
    //        OfficalViewModel report = new OfficalViewModel();
    //        try
    //        {
    //            DynamicParameters parameters = CommonRepository.GetLogParameters();

    //            var _report = _idb_context.Query<OfficalCommModel>("GetUserOfficialDetails", parameters, commandType: CommandType.StoredProcedure).ToList();
    //            if (_report != null)
    //            {
    //                report.Status = parameters.Get<int>("@Status");
    //                report.Message = parameters.Get<string>("@Message");
    //                if (report.Status == 1)
    //                {
    //                    report.OfficalCommList = _report;

    //                    if (report.OfficalCommList.Count == 0)
    //                    {
    //                        report.Status = (int)ErrorStatus.Error;
    //                        report.Message = "User not found";
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                report.OfficalCommList = null;
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            report.Status = (int)ErrorStatus.Exception;
    //            report.Message = ex.Message;
    //        }
    //        catch (DataException ex)
    //        {
    //            report.Status = (int)ErrorStatus.Exception;
    //            report.Message = ex.Message;
    //        }
    //        catch (Exception ex)
    //        {
    //            report.Status = (int)ErrorStatus.Exception;
    //            report.Message = ex.Message;
    //        }
    //        return report;
        
    //}

        //------------------------------------------- Get SaveUpdate Other-----------------------------------------
        public OfficalCommResponse SaveUpdate(OfficialOtherModel model)
        {
            OfficalCommResponse response = new OfficalCommResponse();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@OfficialId", model.OfficialID);
                

                parameters.Add("@TypeName", model.Name);
                parameters.Add("@TypeValue", model.Value);
                parameters.Add("@UserID", model.UserID);
                parameters.Add("@CreatedBy", model.CreatedBy);
                parameters.Add("@UpdatedBy", model.UpdatedBy);
                var result = _idb_context.Query<OfficialOtherModel>("SaveUpdateOthersOffical", parameters, null, CommandType.StoredProcedure);
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
        //----------------------------------------Get All Others Details-----------------------------------------
        public OfficalOtherModelList Get()
        {
            OfficalOtherModelList report = new OfficalOtherModelList();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                var _report = _idb_context.Query<OfficialOtherModel>("GetAllOthersOffical", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)                                        
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.OfficalOthersList = _report;

                        if (report.OfficalOthersList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Offical Other not found";
                        }
                    }
                }
                else
                {
                    report.OfficalOthersList = null;
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

        //-----------------------------------------------------Delete Offical Details by OfficalID--------------------------------
        public OfficalCommResponse Delete(int OfficalId)
        {
            OfficalCommResponse response = new OfficalCommResponse();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OfficalID", OfficalId);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<OfficalCommResponse>("Delete_OfficialDetails", parameters, null, CommandType.StoredProcedure);
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
