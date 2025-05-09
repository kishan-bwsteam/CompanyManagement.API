
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
	public class LeaveDataRepository : ILeaveDataRepository
	{
		public readonly IDatabaseContext _idb_context;
		public LeaveDataRepository(IDatabaseContext _dbcontext)
		{
            _idb_context = _dbcontext;
		}




		//--------------------------------------------Save Update Leave-------------------------------------
		public Response SaveUpdate(LeaveModel model)
		{
			Response response = new Response();
			try
			{

				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@LeaveRequestID", model.LeaveRequestID);
				parameters.Add("@UserID", model.UserID);
				parameters.Add("@LeaveStatusID", model.LeaveStatusID);
				parameters.Add("@FromDate", model.FromDate);
				parameters.Add("@ToDate", model.ToDate);
				parameters.Add("@IsDeleted ", model.IsDeleted);
				parameters.Add("@LeaveReasonId", model.LeaveReasonId);
				parameters.Add("@AttachmentName", model.AttachmentName);

				var result = _idb_context.Query<string>("fetchUserLeaveRequest", parameters, null, CommandType.StoredProcedure);
				
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
				throw ex;
			}
			return response;
		}


		//-------------------------------------------Get upload Attachment --------------------------------------------------

		public Response GetAtt(LeaveModel model)
		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@LeaveRequestAttachmentID", model.@LeaveRequestAttachmentID);
				parameters.Add("@LeaveRequestID", model.LeaveRequestID);
				parameters.Add("@AttachmentName", model.AttachmentName);
				parameters.Add("@IsDeleted", 0);
				parameters.Add("@UpdatedBy", model.UserID);
				var result = _idb_context.Query<string>("SaveUpdate_LeaveRequestAttachment", parameters, null, CommandType.StoredProcedure);

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
				throw ex;
			}
			return response;
		}


		//-------------------------------------------Get All Leave by LeaveViewModels--------------------------------------------------

		public LeaveViewModels GetAll(int CompanyID)
		{
			LeaveViewModels report = new LeaveViewModels();
			try
			{

				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@CompanyID", CompanyID);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var _report = _idb_context.Query<LeaveModel>("GetLeaveDetailCompany", parameters, commandType: CommandType.StoredProcedure).ToList();

				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.leaveViewModel = _report;
						if (report.leaveViewModel.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = " Deatils Not found";
						}
					}
				}
				else
				{
					report.leaveViewModel = null;
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







        //-------------------------------------------Get All Leave by UserID--------------------------------------------

        public LeaveViewModels GetAllUser(int userID)
        {
            LeaveViewModels report = new LeaveViewModels();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", userID);
                parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


                var _report = _idb_context.Query<LeaveModel>("GetLeaveDetailUser", parameters, commandType: CommandType.StoredProcedure).ToList();

                if (_report != null)
                {
                    report.Status = parameters.Get<int>("@Status");
                    report.Message = parameters.Get<string>("@Message");
                    if (report.Status == 200)
                    {
                        report.leaveViewModel = _report;
                        if (report.leaveViewModel.Count == 0)
                        {
                            report.Status = (int)ErrorStatus.Error;
                            report.Message = " Deatils Not found";
                        }
                    }
                }
                else
                {
                    report.leaveViewModel = null;
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




        //------------------------------------------Update Approval Leave-------------------------------------------

        public Response Update(int Accept, int leaveRequestID)
		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@Accept", Accept);
				parameters.Add("@leaveRequestID", leaveRequestID);
				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("LeaveApproveReject", parameters, null, CommandType.StoredProcedure);

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
				throw ex;
			}
			return response;
		}


		//------------------------------------------ Get Status Dropdown by StatusViewModel-----------------------------

		public StatusViewModel GetStatus()
		{
			StatusViewModel report = new StatusViewModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				var _report = _idb_context.Query<DropdownLeaveStatusModel>("LeaveStatusDrop", parameters, commandType: CommandType.StoredProcedure).ToList();

				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.Statuslist = _report;
						if (report.Statuslist.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Status not found";
						}
					}
				}
				else
				{
					report.Statuslist = null;
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



		//------------------------------------------------------------Get Reason by ReasonViewModel ------------------------------------
		public ReasonViewModel GetReason()
		{
			ReasonViewModel report = new ReasonViewModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				var _report = _idb_context.Query<DropdownLeaveReasonModel>("LeaveReasonPro", parameters, commandType: CommandType.StoredProcedure).ToList();

				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.Reasonlist = _report;
						if (report.Reasonlist.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Detail not found";
						}
					}
				}
				else
				{
					report.Reasonlist = null;
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

		//------------------------------------------ Get Approval  by ReasonViewModel(Dropdown)-------------------


		public ReasonViewModel GetApp()
		{
			ReasonViewModel report = new ReasonViewModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				var _report = _idb_context.Query<DropdownLeaveReasonModel>("LeaveReasonPro", parameters, commandType: CommandType.StoredProcedure).ToList();

				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.Reasonlist = _report;
						if (report.Reasonlist.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Detail not found";
						}
					}
				}
				else
				{
					report.Reasonlist = null;
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


		//---------------------------------------------Get Single Approve Leave model List by SingleApproveLeave-----------------------------------

		public SingleApproveLeave GetSingle(int leaveRequestID)
		{
			SingleApproveLeave report = new SingleApproveLeave();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@leaveRequestID", leaveRequestID);
				var _report = _idb_context.Query<LeaveModel>("GetSingleApproveLeave", parameters, null, CommandType.StoredProcedure);
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200 )
					{
						report.SALeave = _report.FirstOrDefault();
						if (report.SALeave == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Position Details not found";
						}
					}
					else
					{
						report.SALeave = null;
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

		//-------------------------------------------- Delete Leave Request by leave Request ID-------------------------------------------------------

		public Response Delete(int leaveRequestID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@leaveRequestID", leaveRequestID);
				var result = _idb_context.Query<string>("DeleteLeaveEmployeeLeave", parameters, null, CommandType.StoredProcedure);
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
