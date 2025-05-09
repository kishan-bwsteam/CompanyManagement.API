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
   public class JoiningLetterRepository:IJoiningLetterRepository
    {
		public readonly IDatabaseContext _idb_context;
		public JoiningLetterRepository(IDatabaseContext _db_context)
		{
			_idb_context = _db_context;
		}

		public Response SaveUpdate()
        {
            return null;
        }
		//--------------------------------------------- Get  Single Template (List) by template name-----------------------

		public SingleLetterViewModel GetSingleLetterByTemplate(string TemplateName, int CompanyID)

		{
			SingleLetterViewModel report = new SingleLetterViewModel();

			try
			{
				DynamicParameters parameters = CommonRepository.GetLogParameters();
				parameters.Add("@TemplateName", TemplateName);
				parameters.Add("@CompanyID", CompanyID);

				var _report = _idb_context.Query<LetterModel>("GetLetterByTemplate", parameters, null, CommandType.StoredProcedure);
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
							report.Message = "Letter Template not found";
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

	}

}
