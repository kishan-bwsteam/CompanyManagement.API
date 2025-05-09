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
    public class WagesRepository : IWagesRepository
    {
        public readonly IDatabaseContext _idb_context;
        public WagesRepository(IDatabaseContext _dbcontext)
        {
            _idb_context = _dbcontext;
        }

        //-----------------------------------Save Update Wages------------------------------

        public Response SaveUpdate(WagesModel model)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@WagesID", model.WagesID);
                parameters.Add("@WagesDetailsID", model.WagesDetailsID);

                parameters.Add("@Startdate", model.Startdate);
                parameters.Add("@WagesType", model.WagesType);
                parameters.Add("@FileAttachment", model.FileAttachment);
                parameters.Add("@CompanySalrayComponentId", model.CompanySalrayComponentId);
                parameters.Add("@UserID", model.UserID);
                parameters.Add("@CompanyID", model.CompanyID);
                parameters.Add("@WagesDetailsID", 0);
                parameters.Add("@Wages", model.Wages);
                parameters.Add("@GrossSalary", model.GrossSalary);
                parameters.Add("@TotalDeductions", model.TotalDeductions);
                parameters.Add("@CTCDeducation", model.CTCDeducation);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);



                var result = _idb_context.Query<WagesModel>("SaveWages", parameters, null, CommandType.StoredProcedure);
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

        //-----------------------------------Get All Wages------------------------------
        public WagesModelView Get()
        {
            WagesModelView report = new WagesModelView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();

                var _report = _idb_context.Query<WagesModel>("GetAllWages", parameters, commandType: CommandType.StoredProcedure).ToList();
                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.WagesModelList = _report;

                        if (report.WagesModelList.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = "Wages Details not found";
                        }
                    }
                }
                else
                {
                    report.WagesModelList = null;
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

        //-----------------------------------Delete Wages by wagesID----------------------------------
        public Response Delete(int WagesID)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@WagesID", WagesID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<WagesModel>("DeleteWages", parameters, null, CommandType.StoredProcedure);
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
        public MultiWagesModelView GetStructureSalary(string Box)
        {
            MultiWagesModelView report = new MultiWagesModelView();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                var split = Box.Split('-');
                parameters.Add("@UserID", Int32.Parse(split[0]));
                parameters.Add("@CompanySalrayComponentId", Int32.Parse(split[1] == "undefined"? "0": split[1])) ;
               
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);



                var _report = _idb_context.Query<WagesStructureModel>("GetWagesSalaryStructureDemo", parameters, null, CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");



                
                    if (report.Status == 200)
                    {

                        report.multiStructureList = _report;
                        {
                            if (report.multiStructureList.Count == 0)
                            {
                                report.Status = (int)ErrorStatus.Error;
                                report.Message = "Salary Structure not found";
                            }
                        }
                    }
                }
                else
                {
                    report.multiStructureList = null;
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




        //public MultiWagesModelView GetUserStructure(int UserID)
        //{
        //    MultiWagesModelView report = new MultiWagesModelView();
        //    try
        //    {
        //        DynamicParameters parameters = CommonRepository.GetLogParameters();
                
        //        parameters.Add("@UserID", UserID);
          

        //        parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
        //        parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);



        //        var _report = _idb_context.Query<WagesStructureModel>("GetWagesUserSalaryStructureDemo", parameters, null, CommandType.StoredProcedure).ToList();

        //        if (_report != null)
        //        {
        //            report.Status = parameters.Get<int>("@Status");
        //            report.Message = parameters.Get<string>("@Message");




        //            if (report.Status == 200)
        //            {

        //                report.multiStructureList = _report;
        //                {
        //                    if (report.multiStructureList.Count == 0)
        //                    {
        //                        report.Status = (int)ErrorStatus.Error;
        //                        report.Message = "Salary Structure not found";
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            report.multiStructureList = null;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        report.Status = (int)ErrorStatus.Exception;
        //        report.Message = ex.Message;
        //    }
        //    catch (DataException ex)
        //    {
        //        report.Status = (int)ErrorStatus.Exception;
        //        report.Message = ex.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        report.Status = (int)ErrorStatus.Exception;
        //        report.Message = ex.Message;
        //    }
        //    return report;
        //}






    }
}
