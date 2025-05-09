using CompanyManagement.Datas.Concrete;
using Dapper;
using Datas.Abstract;

using Dto.Model.Common;
using Microsoft.Data.SqlClient;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;

namespace Datas.Concrete
{



    public class AttendanceRepository : IAttendanceRepository
    {
        public readonly IDatabaseContext _idb_context;
        public AttendanceRepository(IDatabaseContext databaseContext)
        {
            _idb_context = databaseContext;
        }




        //---------------------Save Update Attendance------------------------------- 


        public Response SaveUpdate(AttendanceModal modal)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                 parameters.Add("@AttendanceID",modal.AttendanceID);
                 parameters.Add("@EmployeeID", modal.EmployeeID);
                parameters.Add("@CompanyID", modal.CompanyID);
                parameters.Add("@InDate", modal.InDate);
                parameters.Add("@InTime", modal.InTime);
                parameters.Add("@OutTime", modal.OutTime);
                parameters.Add("@OutDate", modal.OutDate);
                parameters.Add("@CreatedBy", modal.CreatedBy);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                var result = _idb_context.Query<string>("SaveUpdateAttendance", parameters, null, CommandType.StoredProcedure);
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

       

        //---------------------Get All Employee-------------------------------

        public AttendanceViewModels GetAll( int companyID)
        {
            AttendanceViewModels report = new AttendanceViewModels();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@CompanyID", companyID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

                parameters.Add("@CompanyID", companyID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);

             
                using (var multi = _idb_context.QueryMultiple("GetAllEmployeeAttendance", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.AttendanceModel = (List<AttendanceModal>)multi.Read<AttendanceModal>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.TotalTimeAttendanceModel = (List<SelectAttendanceModal>)multi.Read<SelectAttendanceModal>();
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



     



        //---------------------Delete Attendance-------------------------------

        public Response Delete(int attendanceID)
        {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AttendanceID", attendanceID);

                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                var result = _idb_context.Query<string>("Delete_Attendance", parameters, null, CommandType.StoredProcedure);
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

        //---------------------Get Single Employee Attendance By EmployeeID-------------------------------

        public SingleAttendanceViewModels GetSingle(int employeeID,int companyID)

        {
            SingleAttendanceViewModels report = new SingleAttendanceViewModels();

            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@EmpID", employeeID);
                parameters.Add("@companyID", companyID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
                using (var multi = _idb_context.QueryMultiple("GetSingleAttandance", parameters, null, CommandType.StoredProcedure))
                {
                    if (!multi.IsConsumed)
                    {
                        report.SingleAttendanceModelList = (List<AttendanceModal>)multi.Read<AttendanceModal>();
                    }
                    if (!multi.IsConsumed)
                    {
                        report.TotalTimeAttendanceModel = (List<SelectAttendanceModal>)multi.Read<SelectAttendanceModal>();
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

    }
}
