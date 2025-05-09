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
public    class EmployeeDetailRepository : IEmployeeDetailRepository
    {
        public readonly IDatabaseContext _idb_context;
        
        public EmployeeDetailRepository(IDatabaseContext _db_context)
        {
            _idb_context = _db_context;
        }


        //------------------------------------------------------ Get Employee Deatils by Company Id---------------------------------------------------------

        public Response SaveOrUpdate(EmployeeDetail model, int actionBy)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EmpId", model.EmpId ?? 0); // 0 if null
                parameters.Add("@UserID", model.UserID ?? 0);
                parameters.Add("@EmpCode", model.EmpCode);
                parameters.Add("@DOB", model.DOB);
                parameters.Add("@DOH", model.DOH);
                parameters.Add("@DepartmentID", model.DepartmentID);
                parameters.Add("@EmployeeStatusID", model.EmployeeStatusID);
                parameters.Add("@BloodGroup", model.BloodGroup);
                parameters.Add("@CompanyID", model.CompanyId);
                parameters.Add("@RoleID", model.RoleId);
                parameters.Add("@EmailId", model.EmailID);
                parameters.Add("@ActionBy", actionBy);

                _idb_context.Execute("SaveOrUpdateEmployeeDetail",
                                     parameters,
                                     commandType: CommandType.StoredProcedure);

                return new Response
                {
                    Status = 200,
                    Message = model.EmpId > 0 ? "Employee updated" : "Employee created"
                };
            }
            catch (SqlException ex)
            {
                return new Response { Status = 500, Message = "SQL Error: " + ex.Message };
            }
            catch (Exception ex)
            {
                return new Response { Status = 500, Message = "Error: " + ex.Message };
            }
        }


        public EmployeeDetailViewModels Get(int companyId)
		{
			EmployeeDetailViewModels report = new EmployeeDetailViewModels();
			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@CompanyID", companyId);

				var _report = _idb_context.Query<EmployeeDetailModel>("GetEmployeeDetail", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.EmployeeDetailList = _report;

						if (report.EmployeeDetailList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = "Employee not found";
						}
					}
				}
				else
				{
					report.EmployeeDetailList = null;
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

		//------------------------------------------------------------------Delete Employee-------------------------


		public Response Delete(int userID)

		{
			Response response = new Response();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@UserID", userID);

				parameters.Add("@Status", 0, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);
				var result = _idb_context.Query<string>("Delete_EmployeeDetail", parameters, null, CommandType.StoredProcedure);
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
