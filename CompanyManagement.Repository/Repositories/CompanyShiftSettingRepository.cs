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
    public class CompanyShiftSettingRepository : ICompanyShiftSettingRepository
    {
        public readonly IDatabaseContext _idb_context;
        public CompanyShiftSettingRepository(IDatabaseContext _databaseContext)
        {
            _idb_context = _databaseContext;
        }



        //-------------------------------- Save Update Company Shift Setting-------------------------------------------

        public Response SaveUpdate(ShiftSettingModel modal)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@ShiftID", modal.ShiftID);
                parameters.Add("@ShiftName", modal.ShiftName);
                parameters.Add("@ToTime", modal.ToTime);
                parameters.Add("@FromTime", modal.FromTime);
                parameters.Add("@CompanyID", modal.CompanyID);
                parameters.Add("@CreatedBy", modal.CreatedBy);
                
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                var result = _idb_context.Query<string>("SaveUpdateCompanyShiftSetting", parameters, null, CommandType.StoredProcedure);
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

        //----------------------Get All Company Shift By CompanyID----------------------------------
        public ShiftSettingViewModel Get(int companyID)
        {
            ShiftSettingViewModel report = new ShiftSettingViewModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@CompanyID", companyID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                using (var multi = _idb_context.QueryMultiple("GetAllShiftSetting", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.shiftSettingModalList = (List<ShiftSettingModel>)multi.Read<ShiftSettingModel>();
                    }
                  


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


        //-----------------------------------Get Single Shift by Shift ID-------------------------------------


        public SingleShiftSettingModel GetSingle(int companyId,int ShiftID)
        {
            SingleShiftSettingModel report = new SingleShiftSettingModel();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                parameters.Add("@ShiftID", ShiftID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                /*using (var multi = dbcontext.QueryMultiple("GetSingleShiftSetting", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.SingleShiftSettingModal = (ShiftSettingModel)multi.Read<ShiftSettingModel>();
                    }



                }*/

                var _report = _idb_context.Query<ShiftSettingModel>("GetSingleShiftSetting", parameters, null, CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.singleShiftSettingModal = _report;
                        if (report.singleShiftSettingModal.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Details not found";
                        }
                    }
                    else
                    {
                        report.singleShiftSettingModal = null;
                    }
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
        //-----------------------------------Delete Shift by Shift ID-------------------------------------
        public Response Delete(int shiftID)

        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftID", shiftID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<string>("Delete_ShiftSetting", parameters, null, CommandType.StoredProcedure);
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

