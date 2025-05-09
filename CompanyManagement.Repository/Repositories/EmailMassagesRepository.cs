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
   public class EmailMassagesRepository : IEmailMassagesRepository
    {
        public readonly IDatabaseContext _idb_context;
        public EmailMassagesRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }


		//-------------------------------------------------Save Update Email message ------------------------------ 


		public Response SaveUpdate(EmailMassagesModel model)
         {
            Response response = new Response();
            try
            {
                DynamicParameters parameters = CommonRepository.GetLogParameters();
                parameters.Add("@EmailMessageID", model.EmailMessageID);
                parameters.Add("@TempleteName", model.TempleteName);
				parameters.Add("@UserID",model.UserID);
                parameters.Add("@Body", model.Body);
                parameters.Add("@MailSubject", model.MailSubject);
                parameters.Add("@CompanyID", model.CompanyID);
                parameters.Add("@IsDeleted", model.IsDeleted);
                parameters.Add("@CreatedOn", model.CreatedOn);
                parameters.Add("@CreatedBy", model.CreatedBy);
                parameters.Add("@UpdatedOn", model.UpdatedOn);
                parameters.Add("@UpdatedBy", model.UpdatedBy);
              


                var result = _idb_context.Query<EmergencyModel>("SaveUpdateEmailMessage", parameters, null, CommandType.StoredProcedure);
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



		//---------------------------------------------Get All Email Message By EmailMessagesViewModel------------------
		public EmailMessagesViewModel GetAll(int UserID)

		{
			EmailMessagesViewModel report = new EmailMessagesViewModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@UserID", UserID);

				var _report = _idb_context.Query<EmailMassagesModel>("GetAllEmailMessage", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.EmailMassagesModelList = _report;

						if (report.EmailMassagesModelList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Message not found";
						}
					}
				}
				else
				{
					report.EmailMassagesModelList = null;
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







		//---------------------------------------------Get All Email Message By EmailMessagesViewModel------------------
		public EmailMessagesViewModel GetAllCompanyMail(int CompanyID)

		{
			EmailMessagesViewModel report = new EmailMessagesViewModel();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", CompanyID);

				var _report = _idb_context.Query<EmailMassagesModel>("GetAllEmailMessageCompany", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.EmailMassagesModelList = _report;

						if (report.EmailMassagesModelList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Message not found";
						}
					}
				}
				else
				{
					report.EmailMassagesModelList = null;
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



		//--------------------------------------------- Get  Single Message (List) by EmpID-----------------------

		public SingleEmailMassagesViewModel GetSingle(int empID)

		{
			SingleEmailMassagesViewModel report = new SingleEmailMassagesViewModel();

			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@EmailMessageID", empID);

				var _report = _idb_context.Query<EmailMassagesModel>("GetSingleMail", parameters, null, CommandType.StoredProcedure);
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.SingleModelList = _report.FirstOrDefault();
						if (report.SingleModelList == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Email Message not found";
						}
					}
					else
					{
						report.SingleModelList = null;
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







		//-------------------------------------------- Delete Email Message by EmpID----------------------------------


		public Response Delete(int empID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@EmailMessageID", empID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("Delete_EmailMessage", parameters, null, CommandType.StoredProcedure);
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
