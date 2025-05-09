using Dapper;
using Datas.Abstract;
using Dto.Model;
using Dto.Model.Common;
using Microsoft.Data.SqlClient;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;

namespace Datas.Concrete
{
    public class CalLeaveRepository : ICalLeaveRepository
    {
        public readonly IDatabaseContext _idb_context;
        public CalLeaveRepository(IDatabaseContext databaseContext)
        {
            _idb_context = databaseContext;
        }


		//---------------------------------------Calaculate leave by CalLeaveViewModel-------------------
		public CalLeaveViewModel GetLeave(RequestLeave model)
		{
			CalLeaveViewModel report = new CalLeaveViewModel();
			try
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@FromDate", model.FromDate);
				parameters.Add("@ToDate", model.ToDate);
				parameters.Add("@EmployeeID",model.EmployeeID);
				parameters.Add("@Status", 1, DbType.Int32, ParameterDirection.Output);
				parameters.Add("@Message", "", DbType.String, ParameterDirection.Output);


				var _report = _idb_context.Query<CalLeaveModel>("GetLeaveReport2", parameters, commandType: CommandType.StoredProcedure).ToList();
				if (_report != null)
				{
					report.Status = parameters.Get<int>("@Status");
					report.Message = parameters.Get<string>("@Message");
					if (report.Status == 200)
					{
						report.CalLeaveList = _report;
						if (report.CalLeaveList.Count == 0)
						{
							report.Status = (int)ErrorStatus.Error;
							report.Message = " Leave Deatils Not found";
						}

					}
				}
				else
				{
					report.CalLeaveList = null;
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
