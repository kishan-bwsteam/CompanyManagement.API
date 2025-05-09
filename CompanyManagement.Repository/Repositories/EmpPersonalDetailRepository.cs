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
    public class EmpPersonalDetailRepository : IEmpPersonalDetailRepository
    {

        public readonly IDatabaseContext _idb_context;
        public EmpPersonalDetailRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }


		//---------------------------------------- Save Update Personal Details------------------------------------------

		public Response SaveUpdate(EmpPersonalDetailModel model)

		{

			Response response = new Response();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", model.CompanyID);
				parameters.Add("@UserID", model.UserID);
				parameters.Add("@UserGuid ", model.UserGuid);
				parameters.Add("@FirstName", model.FirstName);
				parameters.Add("@MiddleName", model.MiddleName);
				parameters.Add("@LastName", model.LastName);
				parameters.Add("@UserName ", model.UserName);
				parameters.Add("@IsDeleted ", model.IsDeleted);
				parameters.Add("@CreatedBy", model.CreatedBy);
				parameters.Add("@DOB", model.DOB);
				parameters.Add("@UserTypeID", model.UserTypeID);
				parameters.Add("@UpdatedBy", model.LoginUserID);
				parameters.Add("@EmailID ", model.EmailID);
				parameters.Add("@BloodGroup", model.BloodGroup);
				parameters.Add("@PrimaryPhoneNo", model.PrimaryPhoneNo);
				parameters.Add("@SecondaryPhoneNo", model.SecondaryPhoneNo);
				parameters.Add("@DOH", model.DOH);
				parameters.Add("@EmpCode", model.EmpCode);
				parameters.Add("@PassKey", model.PassKey);
				parameters.Add("@SaltKey", model.SaltKey);
				parameters.Add("@SaltKeyIV", model.SaltKeyIV);
				parameters.Add("@DepartmentId", model.DepartmentID);
				parameters.Add("@PositionID", model.RoleID);
				parameters.Add("@EmployeeStatusId", model.EmployeeStatusID);
				var result = _idb_context.Query<EmpPersonalDetailModel>("EmpPersonalDetail", parameters, null, CommandType.StoredProcedure);
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

		//--------------------------------------- Get All Personal Detail by EmpPersonalDetailViewModels----------------------------

		public EmpPersonalDetailViewModels Get()
		{
			EmpPersonalDetailViewModels report = new EmpPersonalDetailViewModels();		
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
			
				var _report = _idb_context.Query<EmpPersonalDetailModel>("GetPersonaldetailData", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.PersonalDetailModelList = _report;

						if (report.PersonalDetailModelList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Details not found";
						}
					}
				}
				else
				{
					report.PersonalDetailModelList = null;
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


		//-------------------------------------- Get Single Details by  SinglePersonalDetailResponseModel------------------

		public SinglePersonalDetailResponseModel GetSingle(int userID)

		{
			SinglePersonalDetailResponseModel report = new SinglePersonalDetailResponseModel();

			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@UserID", userID);
		
				var _report = _idb_context.Query<EmpPersonalDetailModel>("GetSinglePersonaldetailData", parameters, null, CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.SingleModelList = _report;
						if (report.SingleModelList == null)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "User Details not found";
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



		//---------------------------------------- Delete User Details By UserID----------------------
		public Response Delete(int userID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@UserID", userID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("DeletePersonalDetail", parameters, null, CommandType.StoredProcedure);
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



		


		//--------------------------------------------------- Get All Department by DepartmentViewModel-------------------------------
		public DepartmentViewModel GetDepartment()
		{
			{
				DepartmentViewModel report = new DepartmentViewModel();
				try
				{
					DynamicParameters parameters = CommonRepository.GetLogParameters();
					var _report = _idb_context.Query<DepartmentDropdown>("GetDepartment_DropDown", parameters, commandType: CommandType.StoredProcedure).ToList();

					if (_report != null)
					{
						report.Status = parameters.Get<int>("@Status");
						report.Message = parameters.Get<string>("@Message");
						if (report.Status == 200)
						{
							report.DepartmentList = _report;
							if (report.DepartmentList.Count == 0)
							{
								report.Status = (int)ErrorStatus.Error;
								report.Message = "Country not found";
							}
						}
					}
					else
					{
						report.DepartmentList = null;
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


		//---------------------------------------------------- Get All Position by PositionViewModel---------------------

		public PositionViewModel GetPosition()
		{
			{
				PositionViewModel report = new PositionViewModel();
				try
				{
					DynamicParameters parameters = CommonRepository.GetLogParameters();
					var _report = _idb_context.Query<PositionDropDown>("GetPosition_DropDown", parameters, commandType: CommandType.StoredProcedure).ToList();

					if (_report != null)
					{
						report.Status = parameters.Get<int>("@Status");
						report.Message = parameters.Get<string>("@Message");
						if (report.Status == 200)
						{
							report.PositionList = _report;
							if (report.PositionList.Count == 0)
							{
								report.Status = (int)ErrorStatus.Error;
								report.Message = "Country not found";
							}
						}
					}
					else
					{
						report.PositionList = null;
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
}
